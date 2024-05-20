using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Scenario;

public abstract class UnitTask {
    public string title;
    public string description;
    public int requiredResearchScore;
    public int requiredScienceScore;
    public int outResearchScore;
    public int outScienceScore;
    public float duration;
    public UnitTaskEvent[] events;
}

public class UnitTaskEvent {
    public int time;
    public int research;
    public int science;
    public Trigger trigger;
}

public class ResearchTask: UnitTask {

}

public class ResearchModal: Modal {
    public static int availTaskIndex = 0;
    static readonly ResearchTask[] tasks = {
        new() {
            title = "Появление ENIAC",
            description = "Тут сказано, что это первый электронный цифровой вычислитель общего назначения, который можно было перепрограммировать для решения широкого спектра задач. Звучит интересно, жаль, что не все модули хорошо сохранились.\r\n\r\nБудем исследовать оставшиеся модули и данные о создании и использовании ENIAC, чтобы лучше понять какие технологии были доступны в ту эпоху и какие решения принимали учёные и инженеры для решения проблем того времени.",
            requiredResearchScore = 0,
            requiredScienceScore = 3,
            outResearchScore = 14,
            outScienceScore = 4,
            duration = 145,
            events = new UnitTaskEvent[] {
                new() { time = 2, research = 1 },
                new() { time = 10, research = 2 },
                new() { time = 16, research = 1, science = 2 },
                new() { time = 48, research = 4 },
                new() { time = 52, research = 2 },
                new() { time = 68, research = 1 },
                new() { time = 80, research = 3 },
                new() { time = 101, research = 2, science = 2 },
                new() { time = 115, research = 1 },
                new() { time = 130, research = 2 },
                new() { time = 140, research = 1 },
                new() { time = 144, trigger = Trigger.EniacDocsEvent }
            }
        },
        new() {
            title = "Изучить проводку",
            description = "Модуль издает странные звуки, стоить проверить...",
            requiredResearchScore = 4,
            requiredScienceScore = 1,
            outResearchScore = 8,
            outScienceScore = 1,
            duration = 80,
            events = new UnitTaskEvent[] {
                new() { time = 2, research = 1 },
                new() { time = 10, research = 2 },
                new() { time = 16, research = 0, science = 4 },
                new() { time = 48, research = 1 },
                new() { time = 52, research = 2 },
                new() { time = 68, research = 1 },
                new() { time = 79, research = 1, trigger = Trigger.WiresEvent }
            }
        },
        new() {
            title = "Подготовить перфокарту",
            description = "Первый шаг к программированию",
            requiredResearchScore = 10,
            requiredScienceScore = 3,
            outResearchScore = 4,
            outScienceScore = 13,
            duration = 45,
            events = new UnitTaskEvent[] {
                new() { time = 2, research = 1, science = 4 },
                new() { time = 10, research = 2, science = 1 },
                new() { time = 16, research = 1, science = 2, trigger = Trigger.PunchcardEvent },
                new() { time = 44, research = 1, science = 7, trigger = Trigger.PunchcardEventEnd }
            }
        },
        new() {
            title = "Откалибровать модуль",
            description = "Настройка перед реальной работой",
            requiredResearchScore = 4,
            requiredScienceScore = 14,
            outResearchScore = 10,
            outScienceScore = 1,
            duration = 145,
            events = new UnitTaskEvent[] {
                new() { time = 2, research = 1 },
                new() { time = 10, research = 1, trigger = Trigger.WiresEvent },
                new() { time = 16, research = 1, science = 1 },
                new() { time = 48, research = 1 },
                new() { time = 52, research = 1, trigger = Trigger.PunchcardEvent },
                new() { time = 68, research = 1 },
                new() { time = 80, research = 1 },
                new() { time = 101, research = 3, trigger = Trigger.WiresEvent }
            }
        },
        new() {
            title = "Написать программу",
            description = "Настал час",
            requiredResearchScore = 10,
            requiredScienceScore = 1,
            outResearchScore = 20,
            outScienceScore = 25,
            duration = 145,
            events = new UnitTaskEvent[] {
                new() { time = 2, research = 2 },
                new() { time = 10, research = 2 },
                new() { time = 16, research = 2, science = 10 },
                new() { time = 48, research = 1 },
                new() { time = 52, research = 2 },
                new() { time = 68, research = 2 },
                new() { time = 80, research = 1 },
                new() { time = 101, research = 2, science = 10 },
                new() { time = 115, research = 2 },
                new() { time = 130, research = 2 },
                new() { time = 140, research = 2, trigger = Trigger.SwitchesEvent }
            }
        },
        //new() {
        //    title = "Исследовать модуль",
        //    description = "Полный цикл разработки программы",
        //    requiredResearchScore = 56,
        //    requiredScienceScore = 47,
        //    outResearchScore = 11,
        //    outScienceScore = 12,
        //    duration = 60,
        //    events = new UnitTaskEvent[] {
        //        new() { time = 2, research = 1, science = 3 },
        //        new() { time = 10, research = 2, science = 1 },
        //        new() { time = 16, research = 1, science = 2 },
        //        new() { time = 48, research = 4, science = 2 },
        //        new() { time = 52, research = 3, science = 4 }
        //    }
        //},
        new() {
            title = "Технический осмотр модуля",
            description = "Примените на практике все, чему научились",
            requiredResearchScore = 18,
            requiredScienceScore = 8,
            outResearchScore = 24,
            outScienceScore = 30,
            duration = 145,
            events = new UnitTaskEvent[] {
                new() { time = 2, research = 1 },
                new() { time = 10, research = 2, trigger = Trigger.WiresEvent },
                new() { time = 16, research = 1, science = 2 },
                new() { time = 48, research = 4, trigger = Trigger.WiresEvent },
                new() { time = 52, research = 2 },
                new() { time = 68, research = 1 },
                new() { time = 80, research = 3, trigger = Trigger.PunchcardEvent },
                new() { time = 101, research = 2, science = 2 },
                new() { time = 115, research = 1 },
                new() { time = 130, research = 2, trigger = Trigger.SwitchesEvent },
                new() { time = 140, research = 1, trigger = Trigger.EniacEnd }
            }
        }
    };

    public Transform tasksViewport;
    public GameObject taskPrefab;

    private ResearchTask selectedTask;
    public TextMeshProUGUI taskTitle;
    public TextMeshProUGUI taskDescription;
    public ScannerUnitBehaviour unit;

    void Start () {
        var topOffset = -4f;
        var i = 0;

        foreach (var task in tasks) {
            var taskObject = Instantiate(taskPrefab, tasksViewport);
            taskObject.transform.localPosition += new Vector3(0, topOffset, 0);

            var taskTransform = (RectTransform) taskObject.transform;
            topOffset -= taskTransform.sizeDelta.y + 4;

            var card = taskObject.GetComponent<UnitTaskCard>();
            card.task = task;

            var cardBtn = taskObject.GetComponent<Button>();
            cardBtn.onClick.AddListener(() => {
                selectedTask = task;
                taskTitle.text = task.title;
                taskDescription.text = task.description;
            });

            cardBtn.interactable = i == availTaskIndex;
            i++;
        }
    }

    public void TakeTask () {
        if (selectedTask == null) return;

        unit.SetTask(selectedTask);
        Close();
    }
}
