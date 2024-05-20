using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wireGame : MonoBehaviour
{
    private bool task_bar_state = false;
    public GameObject obj;
    public GameObject[] task_wires = new GameObject[5];
    public GameObject[] ans_wires = new GameObject[5];
    public GameObject[] task_obj = new GameObject[5];
    public GameObject[] ans_obj = new GameObject[5];
    public GameObject[] task_btn = new GameObject[5];
    public GameObject[] ans_btn = new GameObject[5];
    private int f_id = -1;
    private int s_id = -1;
    private int[] indexes = new int[5];
    private int[] ans_indexes = new int[5];
    private int[] inactive_indexes = new int[5] { -2, -2, -2, -2, -2 };
    private int[] inactive_ans_indexes = new int[5] { -2, -2, -2, -2, -2 };
    private int index_counter = 0;
    public void ShowTasks()
    {
        if (task_bar_state == false)
            task_bar_state = true;
        else
            task_bar_state = false;
        obj.SetActive(task_bar_state);
    }
    private void SetRandomIndexes()
    {
        for (int i = 0; i < 5; i++)
            indexes[i] = 0;
        int[] arr = { 1, 2, 3, 4, 5 };
        int tmp1, tmp2, tmp3, tmp4, tmp5;
        tmp1 = arr[Random.Range(0, arr.Length)];
        tmp2 = tmp1;
        while (tmp2 == tmp1)
        {
            tmp2 = arr[Random.Range(0, arr.Length)];
        }
        tmp3 = tmp1;
        while (tmp2 == tmp3 || tmp3 == tmp1)
        {
            tmp3 = arr[Random.Range(0, arr.Length)];
        }
        tmp4 = tmp1;
        while (tmp2 == tmp4 || tmp3 == tmp4 || tmp4 == tmp1)
        {
            tmp4 = arr[Random.Range(0, arr.Length)];
        }
        tmp5 = tmp1;
        while (tmp2 == tmp5 || tmp3 == tmp5 || tmp4 == tmp5 || tmp5 == tmp1)
        {
            tmp5 = arr[Random.Range(0, arr.Length)];
        }
        indexes[0] = tmp1;
        indexes[1] = tmp2;
        indexes[2] = tmp3;
        indexes[3] = tmp4;
        indexes[4] = tmp5;
    }
    private void SetRandomAnsIndexes()
    {
        for (int i = 0; i < 5; i++)
            ans_indexes[i] = 0;
        int[] arr = { 1, 2, 3, 4, 5 };
        int tmp1, tmp2, tmp3, tmp4, tmp5;
        tmp1 = arr[Random.Range(0, arr.Length)];
        tmp2 = tmp1;
        while (tmp2 == tmp1)
        {
            tmp2 = arr[Random.Range(0, arr.Length)];
        }
        tmp3 = tmp1;
        while (tmp2 == tmp3 || tmp3 == tmp1)
        {
            tmp3 = arr[Random.Range(0, arr.Length)];
        }
        tmp4 = tmp1;
        while (tmp2 == tmp4 || tmp3 == tmp4 || tmp4 == tmp1)
        {
            tmp4 = arr[Random.Range(0, arr.Length)];
        }
        tmp5 = tmp1;
        while (tmp2 == tmp5 || tmp3 == tmp5 || tmp4 == tmp5 || tmp5 == tmp1)
        {
            tmp5 = arr[Random.Range(0, arr.Length)];
        }
        ans_indexes[0] = tmp1;
        ans_indexes[1] = tmp2;
        ans_indexes[2] = tmp3;
        ans_indexes[3] = tmp4;
        ans_indexes[4] = tmp5;
    }
    private void SetWires()
    {
        for (int i = 0; i < 5; i++)
        {
            switch (i + 1)
            {
                case 1:
                    for(int j = 0; j < 5; j++)
                        if(indexes[j] == i + 1)
                            task_wires[j].GetComponent<Image>().color = Color.red;
                    for (int j = 0; j < 5; j++)
                        if (ans_indexes[j] == i + 1)
                            ans_wires[j].GetComponent<Image>().color = Color.red;
                    break;
                case 2:
                    for (int j = 0; j < 5; j++)
                        if (indexes[j] == i + 1)
                            task_wires[j].GetComponent<Image>().color = Color.blue;
                    for (int j = 0; j < 5; j++)
                        if (ans_indexes[j] == i + 1)
                            ans_wires[j].GetComponent<Image>().color = Color.blue;
                    break;
                case 3:
                    for (int j = 0; j < 5; j++)
                        if (indexes[j] == i + 1)
                            task_wires[j].GetComponent<Image>().color = Color.yellow;
                    for (int j = 0; j < 5; j++)
                        if (ans_indexes[j] == i + 1)
                            ans_wires[j].GetComponent<Image>().color = Color.yellow;
                    break;
                case 4:
                    for (int j = 0; j < 5; j++)
                        if (indexes[j] == i + 1)
                            task_wires[j].GetComponent<Image>().color = Color.green;
                    for (int j = 0; j < 5; j++)
                        if (ans_indexes[j] == i + 1)
                            ans_wires[j].GetComponent<Image>().color = Color.green;
                    break;
                case 5:
                    for (int j = 0; j < 5; j++)
                        if (indexes[j] == i + 1)
                            task_wires[j].GetComponent<Image>().color = Color.magenta;
                    for (int j = 0; j < 5; j++)
                        if (ans_indexes[j] == i + 1)
                            ans_wires[j].GetComponent<Image>().color = Color.magenta;
                    break;
            }
        }
    }
    private void Press_Obj()
    {
        if(f_id != -1 && s_id != -1)
        {
            if(indexes[f_id - 1] == ans_indexes[s_id - 1])
            {
                task_obj[f_id - 1].GetComponent<Image>().color = Color.green;
                ans_obj[s_id - 1].GetComponent<Image>().color = Color.green;
                inactive_indexes[index_counter] = f_id;
                inactive_ans_indexes[index_counter] = s_id;
                index_counter++;
                if (index_counter == 5)
                    FinishGame();
            }
        }

    }
    public void OnClick_btn1()
    {
        if (1 != inactive_indexes[0] && 1 != inactive_indexes[1] && 1 != inactive_indexes[2] && 1 != inactive_indexes[3] && 1 != inactive_indexes[4])
        {
            if (f_id == -1)
            {
                f_id = 1;
                task_obj[f_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
            else 
            {
                if (f_id != inactive_indexes[0] && f_id != inactive_indexes[1] && f_id != inactive_indexes[2] && f_id != inactive_indexes[3] && f_id != inactive_indexes[4])
                    task_obj[f_id - 1].GetComponent<Image>().color = Color.white;
                f_id = 1;
                task_obj[f_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
        }
    }
    public void OnClick_btn2()
    {
        if (2 != inactive_indexes[0] && 2 != inactive_indexes[1] && 2 != inactive_indexes[2] && 2 != inactive_indexes[3] && 2 != inactive_indexes[4])
        {
            if (f_id == -1)
            {
                f_id = 2;
                task_obj[f_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
            else 
            {
                if (f_id != inactive_indexes[0] && f_id != inactive_indexes[1] && f_id != inactive_indexes[2] && f_id != inactive_indexes[3] && f_id != inactive_indexes[4])
                    task_obj[f_id - 1].GetComponent<Image>().color = Color.white;
                f_id = 2;
                task_obj[f_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
        }
    }
    public void OnClick_btn3()
    {
        if (3 != inactive_indexes[0] && 3 != inactive_indexes[1] && 3 != inactive_indexes[2] && 3 != inactive_indexes[3] && 3 != inactive_indexes[4])
        {
            if (f_id == -1)
            {
                f_id = 3;
                task_obj[f_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
            else 
            {
                if (f_id != inactive_indexes[0] && f_id != inactive_indexes[1] && f_id != inactive_indexes[2] && f_id != inactive_indexes[3] && f_id != inactive_indexes[4])
                    task_obj[f_id - 1].GetComponent<Image>().color = Color.white;
                f_id = 3;
                task_obj[f_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
        }
    }
    public void OnClick_btn4()
    {
        if (4 != inactive_indexes[0] && 4 != inactive_indexes[1] && 4 != inactive_indexes[2] && 4 != inactive_indexes[3] && 4 != inactive_indexes[4])
        {
            if (f_id == -1)
            {
                f_id = 4;
                task_obj[f_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
            else 
            {
                if (f_id != inactive_indexes[0] && f_id != inactive_indexes[1] && f_id != inactive_indexes[2] && f_id != inactive_indexes[3] && f_id != inactive_indexes[4])
                    task_obj[f_id - 1].GetComponent<Image>().color = Color.white;
                f_id = 4;
                task_obj[f_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
        }
    }
    public void OnClick_btn5()
    {
        if (5 != inactive_indexes[0] && 5 != inactive_indexes[1] && 5 != inactive_indexes[2] && 5 != inactive_indexes[3] && 5 != inactive_indexes[4])
        {
            if (f_id == -1)
            {
                f_id = 5;
                task_obj[f_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
            else 
            {
                if (s_id != inactive_ans_indexes[0] && s_id != inactive_ans_indexes[1] && s_id != inactive_ans_indexes[2] && s_id != inactive_ans_indexes[3] && s_id != inactive_ans_indexes[4])
                    task_obj[f_id - 1].GetComponent<Image>().color = Color.white;
                f_id = 5;
                task_obj[f_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
        }
    }
    public void OnClick_btn6()
    {
        if (1 != inactive_ans_indexes[0] && 1 != inactive_ans_indexes[1] && 1 != inactive_ans_indexes[2] && 1 != inactive_ans_indexes[3] && 1 != inactive_ans_indexes[4])
        {
            if (s_id == -1)
            {
                s_id = 1;
                ans_obj[s_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
            else 
            {
                if (s_id != inactive_ans_indexes[0] && s_id != inactive_ans_indexes[1] && s_id != inactive_ans_indexes[2] && s_id != inactive_ans_indexes[3] && s_id != inactive_ans_indexes[4])
                    ans_obj[s_id - 1].GetComponent<Image>().color = Color.white;
                s_id = 1;
                ans_obj[s_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
        }
    }
    public void OnClick_btn7()
    {
        if (2 != inactive_ans_indexes[0] && 2 != inactive_ans_indexes[1] && 2 != inactive_ans_indexes[2] && 2 != inactive_ans_indexes[3] && 2 != inactive_ans_indexes[4])
        {
            if (s_id == -1)
            {
                s_id = 2;
                ans_obj[s_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
            else 
            {
                if (s_id != inactive_ans_indexes[0] && s_id != inactive_ans_indexes[1] && s_id != inactive_ans_indexes[2] && s_id != inactive_ans_indexes[3] && s_id != inactive_ans_indexes[4])
                    ans_obj[s_id - 1].GetComponent<Image>().color = Color.white;
                s_id = 2;
                ans_obj[s_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
        }
    }
    public void OnClick_btn8()
    {
        if (3 != inactive_ans_indexes[0] && 3 != inactive_ans_indexes[1] && 3 != inactive_ans_indexes[2] && 3 != inactive_ans_indexes[3] && 3 != inactive_ans_indexes[4])
        {
            if (s_id == -1)
            {
                s_id = 3;
                ans_obj[s_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
            else 
            {
                if (s_id != inactive_ans_indexes[0] && s_id != inactive_ans_indexes[1] && s_id != inactive_ans_indexes[2] && s_id != inactive_ans_indexes[3] && s_id != inactive_ans_indexes[4])
                    ans_obj[s_id - 1].GetComponent<Image>().color = Color.white;
                s_id = 3;
                ans_obj[s_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
        }
    }
    public void OnClick_btn9()
    {
        if (4 != inactive_ans_indexes[0] && 4 != inactive_ans_indexes[1] && 4 != inactive_ans_indexes[2] && 4 != inactive_ans_indexes[3] && 4 != inactive_ans_indexes[4])
        {
            if (s_id == -1)
            {
                s_id = 4;
                ans_obj[s_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
            else 
            {
                if (s_id != inactive_ans_indexes[0] && s_id != inactive_ans_indexes[1] && s_id != inactive_ans_indexes[2] && s_id != inactive_ans_indexes[3] && s_id != inactive_ans_indexes[4])
                    ans_obj[s_id - 1].GetComponent<Image>().color = Color.white;
                s_id = 4;
                ans_obj[s_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
        }
    }
    public void OnClick_btn10()
    {
        if (5 != inactive_ans_indexes[0] && 5 != inactive_ans_indexes[1] && 5 != inactive_ans_indexes[2] && 5 != inactive_ans_indexes[3] && 5 != inactive_ans_indexes[4])
        {
            if (s_id == -1)
            {
                s_id = 5;
                ans_obj[s_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
            else 
            {
                if (s_id != inactive_ans_indexes[0] && s_id != inactive_ans_indexes[1] && s_id != inactive_ans_indexes[2] && s_id != inactive_ans_indexes[3] && s_id != inactive_ans_indexes[4])
                    ans_obj[s_id - 1].GetComponent<Image>().color = Color.white;
                s_id = 5;
                ans_obj[s_id - 1].GetComponent<Image>().color = Color.black;
                Press_Obj();
            }
        }
    }
        void Start()
    {
        SetRandomAnsIndexes();
        SetRandomIndexes();
        SetWires();
        ShowTasks();
    }
    private void FinishGame()
    {
        obj.SetActive(false);
    }
    void Update()
    {
        
    }
}
