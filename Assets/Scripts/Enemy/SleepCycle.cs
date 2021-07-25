using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepCycle : MonoBehaviour
{
    public GameObject PatrolObject;
    public float SleepTime;
    public float AwakeTime;

    public GameObject DetectedIcon;

    [HideInInspector]
    public bool isAwake;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        StartCoroutine("SleepTimeCoroutine");
    }

    private IEnumerator SleepTimeCoroutine()
    {
        SetSleep();
        
        yield return new WaitForSeconds(SleepTime);
        StartCoroutine("AwakeTimeCoroutine");
    }

    private IEnumerator AwakeTimeCoroutine()
    {
        SetAwake();

        yield return new WaitForSeconds(AwakeTime);
        StartCoroutine("SleepTimeCoroutine");
    }

    public void SetSleep()
    {
        isAwake = false;
        animator.SetBool("Sleep", true);
        animator.SetBool("Awake", false);
    }

    public void SetAwake()
    {
        isAwake = true;
        animator.SetBool("Sleep", false);
        animator.SetBool("Awake", true);
    }
}
