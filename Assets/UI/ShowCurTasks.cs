using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCurTasks : MonoBehaviour
{
    private bool task_bar_state = false;
    private string[] tasks = new string[50];
    private int task_count = 0;
    public Text task_text;
    public GameObject obj;
    public void ShowTasks()
    {
        if (task_bar_state == false)
            task_bar_state = true;
        else
            task_bar_state = false;
        obj.SetActive(task_bar_state);
    }
    public void AddTask(string new_task)
    {
        tasks[task_count] = new_task;
        task_count++;
        ShowTaskText();
    }
    public void RemoveTask(int id)
    {
        while(tasks[id + 2] != "")
        {
            tasks[id] = tasks[id + 1];
        }
        task_count--;
        ShowTaskText();
    }
    private void ShowTaskText()
    {
        for(int i = 0; i < task_count; i++)
        {
            task_text.text += tasks[i] + "\n";
        }
    }
    void Start()
    {
        for (int i = 0; i < 50; i++)
            tasks[i] = "";
        tasks[0] = "Не делай плохо";
        tasks[1] = "Делай хорошо";
        task_count = 2;
        ShowTaskText();
    }
    void Update()
    {
        
    }
}
