using UnityEngine;

public class SwitchGameController: MonoBehaviour {
    public SwitchLine[] lines;
    public SwitchGameEq[] equations;
    public SwitchLine.State[] requiredStates = new SwitchLine.State[] {
        new() {
            input = 'A',
            op = '*',
            varArg = 'B',
            numArg = 0,
            output = 'E'
        },
        new() {
            input = 'A',
            op = '+',
            varArg = 'N',
            numArg = 1,
            output = 'C'
        },
        new() {
            input = 'B',
            op = '-',
            varArg = 'N',
            numArg = 4,
            output = 'D'
        }
    };

    void Start () {
        foreach (var line in lines) {
            line.OnStateChange += () => OnStateUpdate();
        }
    }

    void OnStateUpdate () {
        for (var i = 0; i < requiredStates.Length; i++) {
            var correct = false;
            foreach (var line in lines) {
                if (line.state.Equals(requiredStates[i])) {
                    correct = true;
                    break;
                }
            }

            equations[i].ToggleCorrect(correct);
        }
    }
}
