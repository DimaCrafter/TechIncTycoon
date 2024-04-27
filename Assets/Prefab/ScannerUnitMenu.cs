using UnityEngine;

public class ScannerUnitMenu: MenuBehaviour<ScannerUnitBehaviour> {
    public GameObject researchModalPrefab;
    public void OnResearchClick () {
        var modal = Modal.Open<ResearchModal>(researchModalPrefab);
        modal.unit = parent;

        parent.Reset();
    }

    public void OnAssembleClick () {
        parent.Reset();
    }
}
