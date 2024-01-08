using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchOpBlock: SwitchBlock, IPointerClickHandler {
    private int state = 0;
    private readonly char[] states = new char[] { '+', '-', '*', '/' };
    private bool forwardSwitch = true;

    public void OnPointerClick (PointerEventData e) {
        if (e.button != PointerEventData.InputButton.Left) {
            return;
        }

        if (state == states.Length - 1) {
            forwardSwitch = false;
            state--;
        } else if (state == 0) {
            forwardSwitch = true;
            state++;
        } else if (forwardSwitch) {
            state++;
        } else {
            state--;
        }

        handleTransform.rotation = Quaternion.Euler(0, 0, -15.25f - 30.5f * state);
        OnStateChange(states[state]);
    }
}
