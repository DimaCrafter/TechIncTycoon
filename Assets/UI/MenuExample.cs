using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuExample: MonoBehaviour {
    public Button counterBtn;
    // Start is called before the first frame update
    void Start () {
        counterBtn.onClick.AddListener(OnCounterClick);
    }

    void OnCounterClick () {
        var textMesh = counterBtn.GetComponentInChildren<TextMeshProUGUI>();
        textMesh.text = (int.Parse(textMesh.text) + 1).ToString();
    }

    // Update is called once per frame
    void Update () {
        
    }
}
