using UnityEngine;

public class ScannerUnitBehaviour: ContextedBehaviour<ScannerUnitBehaviour> {
    public GameObject menuPrefab;
    protected override GameObject GetMenuPrefab () {
        if (task == null) {
            return menuPrefab;
        } else {
            return null;
        }
    }

    public GameObject taskHintPrefab;
    private TaskProgressHint taskHint;
    private UnitTask task;
    private float taskRemain;

    private Outline outline;
    private new BoxCollider collider;

    void Start () {
        outline = GetComponent<Outline>();
        collider = GetComponent<BoxCollider>();
    }

    public void SetTask (UnitTask newTask) {
        task = newTask;
        taskRemain = task.duration;
    }

    protected override void OnHover (bool isOver) {
        outline.enabled = isOver;

        if (isOver) {
            if (taskHint == null && task != null) {
                var taskHintObject = Instantiate(taskHintPrefab, GameplayController.canvasRect);

                taskHint = taskHintObject.GetComponent<TaskProgressHint>();
                taskHint.SetPosition(transform, collider);
                taskHint.SetTask(task.title, 1 - taskRemain / task.duration);
            }
        } else {
            if (taskHint != null) {
                Destroy (taskHint.gameObject);
                taskHint = null;
            }
        }
    }

    void Update () {
        if (task != null) {
            UpdateTaskStatus();
        }
    }

    private void UpdateTaskStatus () {
        if (taskRemain > 0) {
            taskRemain -= Time.deltaTime;
            /*if (Mathf.Floor(taskRemain) % 2 == 0) {
                GameplayController.instance.IncrementScienceScore(gameObject, 1);
            }*/
        } else {
            task = null;
            if (taskHint != null) {
                Destroy(taskHint.gameObject);
                taskHint = null;
            }

            Debug.Log("Task done!");
            Scenario.Fire(Scenario.Trigger.ResearchTaskStart);
        }

        if (taskHint != null) {
            taskHint.SetPosition(transform, collider);
            taskHint.UpdateProgress(1 - taskRemain / task.duration);
        }
    }
}
