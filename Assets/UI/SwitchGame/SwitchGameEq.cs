using UnityEngine;

public class SwitchGameEq: MonoBehaviour {
    public GameObject correctImg;
    public GameObject incorrectImg;
    public void ToggleCorrect (bool value) {
        correctImg.SetActive(value);
        incorrectImg.SetActive(!value);
    }
}
