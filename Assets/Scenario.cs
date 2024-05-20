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
        new DialogStep("����� ���������� �� ��� ����� ������� �����, �������������! ��� �� ��� ������, �� �������� ������������ ������� �������������� �����, ����� ����� ������ ����."),
        new DialogStep("���� ��� �������� � ���, ��� ���� ���������� �������������� ����������, � ����� � ���, ������� � ���� ������� ��� �����������. ����� ������� ����������� ������� �������, ����� ����������� ��������!"),
        new DialogStep("..."),
        new DialogStep("��, ��. � ����� ����������� 2 ������ ENIAC, ������� ���� ��������� ��������� �� ����� � �������� ����. ��� �� ���� ��� ��� �����... � ��� ��� �������, ��� � ����������!"),
        new DialogStep("�������� � �������� ����� ������� ������� - ���������� ������ ������ ��� ��, �� � ������� ���������� ���������� ���������� ������ � ���������� ����� ������."),
        new DialogStep("����� ������ ��������� ������� ������������ � �����, ������� � ��� ����� ����������. � �� �������, ��� ��� �� ��� �������! ��� �����, ������... �� ����� ��������..."),
        new DialogStep("..."),
        new DialogStep("����� � ����. ����� � �������� ���� ���������� ����� ��� ��������� �������. �������� ����� � ���������� ������ ������."),
        new ScienceRewardStep(3),

        new WaitTriggerStep(Trigger.ScannerInstall),
        new DialogStep("����� ��� ������ �������: ������������ ���������� ENIAC�. ������������ ���� ���� ������������, ����������� ��� ��������� �����������."),

        new WaitTriggerStep(Trigger.ResearchTaskStart),
        new DialogStep("�������! ������ �� ����� ������������ � ������� ����� ��������� ������ ���������� ��� ���������� �����-�� ���������, ������� ����� ���������� ��� �����������."),

        new WaitTriggerStep(Trigger.EniacDocsEvent),
        new ModalStep<Modal>(0),

        new WaitTriggerStep(Trigger.WiresEvent),
        new DialogStep("��������! ���������� ������������� � ������� ENIAC. ������������ ����������� �������� ������� �������� ���������. ��������� ����������� �������������."),
        new DialogStep("��� �������������� ������ ENIAC ���������� ��������� ��������� �������� ������."),
        new ModalStep<Modal>(1),
        new DialogStep("�������� ��������, ����������� ������������ � ��� �� ����"),

        new WaitTriggerStep(Trigger.PunchcardEvent),
        new DialogStep("������ ��� ����� ��������� ���������� ��� ���������� ����� ������������."),
        new DialogStep("���������� - ��� �������� ����������, �������������� ��� ����� ������ � �������� � �������������� ������. ������ ��������� �� ���������� ������������� ����������� ������� ��� ������."),
        new DialogStep("�������� ��������� ����������� ��� ��������� ����������"),
        //new DialogStep("��������� ���������� � ����������� ����������."),
        //new DialogStep("������� ������ �������, �������� ��������� � ��������������� ��������."),
        //new DialogStep("���������, ��� ��� ������ ������� ���������."),
        new ModalStep<Modal>(2),

        new WaitTriggerStep(Trigger.PunchcardEventEnd),
        new DialogStep("�������! ������ �� ����� ��� �������� � ������������, �����, ��� ���� ����� ����� ��� �������."),
        new DialogStep("������ �������� ������������� ENIAC. ���� ������ ��������� � �������� ������ �� ������ ������, ������ �����������, � ����� ������ ����� ���������� �������������."),
        new DialogStep("� ������ �������� ���������� ������������� ������ ���������, ��� �������� ��� ������� ��������!"),

        new WaitTriggerStep(Trigger.WiresEvent),
        new ModalStep<Modal>(1),

        new WaitTriggerStep(Trigger.PunchcardEvent),
        new ModalStep<Modal>(2),

        new WaitTriggerStep(Trigger.WiresEvent),
        new ModalStep<Modal>(1),

        new DialogStep("���������� ������ �������. ������ �� ����� ���������� � ���������� �����."),
        new WaitTriggerStep(Trigger.SwitchesEvent),

        new DialogStep("��� ��������� ��������� ENIAC ��� ������ � ����������� �����������, ��� ����� ������������ �������� �� ������ ������. ������� �� ��� ������."),
        new DialogStep("���������������� �� ������ ������ ����� ���������� ���-�� �������, ������ ����������� �������� ���������� � ������, �� ����������."),
        new DialogStep("������ ����� ��������� �������� �� ���������� � ����� ���������. ��� ���������� ��������� ���������� ������ ����������� �� ��������."),
        new DialogStep("������ ����� ���������� ����� ������� ����� ���������. � ������ ������ ��� �������� ��������, ����������, ��������� � �������."),
        new DialogStep("������ �������� �� ������ ���������� � ����������, ��������� ������ ���������. ��������� - ��� ����� ������� �� ���������� � ���� ���������� ���������."),
        new DialogStep("����� ����� ��������� �������� �� ��, ���� ���������� ��������� ���������� ���������. ��� ��� �� �������� ���������� �� ������� ��������� ����� ��������� ��������."),
        new DialogStep("������ ������, ������ �� �������� ������ �����. ���������� �������� ���� ������ ��������� �� ����� ���������� ������������."),
        new ModalStep<Modal>(3),

        new DialogStep("��� �������. �������� ����� ���� ����� � ��� ����� ����� ������� ��������� ENIAC."),
        new DialogStep("����������� ����������� ������."),

        //new WaitTriggerStep(Trigger.ResearchTaskStart), //����������, ����������������
        //new DialogStep("��� ��� ��������� �������. �������� ���, ���� ��������� �� ������ ������."),
        //new DialogStep("��������� ������ ���. ������ ������ � �������� ��� ���� ���������."),

        new WaitTriggerStep(Trigger.WiresEvent),
        new ModalStep<Modal>(1),

        new WaitTriggerStep(Trigger.WiresEvent),
        new ModalStep<Modal>(1),

        new WaitTriggerStep(Trigger.PunchcardEvent),
        new ModalStep<Modal>(2),

        new WaitTriggerStep(Trigger.SwitchesEvent),
        new ModalStep<Modal>(3),

        new WaitTriggerStep(Trigger.EniacEnd),
        new DialogStep("����������! �� ������ ������ ���� ������� ���������� ������. ������ �� ������ ������� ���� ������������ ENIAC!"),
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
