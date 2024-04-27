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
}

public class ResearchTask: UnitTask {

}

public class ResearchModal: Modal {
    static ResearchTask[] tasks = {
        new() {
            title = "��������� ENIAC",
            description = "��� �������, ��� ��� ������ ����������� �������� ����������� ������ ����������, ������� ����� ���� ������������������� ��� ������� �������� ������� �����. ������ ���������, ����, ��� �� ��� ������ ������ �����������.\r\n\r\n����� ����������� ���������� ������ � ������ � �������� � ������������� ENIAC, ����� ����� ������ ����� ���������� ���� �������� � �� ����� � ����� ������� ��������� ������ � �������� ��� ������� ������� ���� �������.",
            requiredResearchScore = 1,
            requiredScienceScore = 2,
            outResearchScore = 3,
            outScienceScore = 4,
            duration = 15
        },
        new() {
            title = "�������� ������",
            description = "����� ����� ����� ��� �����...",
            requiredResearchScore = 8,
            requiredScienceScore = 7,
            outResearchScore = 6,
            outScienceScore = 5,
            duration = 15
        },
        new() {
            title = "������������� ����������",
            description = "����� ����� ����� ��� �����...",
            requiredResearchScore = 9,
            requiredScienceScore = 10,
            outResearchScore = 11,
            outScienceScore = 12,
            duration = 30
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
