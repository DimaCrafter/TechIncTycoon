using UnityEngine;

public class GameplayController: MonoBehaviour {
    public ScoreBulb researchScoreBulb;
    public GameObject researchScoreParticle;
    public ScoreBulb scienceScoreBulb;
    public GameObject scienceScoreParticle;
    public ModulePlace[] modulePlaces;
    public DialogController dialog;
    public GameObject defaultScoreSource;

    public static RectTransform canvasRect { get; private set; }
    public static GameplayController instance { get; private set; }
    void Start () {
        instance = this;
        canvasRect = GetComponent<RectTransform>();
        RestoreProgress();
        Scenario.Play();
    }

    void RestoreProgress () {
        for (var i = 0; i < modulePlaces.Length; i++) {
            modulePlaces[i].Type = Scenario.gameState.modulePlaceTypes[i];
        }
    }

    public void IncrementScienceScore (GameObject source, int delta) {
        if (source == null) {
            source = defaultScoreSource;
        }

        var particleObject = Instantiate(scienceScoreParticle, transform);
        var particle = particleObject.GetComponent<ScoreBulbParticle>();

        particle.SetScore(delta);
        particle.source = ProjectTopPoint(source.transform, source.GetComponent<BoxCollider>());
        particle.target = scienceScoreBulb;
    }

    public static Vector3 ProjectTopPoint (Transform anchor, BoxCollider collider) {
        var anchorPos = anchor.position;
        anchorPos.y = collider.bounds.max.y;

        var projected = Camera.main.WorldToScreenPoint(anchorPos);
        projected.x -= canvasRect.sizeDelta.x / 2;
        projected.y -= canvasRect.sizeDelta.y / 2;
        return projected;
    }
}
