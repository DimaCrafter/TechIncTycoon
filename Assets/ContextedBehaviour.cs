using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ContextedBehaviour<Self>: MonoBehaviour, IPointerClickHandler where Self: ContextedBehaviour<Self> {
    protected GameObject menuObject;
    protected MenuBehaviour<Self> menu;

    protected virtual void OnHover (bool isOver) {}
    protected abstract GameObject GetMenuPrefab ();

    public void OnPointerClick (PointerEventData e) {
        if (e.button != PointerEventData.InputButton.Left) {
            return;
        }

        if (menuObject != null) {
            return;
        }

        menuObject = Instantiate(GetMenuPrefab(), GameplayController.canvasRect);
        menuObject.transform.position = Input.mousePosition;
        menu = menuObject.GetComponent<MenuBehaviour<Self>>();
        menu.parent = (Self) this;

        OnHover(true);
    }

    public void Reset () {
        Destroy(menuObject);
        menuObject = null;

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
