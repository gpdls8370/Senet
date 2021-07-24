using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepCycle : MonoBehaviour
{
    public float SleepTime;
    public float AwakeTime;
    public GameObject PatrolObject;

    private HideSkill _hideSkill;
    public bool isAwake;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        _hideSkill = PatrolObject.GetComponent<HideSkill>();
        StartCoroutine("SleepTimeCoroutine");
    }

    private IEnumerator SleepTimeCoroutine()
    {
        isAwake = false;
        animator.SetBool("Sleep", true);
        animator.SetBool("Awake", false);

        yield return new WaitForSeconds(SleepTime);
        StartCoroutine("AwakeTimeCoroutine");
    }

    private IEnumerator AwakeTimeCoroutine()
    {
        isAwake = true;
        animator.SetBool("Sleep", false);
        animator.SetBool("Awake", true);

        yield return new WaitForSeconds(AwakeTime);
        StartCoroutine("SleepTimeCoroutine");
    }
}
