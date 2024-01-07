using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class generate_quiz : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public TMP_Text output, question;
    public Toggle toggle_1, toggle_2, toggle_3, toggle_4;
    private bool is_open = false;
    private string[] questions = new string[2]
    {
        "Да?",
        "Нет?"
    };
    private string[] right_ans = new string[2]
    {
        "Пизда",
        "Пидора ответ"
    };
    private string[] wrong_ans_1 = new string[2]
    {
        "Нет",
        "Нет"
    };
    private string[] wrong_ans_2 = new string[2]
    {
        "Да",
        "Да"
    };
    private string[] wrong_ans_3 = new string[2]
    {
        "Не знаю",
        "Не знаю"
    };
    public static int rand_num;
    public void Generate_Question()
    {
        rand_num = Random.Range(0, questions.Length);
        question.text = questions[rand_num];
        string[] ans_pool = new string[4];

        ans_pool[0] = right_ans[rand_num];
        ans_pool[1] = wrong_ans_1[rand_num];
        ans_pool[2] = wrong_ans_2[rand_num];
        ans_pool[3] = wrong_ans_3[rand_num];

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
    public void Check()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        if (toggle.GetComponentInChildren<Text>().text == right_ans[rand_num])
            output.text = "Ответ верный";
        else
            output.text = "Ответ не верный";
    }
}
