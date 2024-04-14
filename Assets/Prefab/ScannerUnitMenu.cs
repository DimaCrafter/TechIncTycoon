using UnityEngine;

public class ScannerUnitMenu: MonoBehaviour, IMenu<ScannerUnitBehaviour> {
    public ScannerUnitBehaviour parent { get; set; }

    public void OnResearchClick () {
        parent.Reset();
    }

    public void OnAssembleClick () {

    }
}
