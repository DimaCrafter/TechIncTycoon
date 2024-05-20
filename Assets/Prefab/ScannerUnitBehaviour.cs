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
    private UnitTaskEvent taskEvent;
    private int taskEventIndex;

    private Outline outline;
    private new BoxCollider collider;

    void Start () {
        outline = GetComponent<Outline>();
        collider = GetComponent<BoxCollider>();
    }

    public void SetTask (UnitTask newTask) {
        if (newTask.requiredResearchScore > GameplayController.instance.researchScoreBulb.value) {
            return;
        } else {
            GameplayController.instance.DecrementResearchScore(newTask.requiredResearchScore);
        }

        if (newTask.requiredScienceScore > GameplayController.instance.scienceScoreBulb.value) {
            return;
        } else {
            GameplayController.instance.DecrementScienceScore(newTask.requiredScienceScore);
        }

        task = newTask;
        taskRemain = task.duration;
        taskEventIndex = 0;
        taskEvent = task.events[0];

        Scenario.Fire(Scenario.Trigger.ResearchTaskStart);
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
            taskRemain -= Time.deltaTime * GameplayController.instance.ScannerSpeed;

            if (taskEvent != null) {
                var time = Mathf.FloorToInt(task.duration - taskRemain);
                if (taskEvent.time == time) {
                    if (taskEvent.research != 0) {
                        GameplayController.instance.IncrementResearchScore(gameObject, taskEvent.research);
                    }

                    if (taskEvent.science != 0) {
                        GameplayController.instance.IncrementScienceScore(gameObject, taskEvent.science);
                    }

                    if (taskEvent.trigger != Scenario.Trigger.None) {
                        Scenario.Fire(taskEvent.trigger);
                    }

                    if (++taskEventIndex == task.events.Length) {
                        taskEvent = null;
                    } else {
                        taskEvent = task.events[taskEventIndex];
                    }
                }
            }
        } else {
            task = null;
            ResearchModal.availTaskIndex++;

            if (taskHint != null) {
                Destroy(taskHint.gameObject);
                taskHint = null;
            }
        }

        if (taskHint != null) {
            taskHint.SetPosition(transform, collider);
            taskHint.UpdateProgress(1 - taskRemain / task.duration);
        }
    }
}
