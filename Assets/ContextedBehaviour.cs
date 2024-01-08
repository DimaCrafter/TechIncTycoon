using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ContextedBehaviour: MonoBehaviour, IPointerClickHandler {
    public Collider contextMenuTrigger;
    protected Transform canvas;
    protected GameObject menuObject;

    protected void InitContexted () {
        contextMenuTrigger = GetComponent<Collider>();
        canvas = GameObject.Find("Canvas").transform;
    }

    protected virtual void OnHover (bool isOver) {}
    protected abstract GameObject GetMenuPrefab ();

    private bool _clickedOnMe = false;
    public void OnPointerClick (PointerEventData e) {
        if (e.button != PointerEventData.InputButton.Left) {
            return;
        }

        _clickedOnMe = true;

        menuObject = Instantiate(GetMenuPrefab(), canvas);
        menuObject.transform.position = Input.mousePosition;
        contextMenuTrigger.enabled = false;

        OnHover(true);
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
        contextMenuTrigger.enabled = true;

        OnHover(false);
    }

    void OnMouseOver () {
        if (menuObject != null) return;
        OnHover(true);
    }

    void OnMouseExit () {
        if (menuObject != null) return;
        OnHover(false);
    }
}
