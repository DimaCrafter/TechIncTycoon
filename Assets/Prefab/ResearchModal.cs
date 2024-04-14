using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResearchTask {
    public string title;
    public string description;
    public int requiredResearchScore;
    public int requiredScienceScore;
    public int outResearchScore;
    public int outScienceScore;
}

public class ResearchModal: MonoBehaviour {
    static ResearchTask[] tasks = {
        new() {
            title = "Появление ENIAC",
            description = "Тут сказано, что это первый электронный цифровой вычислитель общего назначения, который можно было перепрограммировать для решения широкого спектра задач. Звучит интересно, жаль, что не все модули хорошо сохранились.\r\n\r\nБудем исследовать оставшиеся модули и данные о создании и использовании ENIAC, чтобы лучше понять какие технологии были доступны в ту эпоху и какие решения принимали учёные и инженеры для решения проблем того времени.",
            requiredResearchScore = 1,
            requiredScienceScore = 2,
            outResearchScore = 3,
            outScienceScore = 4
        },
        new() {
            title = "Передача данных",
            description = "Лорем ипсум долор сит эммет...",
            requiredResearchScore = 8,
            requiredScienceScore = 7,
            outResearchScore = 6,
            outScienceScore = 5
        },
        new() {
            title = "Моделирование вычислений",
            description = "Лорем ипсум долор сит эммет...",
            requiredResearchScore = 9,
            requiredScienceScore = 10,
            outResearchScore = 11,
            outScienceScore = 12
        }
    };

    public Transform tasksViewport;
    public GameObject taskPrefab;

    private ResearchTask selectedTask;
    public TextMeshProUGUI taskTitle;
    public TextMeshProUGUI taskDescription;

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

    void Update () {
        
    }
}
