using TMPro;
using UnityEngine;

public class ScoreBulb: MonoBehaviour {
    public TMP_Text valueText;
    public TMP_Text mainText;
    public int value = 0;
    void Start () {
    }

    void Update () {
        
    }

    public void Increment (int delta) {
        value += delta;
        valueText.text = value.ToString();
    }
}
