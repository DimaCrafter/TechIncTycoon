using UnityEngine;

public class GameplayController: MonoBehaviour {
    public ScoreBulb researchScoreBulb;
    public GameObject researchScoreParticle;
    public ScoreBulb scienceScoreBulb;
    public GameObject scienceScoreParticle;

    private RectTransform canvasRect;
    void Start () { 
        canvasRect = GetComponent<RectTransform>();
    }

    public void IncrementScienceScore (GameObject source, int delta) {
        var particleObject = Instantiate(scienceScoreParticle, transform);
        var particle = particleObject.GetComponent<ScoreBulbParticle>();

        particle.SetScore(delta);

        var sourcePos = source.transform.position;
        sourcePos.y = source.GetComponent<BoxCollider>().bounds.max.y;

        particle.source = Camera.main.WorldToScreenPoint(sourcePos);
        particle.source.x -= canvasRect.sizeDelta.x / 2;
        particle.source.y -= canvasRect.sizeDelta.y / 2;

        particle.target = scienceScoreBulb;
    }
}
