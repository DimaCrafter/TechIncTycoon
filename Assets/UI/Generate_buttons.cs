using TMPro;
using UnityEngine;

public class Generate_buttons: MonoBehaviour {
    public GameObject referenceBtn;
    public GameObject parentBtn;
    private const int COLS = 40;
    private const int ROWS = 12;
    public bool[,] buttons = new bool[COLS, ROWS];
    private bool btn_state = false;
    private static string[] tasks = new string[] {
        "123",
        "ABC",
        "1A2B3C",
        "HELLO",
        "PUNCH"
    };

    public TMP_Text task_text;
    private string cur_task;
    void Start () {
        cur_task = tasks[Random.Range(0, tasks.Length)];
        task_text.text = cur_task;
        if (btn_state == true) {
            for (int i = 0; i < COLS; i++) {
                for (int j = 0; j < ROWS; j++) {
                    buttons[i, j] = false;
                }
            }
        } else {
            for (uint j = 0; j < ROWS; j++) {
                for (uint i = 0; i < COLS; i++) {
                    GameObject newBtn = Instantiate(referenceBtn, parentBtn.transform);
                    var button = newBtn.GetComponent<boolean_btn>();
                    button.x = i;
                    button.y = j;
                    button.generator = this;
                }
            }
        }
        btn_state = true;
    }
    public TMP_Text tmp;
    public void ParseMatrix () {
        string text = "";
        tmp.text = text;
        for (int i = 0; i < COLS; i++) {
            string symbol = "";
            bool[] _case = new bool[4];
            bool break_point = false;
            for (int j = 0; j < ROWS; j++) {
                if (buttons[i, j] == true && j == 0 && !_case[0] && !_case[1] && !_case[2] && !_case[3]) {
                    _case[0] = true;
                } else if (buttons[i, j] == true && j == 1 && !_case[0] && !_case[1] && !_case[2] && !_case[3]) {
                    _case[1] = true;
                } else if (buttons[i, j] == true && j == 2 && !_case[0] && !_case[1] && !_case[2] && !_case[3]) {
                    _case[2] = true;
                } else if (buttons[i, j] == true && j > 2 && !_case[0] && !_case[1] && !_case[2] && !_case[3]) {
                    _case[3] = true;
                }
                if (_case[0] == true && !break_point && buttons[i, j] == true) {
                    switch (j) {
                        case 3:
                            symbol = "A";
                            break_point = true;
                            break;
                        case 4:
                            symbol = "B";
                            break_point = true;
                            break;
                        case 5:
                            symbol = "C";
                            break_point = true;
                            break;
                        case 6:
                            symbol = "D";
                            break_point = true;
                            break;
                        case 7:
                            symbol = "E";
                            break_point = true;
                            break;
                        case 8:
                            symbol = "F";
                            break_point = true;
                            break;
                        case 9:
                            symbol = "G";
                            break_point = true;
                            break;
                        case 10:
                            symbol = "H";
                            break_point = true;
                            break;
                        case 11:
                            symbol = "I";
                            break_point = true;
                            break;
                    }
                } else if (_case[1] == true && !break_point && buttons[i, j] == true) {
                    switch (j) {
                        case 3:
                            symbol = "J";
                            break_point = true;
                            break;
                        case 4:
                            symbol = "K";
                            break_point = true;
                            break;
                        case 5:
                            symbol = "L";
                            break_point = true;
                            break;
                        case 6:
                            symbol = "M";
                            break_point = true;
                            break;
                        case 7:
                            symbol = "N";
                            break_point = true;
                            break;
                        case 8:
                            symbol = "O";
                            break_point = true;
                            break;
                        case 9:
                            symbol = "P";
                            break_point = true;
                            break;
                        case 10:
                            symbol = "Q";
                            break_point = true;
                            break;
                        case 11:
                            symbol = "R";
                            break_point = true;
                            break;
                    }
                } else if (_case[2] == true && !break_point && buttons[i, j] == true) {
                    switch (j) {
                        case 3:
                            symbol = "S";
                            break_point = true;
                            break;
                        case 4:
                            symbol = "T";
                            break_point = true;
                            break;
                        case 5:
                            symbol = "U";
                            break_point = true;
                            break;
                        case 6:
                            symbol = "V";
                            break_point = true;
                            break;
                        case 7:
                            symbol = "W";
                            break_point = true;
                            break;
                        case 8:
                            symbol = "X";
                            break_point = true;
                            break;
                        case 9:
                            symbol = "Y";
                            break_point = true;
                            break;
                        case 10:
                            symbol = "Z";
                            break_point = true;
                            break;
                        case 11:
                            symbol = "Ð";
                            break_point = true;
                            break;
                    }
                } else if (_case[3] == true && !break_point && buttons[i, j] == true) {
                    if (buttons[i, j] == true)
                        symbol += (j - 2).ToString();
                }
            }
            text += symbol;
        }
        tmp.text = text;
        if (text == cur_task) {
            task_text.text = "Done";
            GetComponent<Modal>().Close();
        }
    }
}
