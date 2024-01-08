using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchNumBlock: SwitchBlock, IPointerClickHandler {
    private int state = 1;
    private bool forwardSwitch = false;

    public void OnPointerClick (PointerEventData e) {
        if (e.button != PointerEventData.InputButton.Left) {
            return;
        }

        if (state == 9) {
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

        handleTransform.rotation = Quaternion.Euler(0, 0, -15.25f * (state - 1));
        OnStateChange(state);
    }
}
