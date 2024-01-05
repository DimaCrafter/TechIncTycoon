using UnityEngine;

public class ScannerUnitBehaviour: MonoBehaviour {
    public GameObject menuPrefab;

    private Transform canvas;
    private GameObject menuObject;
    private Outline outline;
    private new Collider collider;
    private GameplayController gameplay;

    void Start () {
        outline = GetComponent<Outline>();
        collider = GetComponent<Collider>();
        canvas = GameObject.Find("Canvas").transform;
        gameplay = canvas.GetComponent<GameplayController>();
    }

    private bool _clickedOnMe = false;
    void OnMouseDown () {
        gameplay.IncrementScienceScore(gameObject, 2);
        _clickedOnMe = true;

        menuObject = Instantiate(menuPrefab, canvas);
        menuObject.transform.position = Input.mousePosition;
        outline.enabled = true;
        collider.enabled = false;
    }

    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            if (!_clickedOnMe && menuObject != null) {
                Reset();
            }
        }

        _clickedOnMe = false;
    }

    public void Reset () {
        Destroy(menuObject);
        menuObject = null;
        outline.enabled = false;
        collider.enabled = true;
    }

    void OnMouseOver () {
        if (menuObject != null) return;
        outline.enabled = true;
    }

    void OnMouseExit () {
        if (menuObject != null) return;
        outline.enabled = false;
    }
}
