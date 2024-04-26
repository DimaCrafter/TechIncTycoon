using System;
using UnityEngine;

public class Modal: MonoBehaviour {
    public static void Open (GameObject prefab) {
        Instantiate(prefab, GameplayController.canvasRect);
    }

    public Action onClose = () => {};
    public void Close () {
        onClose();
        Destroy(gameObject);
    }
}
