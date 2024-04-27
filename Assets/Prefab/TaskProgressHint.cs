using TMPro;
using UnityEngine;

public class TaskProgressHint: MonoBehaviour {
    public ProgressBar progressBar;
    public TMP_Text taskName;
    public void SetTask (string name, float progress) {
        taskName.text = name;
        progressBar.progress = progress;
    }

    public void UpdateProgress (float progress) {
        progressBar.progress = progress;
    }

    public void SetPosition (Transform anchor, BoxCollider collider) {
        var position = GameplayController.ProjectTopPoint(anchor, collider);
        position.y += 10;

        transform.localPosition = position;
    }
}
