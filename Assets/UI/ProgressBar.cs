using UnityEngine;

public class ProgressBar: MonoBehaviour {
    public RectTransform indicator;

    private float _progress = 0;
    public float progress {
        get { return _progress; }
        set {
            _progress = value;

            var parent = (RectTransform) indicator.parent;
            indicator.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, parent.rect.width * value);
        }
    }
}
