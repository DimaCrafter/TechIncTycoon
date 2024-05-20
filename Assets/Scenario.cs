using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Scenario: MonoBehaviour {
    public enum Trigger {
        None,
        DialogClose,
        ScannerInstall,
        ResearchTaskStart,
        EniacDocsEvent,
        WiresEvent,
        PunchcardEvent,
        PunchcardEventEnd,
        SwitchesEvent,
        EniacEnd
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

    public class ModalStep<T>: Step where T : Modal {
        public uint modalIndex;
        public ModalStep (uint modalIndex) {
            this.modalIndex = modalIndex;
        }

        public override Task Execute () {
            var prefab = GameplayController.instance.modalPrefabs[modalIndex];
            var modal = Modal.Open<T>(prefab);
            Time.timeScale = 0;

            var taskSource = new TaskCompletionSource<object>();
            modal.onClose += () => {
                Time.timeScale = 1;
                taskSource.SetResult(null);
            };
            
            return taskSource.Task;
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
        gameState = new GameState(); // FileManager.LoadJson<GameState>("game_state.json");
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
        new DialogStep("Ближе к делу. Рядом с модулями есть выделенные места для установки сканера. Выберите любое и установите первый сканер."),
        new ScienceRewardStep(3),

        new WaitTriggerStep(Trigger.ScannerInstall),
        new DialogStep("Дадим ему первое задание: Исследование «Появление ENIAC». Исследования дают очки исследований, необходимые для улучшения лаборатории."),

        new WaitTriggerStep(Trigger.ResearchTaskStart),
        new DialogStep("Отлично! Иногда во время исследования у сканера может появиться важная информация или возникнуть какая-то сложность, которую нужно преодолеть для продолжения."),

        new WaitTriggerStep(Trigger.EniacDocsEvent),
        new ModalStep<Modal>(0),

        new WaitTriggerStep(Trigger.WiresEvent),
        new DialogStep("Внимание! Обнаружена неисправность в системе ENIAC. Некорректное подключение проводов вызвало короткое замыкание. Требуется немедленное вмешательство."),
        new DialogStep("Для восстановления работы ENIAC необходимо правильно настроить передачу данных."),
        new ModalStep<Modal>(1),
        new DialogStep("Проблема миновала, продолжайте исследования в том же духе"),

        new WaitTriggerStep(Trigger.PunchcardEvent),
        new DialogStep("Теперь нам нужно настроить перфокарту для следующего этапа исследования."),
        new DialogStep("Перфокарта - это носитель информации, использующийся для ввода данных и программ в вычислительные машины. Каждое отверстие на перфокарте соответствует определённой команде или данным."),
        new DialogStep("Следуйте найденным инструкциям для настройки перфокарты"),
        //new DialogStep("Поместите перфокарту в считывающее устройство."),
        //new DialogStep("Введите нужные команды, пробивая отверстия в соответствующих позициях."),
        //new DialogStep("Убедитесь, что все данные введены корректно."),
        new ModalStep<Modal>(2),

        new WaitTriggerStep(Trigger.PunchcardEventEnd),
        new DialogStep("Отлично! Теперь мы знаем как работать с перфокартами, думаю, что этот навык будет нам полезен."),
        new DialogStep("Сейчас треуется откалибровать ENIAC. Хоть данная процедура и выглядит просто на первый взгляд, будьте внимательны, в любой момент может возникнуть неисправность."),
        new DialogStep("В случае успешной калибровки эффективность модуля возрастет, что позволит нам быстрее работать!"),

        new WaitTriggerStep(Trigger.WiresEvent),
        new ModalStep<Modal>(1),

        new WaitTriggerStep(Trigger.PunchcardEvent),
        new ModalStep<Modal>(2),

        new WaitTriggerStep(Trigger.WiresEvent),
        new ModalStep<Modal>(1),

        new DialogStep("Калибровка прошла успешно. Теперь мы можем переходить к следующему этапу."),
        new WaitTriggerStep(Trigger.SwitchesEvent),

        new DialogStep("Нам требуется настроить ENIAC для работы с конкретными программами, для этого используются тумблеры на панели модуля. Изучите их для начала."),
        new DialogStep("Программирование на первый взгляд может показаться чем-то сложным, однако внимательно прочитав инструкция я уверен, вы справитесь."),
        new DialogStep("Первая серия тумблеров отвечает за переменную в нашем уравнении. При исполнении программы переменная примет присвоенное ей значение."),
        new DialogStep("Вторая серия определяет какая оперция будет исполнена. В данный момент нас доступно сложение, выичитание, умножение и деление."),
        new DialogStep("Третья отвечает за вторую переменную в уравнениее, четвертая задает константу. Константа - это число которое не изменяется в ходе исполнения программы."),
        new DialogStep("Пятая серия тумблеров отвечает за то, куда поместится результат исполнения программы. Она так же является переменной из которой программа может извлекать значение."),
        new DialogStep("Звучит сложно, однако на практике станет проще. Попробуйте написать свою первую программу во время следующего исследования."),
        new ModalStep<Modal>(3),

        new DialogStep("Так держать. Осталась всего пара шагов и вас можно будет назвать экспертом ENIAC."),
        new DialogStep("Продалжайте исследовать модуль."),

        //new WaitTriggerStep(Trigger.ResearchTaskStart), //Перфокарта, программирование
        //new DialogStep("Даю вам последние задание. Покажите все, чему научились на данный момент."),
        //new DialogStep("Проведите полный тех. осмотр модуля и напишите еще одну программу."),

        new WaitTriggerStep(Trigger.WiresEvent),
        new ModalStep<Modal>(1),

        new WaitTriggerStep(Trigger.WiresEvent),
        new ModalStep<Modal>(1),

        new WaitTriggerStep(Trigger.PunchcardEvent),
        new ModalStep<Modal>(2),

        new WaitTriggerStep(Trigger.SwitchesEvent),
        new ModalStep<Modal>(3),

        new WaitTriggerStep(Trigger.EniacEnd),
        new DialogStep("Поздравляю! На данный момент было собрано достаточно данных. Теперь вы можете считать себя специалистом ENIAC!"),
        new ModalStep<Modal>(4)
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
