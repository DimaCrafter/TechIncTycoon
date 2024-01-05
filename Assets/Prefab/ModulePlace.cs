using UnityEngine;

public enum ModulePlaceType {
    None, Eniac
}

public class ModulePlace: MonoBehaviour {
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

    private MeshRenderer meshRenderer;
    public MeshRenderer wallMeshRenderer;

    void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        highlightObject.SetActive(false);
        Type = Type;
    }

    void OnMouseEnter () {
        if (_type == ModulePlaceType.None) {
            highlightObject.SetActive(true);
        }
    }

    void OnMouseExit () {
        if (_type == ModulePlaceType.None) {
            highlightObject.SetActive(false);
        }
    }
}
