using UnityEngine;

public class GameplayController: MonoBehaviour {
    public ScoreBulb researchScoreBulb;
    public GameObject researchScoreParticle;
    public ScoreBulb scienceScoreBulb;
    public GameObject scienceScoreParticle;
    public ModulePlace[] modulePlaces;
    public ScannerPlace[] scannerPlaces;
    public DialogController dialog;
    public GameObject defaultScoreSource;

    public GameObject[] modalPrefabs;

    public static RectTransform canvasRect { get; private set; }
    public static GameplayController instance { get; private set; }
    void Start () {
        instance = this;
        canvasRect = GetComponent<RectTransform>();
        RestoreProgress();
        Scenario.Play();
    }

    void Update () {
        if (Time.timeScale != 0) {
            Time.timeScale = Input.GetKey(KeyCode.F7) ? 8 : (Input.GetKey(KeyCode.F6) ? 0.01f : 1);
        }
    }

    void RestoreProgress () {
        for (var i = 0; i < modulePlaces.Length; i++) {
            modulePlaces[i].Type = Scenario.gameState.modulePlaceTypes[i];
        }

        for (var i = 0; i < scannerPlaces.Length; i++) {
            scannerPlaces[i].Used = Scenario.gameState.scannerPlace[i];
        }
    }

    public int ComputationPower {
        get {
            var total = 0;
            for (var i = 0; i < modulePlaces.Length; i++) {
                switch (modulePlaces[i].Type) {
                    case ModulePlaceType.Eniac:
                        total += 1;
                        break;
                }
            }

            return total;
        }
    }

    public float ScannerSpeed {
        get { return Mathf.Sqrt(ComputationPower); }
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

    public void IncrementResearchScore (GameObject source, int delta) {
        if (source == null) {
            source = defaultScoreSource;
        }

        var particleObject = Instantiate(researchScoreParticle, transform);
        var particle = particleObject.GetComponent<ScoreBulbParticle>();

        particle.SetScore(delta);
        particle.source = ProjectTopPoint(source.transform, source.GetComponent<BoxCollider>());
        particle.target = researchScoreBulb;
    }

    public void DecrementScienceScore (int delta) {
        scienceScoreBulb.Increment(-delta);
    }

    public void DecrementResearchScore (int delta) {
        researchScoreBulb.Increment(-delta);
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
