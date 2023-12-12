using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Generate_buttons : MonoBehaviour
{
    public GameObject referenceBtn;
    public GameObject parentBtn;
    public bool[,] buttons = new bool[80, 12];
    public string text = "";
    public TMP_Text tmp;
    public void GenerateBtn()
    {
        for (uint j = 0; j < 12; j++)
        {
            for (uint i = 0; i < 80; i++)
            {
                GameObject newBtn = Instantiate(referenceBtn, parentBtn.transform);
                var button = newBtn.GetComponent<boolean_btn>();
                button.x = i;
                button.y = j;
                button.generator = this;
            }
        }
    }
    public void ParseMatrix()
    {
        for(int i = 0; i < 80; i++)
        {
            for(int j = 0; j < 12; j++)
            {
                if (buttons[i, j] == true && j > 1)
                    text += (j - 2).ToString();
            }
        }
        tmp.text = text;
    }
}
