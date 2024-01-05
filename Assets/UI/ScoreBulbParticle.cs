using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBulbParticle: MonoBehaviour {
    public TMP_Text textObject;

    [HideInInspector]
    public Vector3 source;
    [HideInInspector]
    public ScoreBulb target;

    private int score;
    public void SetScore (int value) {
        score = value;
        textObject.text = value.ToString();
    }

    private Image background;
    void Start () {
        transform.localPosition = source;
        background = GetComponent<Image>();
    }

    private const float DESTROY_DISTANCE = 40f;
    private const float FADE_DISTANCE = 15f;
    void Update () {
        var distance = (transform.position - target.transform.position).magnitude;

        if (distance < DESTROY_DISTANCE) {
            target.Increment(score);
            Destroy(gameObject);
            return;
        }
        
        if (distance < DESTROY_DISTANCE + FADE_DISTANCE) {
            var opacity = (distance - DESTROY_DISTANCE) / FADE_DISTANCE;
            background.color = new Color(background.color.r, background.color.g, background.color.b, opacity);
            textObject.color = new Color(1f, 1f, 1f, opacity);
        }

        transform.position = Vector3.Lerp(transform.position, target.transform.position, 0.075f);
    }
}
