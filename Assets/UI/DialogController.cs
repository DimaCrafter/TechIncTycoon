using System.Collections;
using TMPro;
using UnityEngine;

public class DialogController: MonoBehaviour {
	private string currentText;

    public float printDelay;
	public TMP_Text dialogText;
    
    public void StartDialog (string text) {
		currentText = text;
        gameObject.SetActive(true);
        StartCoroutine(TypeLine());
	}

	IEnumerator TypeLine () {
        dialogText.text = string.Empty;

        foreach (var symbol in currentText) {
			dialogText.text += symbol;
			yield return new WaitForSeconds(printDelay);
		}
	}

	public void OnClick () {
		if (dialogText.text == currentText) {
            gameObject.SetActive(false);
            Scenario.Fire(Scenario.Trigger.DialogClose);
        } else {
			StopAllCoroutines();
			dialogText.text = currentText;
		}
	}
}
