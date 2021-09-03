using System.Collections;
using UnityEngine;

public class SleepCycle : MonoBehaviour
{
    public float SleepTime;
    public float AwakeTime;

    public bool itCanAwake;

    public GameObject SleepingIcon;

    public bool isAwake;

    private Animator animator;


    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (itCanAwake)
        {
            StartCoroutine("SleepTimeCoroutine");
        }
        else
        {
            SetSleep();
        }  
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
        SleepingIcon.SetActive(true);
        animator.SetBool("Sleep", true);
        animator.SetBool("Awake", false);
    }

    public void SetAwake()
    {
        isAwake = true;
        SleepingIcon.SetActive(false);
        animator.SetBool("Sleep", false);
        animator.SetBool("Awake", true);
    }
}
