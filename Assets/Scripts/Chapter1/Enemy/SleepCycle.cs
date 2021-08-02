using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepCycle : MonoBehaviour
{
    public GameObject PatrolObject;
    public float SleepTime;
    public float AwakeTime;

    public GameObject DetectedIcon;
    public GameObject SleepingIcon;

    public Sprite DetectedImage;

    [HideInInspector]
    public bool isAwake;
    public bool isDetected = false;

    private Animator animator;
    private NpcSentence _npcSentence;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        StartCoroutine("SleepTimeCoroutine");
        _npcSentence = GetComponent<NpcSentence>();
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

    public void Detected()
    {
        if (!StateManager.Instance.isDead())
        {
            StateManager.Instance.SetDead();
            isDetected = true;
            SetAwake();
            StopAllCoroutines();
            DetectedIcon.SetActive(true);
            DetectedIcon.GetComponent<SpriteRenderer>().sprite = DetectedImage;
            _npcSentence.TalkNpc();
        }
    }

}
