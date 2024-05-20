using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public Scenario.Trigger trigger;
}

public class ResearchTask: UnitTask {

}

public class ResearchModal: Modal {
    static ResearchTask[] tasks = {
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
                new() { time = 140, research = 1 }
            }
        },
        new() {
            title = "Проверить проводку",
            description = "Модуль издает странные звуки, стоить проверить...",
            requiredResearchScore = 14,
            requiredScienceScore = 7,
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
                new() { time = 80, research = 1 },
            }
        },
        new() {
            title = "Подготовить перфокарту",
            description = "Первый шаг к программированию",
            requiredResearchScore = 22,
            requiredScienceScore = 8,
            outResearchScore = 4,
            outScienceScore = 13,
            duration = 45,
            events = new UnitTaskEvent[] {
                new() { time = 2, research = 1, science = 4 },
                new() { time = 10, research = 2, science = 1 },
                new() { time = 16, research = 1, science = 2 },
                new() { time = 45, research = 1, science = 7 }
            }
        },
        new() {
            title = "Откалибровать модуль",
            description = "Настройка перед реальной работой",
            requiredResearchScore = 26,
            requiredScienceScore = 21,
            outResearchScore = 10,
            outScienceScore = 1,
            duration = 145,
            events = new UnitTaskEvent[] {
                new() { time = 2, research = 1 },
                new() { time = 10, research = 1 },
                new() { time = 16, research = 1, science = 1 },
                new() { time = 48, research = 1 },
                new() { time = 52, research = 1 },
                new() { time = 68, research = 1 },
                new() { time = 80, research = 1 },
                new() { time = 101, research = 3}
            }
        },
        new() {
            title = "Написать программу",
            description = "Настал час",
            requiredResearchScore = 36,
            requiredScienceScore = 22,
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
                new() { time = 140, research = 2 }
            }
        },
        new() {
            title = "Исследовать модуль",
            description = "Полный цикл разработки программы",
            requiredResearchScore = 56,
            requiredScienceScore = 47,
            outResearchScore = 11,
            outScienceScore = 12,
            duration = 60,
            events = new UnitTaskEvent[] {
                new() { time = 2, research = 1, science = 3 },
                new() { time = 10, research = 2, science = 1 },
                new() { time = 16, research = 1, science = 2 },
                new() { time = 48, research = 4, science = 2 },
                new() { time = 52, research = 3, science = 4 }
            }
        },
        new() {
            title = "Технический осмотр модуля",
            description = "Примените на практике все, чему научились",
            requiredResearchScore = 67,
            requiredScienceScore = 59,
            outResearchScore = 24,
            outScienceScore = 30,
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
                new() { time = 140, research = 1 }
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
        }
    }

    public void TakeTask () {
        if (selectedTask == null) return;

        unit.SetTask(selectedTask);
        Close();
    }
}
