using UnityEngine;

public class ScannerUnitBehaviour: ContextedBehaviour<ScannerUnitBehaviour> {
    public GameObject menuPrefab;
    private Outline outline;

    void Start () {
        outline = GetComponent<Outline>();
    }

    protected override void OnHover (bool isOver) {
        outline.enabled = isOver;
    }

    protected override GameObject GetMenuPrefab () {
        return menuPrefab;
    }
}
