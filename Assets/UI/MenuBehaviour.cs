using UnityEngine;
using UnityEngine.EventSystems;

public class MenuBehaviour<T>: MonoBehaviour, IDeselectHandler where T: ContextedBehaviour<T> {
    public T parent { get; set; }

    void Awake () {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void OnDeselect (BaseEventData e) {
        var pe = (PointerEventData) e;
        if (pe.hovered.Contains(gameObject)) {
            e.Reset();
        } else {
            parent.Reset();
        }
    }
}
