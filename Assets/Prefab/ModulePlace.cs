using UnityEngine;

public enum ModulePlaceType {
    None, Eniac
}

public class ModulePlace: ContextedBehaviour {
    public GameObject highlightObject;
    public GameObject eniac;

    private ModulePlaceType _type = ModulePlaceType.None; 
    public ModulePlaceType Type {
        get { return _type; }
        set {
            wallMeshRenderer.enabled = meshRenderer.enabled = value == ModulePlaceType.None;
            eniac.SetActive(value == ModulePlaceType.Eniac);
            _type = value;
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

        InitContexted();
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
