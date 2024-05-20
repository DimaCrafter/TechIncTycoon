using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.Events;

public class generate_quiz : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public TMP_Text output, question;
    public Toggle toggle_1, toggle_2, toggle_3, toggle_4;
    public string[] questions = new string[]
    {
        "��� ����� ���������� � ��������� �����������?",
        "����� ������������ ������ � ��������� ��������� � 1890 ����?",
        "����� ��� �������� ����� �������� ������ �� �����������?",
        "����� ��� ����������� ENIAC, ������ ����������� ��������� � ����?",
        "��� �������� �������� ���������� ENIAC?",
        "����� ������� ����� � ������ ������ ENIAC?",
        "����� ��� �������� ����� �������� ENIAC?",
        "����� ����������� ���������� �������������� � ENIAC?",
        "������ ���� �������������� �������� ENIAC?",
        "����� ������� ���� ENIAC?"
    };
    public string[] right_ans = new string[]
    {
        "���������� � ��� ��������������� ����� � ����������� ��� ����������������",
        "������ ��������",
        "���������� ������������ ����������� � �����, ����������� ��������� ������� � ������.",
        "1946 ���",
        "���� ������� ������ � ���� ������ �����",
        "����������� ����� ��� ��������� � �������� ������.",
        "������� ������� ������� � ���������� �����, ������� ������ ������� �� ����� ������ ������� �����.",
        "��������� �����",
        "����� 5000 �������� � �������",
        "����� 30�50 �����"
    };
    public string[] wrong_ans_1 = new string[]
    {
        "���������� � ���������� ��� ������ ������� ����������� �� ��������.",
        "������ �������",
        "������ ������������ � �������������� ��������� ����� �� ����������� �����.",
        "1960 ���",
        "���� �������",
        "������������ ������ ��� ����������.",
        "��������� ������� � ����������.",
        "�����������",
        "1 ������� �������� � �������",
        "10�10 ������"
    };
    public string[] wrong_ans_2 = new string[]
    {
        "���������� � ��� ��������� ����� ��� �������� ������.",
        "���� �������",
        "������ ����� ����� ���������� ������� ��� �������� ����������.",
        "1955 ���",
        "������ �������",
        "���������� ����� ��� �������� ����������.",
        "����������� � ����.",
        "���������� ����",
        "10 000 �������� � �������",
        "5�5 �����"
    };
    public string[] wrong_ans_3 = new string[]
    {
        "���������� � ��������� ��� ������ ���������� �� �������.",
        "������ ������",
        "���������� ������������ ����������� �������� �������� ����� �������.",
        "1935 ���",
        "���� �����",
        "������������������ ����� ��������� ������.",
        "�������� ������������� ������������ �������.",
        "���������",
        "100 �������� � �������",
        "100�100 �����������"
    };

    private int questionIndex = -1;
    public void Generate_Question () {
        if (++questionIndex == questions.Length) {
            onDone.Invoke();
            return;
        }

        question.text = questions[questionIndex];
        string[] ans_pool = new string[4];

        ans_pool[0] = right_ans[questionIndex];
        ans_pool[1] = wrong_ans_1[questionIndex];
        ans_pool[2] = wrong_ans_2[questionIndex];
        ans_pool[3] = wrong_ans_3[questionIndex];

        string tmp, tmp1, tmp2, tmp3;
        tmp = ans_pool[Random.Range(0, 4)];
        toggle_1.GetComponentInChildren<Text>().text = tmp;
        tmp1 = tmp;
        while (tmp == tmp1)
            tmp = ans_pool[Random.Range(0, 4)];
        toggle_2.GetComponentInChildren<Text>().text = tmp;
        tmp2 = tmp;
        while (tmp == tmp1 || tmp2 == tmp)
            tmp = ans_pool[Random.Range(0, 4)];
        toggle_3.GetComponentInChildren<Text>().text = tmp;
        tmp3 = tmp;
        while (tmp == tmp1 || tmp2 == tmp || tmp3 == tmp)
            tmp = ans_pool[Random.Range(0, 4)];
        toggle_4.GetComponentInChildren<Text>().text = tmp;
    }

    private float outputVisibleTime = 0;
    void Update () {
        if (outputVisibleTime != 0) {
            if (outputVisibleTime > 0) {
                outputVisibleTime -= Time.unscaledDeltaTime;
            } else {
                outputVisibleTime = 0;
                output.text = "";

                Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
                if (toggle.GetComponentInChildren<Text>().text == right_ans[questionIndex]) {
                    Generate_Question();
                }
            }
        }
    }

    public UnityEvent onDone;
    public void Check () {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        if (toggle.GetComponentInChildren<Text>().text == right_ans[questionIndex]) {
            output.text = "����� ������!";
        } else {
            output.text = "������������ �����";
        }

        outputVisibleTime = 1.75f;
    }
}
