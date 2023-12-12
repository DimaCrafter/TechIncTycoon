using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boolean_btn : MonoBehaviour
{
    public uint x, y;
    public Generate_buttons generator;
    public void OnPress()
    {
        generator.buttons[x, y] = !generator.buttons[x, y];
    }
}
