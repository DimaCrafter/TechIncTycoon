using UnityEngine;

public class ScannerUnitMenu: MenuBehaviour<ScannerUnitBehaviour> {
    public GameObject researchModalPrefab;
    public void OnResearchClick () {
        Modal.Open(researchModalPrefab);
        parent.Reset();
    }

    public void OnAssembleClick () {
        parent.Reset();
    }
}
