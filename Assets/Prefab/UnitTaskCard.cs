using TMPro;
using UnityEngine;

public class UnitTaskCard: MonoBehaviour {
    public UnitTask task;

    public TMP_Text titleText;
    public TMP_Text inResearchScoreText;
    public TMP_Text inScienceScoreText;
    public TMP_Text outResearchScoreText;
    public TMP_Text outScienceScoreText;

    void Start () {
        titleText.text = task.title;
        inResearchScoreText.text = task.requiredResearchScore.ToString();
        inScienceScoreText.text = task.requiredScienceScore.ToString();
        outResearchScoreText.text = task.outResearchScore.ToString();
        outScienceScoreText.text = task.outScienceScore.ToString();
    }
}
