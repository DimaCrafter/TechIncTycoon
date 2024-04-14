using TMPro;
using UnityEngine;

public class UnitTaskCard: MonoBehaviour {
    public ResearchTask task;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI inResearchScoreText;
    public TextMeshProUGUI inScienceScoreText;
    public TextMeshProUGUI outResearchScoreText;
    public TextMeshProUGUI outScienceScoreText;

    void Start () {
        titleText.text = task.title;
        inResearchScoreText.text = task.requiredResearchScore.ToString();
        inScienceScoreText.text = task.requiredScienceScore.ToString();
        outResearchScoreText.text = task.outResearchScore.ToString();
        outScienceScoreText.text = task.outScienceScore.ToString();
    }
}
