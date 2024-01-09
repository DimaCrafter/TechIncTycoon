using UnityEngine;
using UnityEngine.UI;

public class boolean_btn: MonoBehaviour {
    public uint x, y;
    public Generate_buttons generator;
    public void OnPress () {
        generator.buttons[x, y] = !generator.buttons[x, y];
        GetComponent<Image>().color = new Color(1, 1, 1, generator.buttons[x, y] ? 1 : 0);
        generator.ParseMatrix();
    }
}
