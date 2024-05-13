using System;
using UnityEngine;

public class ScannerPlace: ContextedBehaviour<ScannerPlace> {
    public GameObject scanner;
    public MeshRenderer placeIndicator;
    public Material indicatorMaterial;
    public Material indicatorHighlightMaterial;

    private bool _used = false;
    public bool Used {
        get { return _used; }
        set {
            _used = value;
            placeIndicator.enabled = !value;
            scanner.SetActive(value);
            
            if (GameplayController.instance == null) return;

            var i = Array.IndexOf(GameplayController.instance.scannerPlaces, this);
            Scenario.gameState.scannerPlace[i] = value;
        }
    }

    void Start () {
    }

    public GameObject placeMenu;
    //public GameObject scannerMenu;
    protected override GameObject GetMenuPrefab () {
        return placeMenu;
    }

    protected override void OnHover (bool isOver) {
        if (_used) {
        } else {
            placeIndicator.material = isOver ? indicatorHighlightMaterial : indicatorMaterial;
        }
    }
}
