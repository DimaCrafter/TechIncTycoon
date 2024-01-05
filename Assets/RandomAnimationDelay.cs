using System.Collections;
using UnityEngine;

public class RandomAnimationDelay: MonoBehaviour {
    public float min = 0f;
    public float max = 0.5f;

    private Animator animator;
    IEnumerator Start () {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        yield return new WaitForSeconds(Random.Range(min, max));
        animator.enabled = true;
        //animator.playbackTime += Random.Range(min, max);
        //animator.SetFloat("Delay", Random.Range(min, max));
    }
}
