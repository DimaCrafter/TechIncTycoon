using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Scenario: MonoBehaviour {
    public enum Trigger {
        None,
        DialogClose,
        ScannerInstall,
        ResearchTaskStart
    }

    public abstract class Step {
        public abstract Task Execute ();
    }

    public class DialogStep: Step {
        public string text { get; private set; }
        public DialogStep (string text) {
            this.text = text;
        }

        public override Task Execute () {
            GameplayController.instance.dialog.StartDialog(text);
            return WaitTrigger(Trigger.DialogClose);
        }
    }

    public class ScienceRewardStep: Step {
        public int score { get; private set; }

        public ScienceRewardStep (int score) {
            this.score = score;
        }

        public override Task Execute () {
            GameplayController.instance.IncrementScienceScore(null, score);
            return null;
        }
    }

    public class WaitTriggerStep: Step {
        public Trigger trigger { get; private set; }

        public WaitTriggerStep (Trigger trigger) {
            this.trigger = trigger;
        }

        public override Task Execute () {
            return WaitTrigger(trigger);
        }
    }

    public class SaveStep: Step {
        public bool lockSave { get; private set; }

        public SaveStep (bool lockSave) {
            this.lockSave = lockSave;
        }

        public override Task Execute () {
            saveLocked = false;
            SaveProgress();

            saveLocked = lockSave;
            return null;
        }
    }

    public class TriggerListener {
        public Trigger trigger;
        public TaskCompletionSource<object> handler;
    }

    private static readonly List<TriggerListener> triggerListeners = new();
    public static void Fire (Trigger trigger) {
        TriggerListener listener;

        for (var i = triggerListeners.Count; i --> 0; ) {
            listener = triggerListeners[i];

            if (listener.trigger == trigger) {
                triggerListeners.RemoveAt(i);
                listener.handler.SetResult(null);
            }
        }
    }

    public static Task WaitTrigger (Trigger trigger) {
        var taskSource = new TaskCompletionSource<object>();
        triggerListeners.Add(new() {
            trigger = trigger,
            handler = taskSource
        });

        return taskSource.Task;
    }

    public static GameState gameState { get; private set; }
    static Scenario () {
        gameState = FileManager.LoadJson<GameState>("game_state.json");
    }

    public static bool saveLocked { get; private set; } = true;
    public static void SaveProgress () {
        if (saveLocked) return;

        FileManager.SaveJson("game_state.json", gameState);
    }

    public static readonly Step[] steps = new Step[] {
        new DialogStep("Добро пожаловать на своё новое рабочее место, исследователь! Как Вы уже знаете, мы пытаемся восстановить историю вычислительных машин, чтобы лучше понять себя."),
        new DialogStep("Мало что известно о том, как люди изобретали вычислительные технологии, а позже и нас, поэтому и была открыта эта лаборатория. Вашей команде потребуется изучить прошлое, чтобы возобновить прогресс!"),
        new DialogStep("..."),
        new DialogStep("Ах, да. У стены установлено 2 модуля ENIAC, которые были аккуратно извлечены из музея и помещены сюда. Сам не знаю что это такое... А вот как изучите, мне и расскажите!"),
        new DialogStep("Помогать в изучении будут рабочие сканеры - упрощённая модель робота без ИИ, но с хорошим механизмом построения логических связей и детального сбора данных."),
        new DialogStep("Такие сейчас исследуют прошлое человечества в целом, поэтому и тут могут пригодится. И не думайте, что без ИИ они неживые! Они живые, просто... не могут показать..."),
        new DialogStep("..."),
        new DialogStep("Ближе к делу. <как установить сканер>."),
        new ScienceRewardStep(12),

        new WaitTriggerStep(Trigger.ScannerInstall),
        new DialogStep("Дадим ему первое задание: Исследование. Исследования дают очки исследований, необходимые для <...>."),

        new WaitTriggerStep(Trigger.ResearchTaskStart),
        new DialogStep("Отлично! Иногда во время исследования у сканера может появиться важная информация или возникнуть какая-то сложность, которую нужно преодолеть для продолжения."),
        new SaveStep(false)
    };

    public static async void Play () {
        for (; gameState.scenarioStep < steps.Length; gameState.scenarioStep++) {
            var step = steps[gameState.scenarioStep];

            var task = step.Execute();
            if (task != null) {
                await task;
            }
        }
    }
}
