using System;
using UnityEngine;

public class SwitchBlock: MonoBehaviour {
    public Transform handleTransform;
    public Action<object> OnStateChange = _ => {};
}
