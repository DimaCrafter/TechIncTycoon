using System;
using UnityEngine;

public class SwitchLine: MonoBehaviour {
    public struct State: IEquatable<State> {
        public char input;
        public char op;
        public char varArg;
        public int numArg;
        public char output;

        public bool Equals (State other) {
            if (other.input != input || other.op != op || other.output != output || other.varArg != varArg) {
                return false;
            }

            // Ќестрогое соответствие, если справа вместо числа выбрана переменна€
            if (varArg == 'N' && other.numArg != numArg) {
                return false;
            }

            return true;
        }

        public override string ToString () {
            return $"{input} {op} {varArg}{numArg} = {output}";
        }
    }

    public SwitchBlock varIn;
    public SwitchBlock op;
    public SwitchBlock varArg;
    public SwitchBlock numArg;
    public SwitchBlock varOut;
    public State state = new() {
        input = 'A',
        op = '+',
        varArg = 'A',
        numArg = 1,
        output = 'A'
    };

    public Action OnStateChange = () => {};
    void Start () {
        varIn.OnStateChange += inState => {
            state.input = (char) inState;
            OnStateChange();
        };

        op.OnStateChange += opState => {
            state.op = (char) opState;
            OnStateChange();
        };

        varArg.OnStateChange += varArgState => {
            state.varArg = (char) varArgState;
            OnStateChange();
        };

        numArg.OnStateChange += varNumState => {
            state.numArg = (int) varNumState;
            OnStateChange();
        };

        varOut.OnStateChange += outState => {
            state.output = (char) outState;
            OnStateChange();
        };
    }
}
