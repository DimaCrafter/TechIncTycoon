using System;
using UnityEngine;

public enum ModulePlaceType {
    None, Eniac
}

public class ModulePlace: ContextedBehaviour<ModulePlace> {
    public GameObject highlightObject;
    public GameObject eniac;

    private ModulePlaceType _type = ModulePlaceType.None;

    public ModulePlaceType Type {
        get { return _type; }
        set {
            _type = value;
            // Компонент не инициализирован
            if (meshRenderer == null) {
                return;
            }

            wallMeshRenderer.enabled = meshRenderer.enabled = value == ModulePlaceType.None;
            eniac.SetActive(value == ModulePlaceType.Eniac);

            if (GameplayController.instance == null) return;

            var i = Array.IndexOf(GameplayController.instance.modulePlaces, this);
            Scenario.gameState.modulePlaceTypes[i] = value;
        }
    }

    private Outline outline;
    private MeshRenderer meshRenderer;
    public MeshRenderer wallMeshRenderer;

    void Start () {
        outline = GetComponent<Outline>();
        meshRenderer = GetComponent<MeshRenderer>();
        highlightObject.SetActive(false);
        Type = Type;
    }

    public GameObject controlMenu;
    public GameObject assembleMenu;
    protected override GameObject GetMenuPrefab () {
        return _type == ModulePlaceType.None ? assembleMenu : controlMenu;
    }

    protected override void OnHover (bool isOver) {
        if (_type == ModulePlaceType.None) {
            highlightObject.SetActive(isOver);
        } else {
            outline.enabled = isOver;
        }
    }
}
