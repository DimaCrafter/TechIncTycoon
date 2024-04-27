using System;
using UnityEngine;

public class Modal: MonoBehaviour {
    public static T Open<T> (GameObject prefab) where T: Modal {
        var modalObject = Instantiate(prefab, GameplayController.canvasRect);
        var modal = modalObject.GetComponent<T>();
        return modal;
    }

    public Action onClose = () => {};
    public void Close () {
        onClose();
        Destroy(gameObject);
    }
}
