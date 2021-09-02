using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeEnemy : MonoBehaviour
{
    [SerializeField] private HideZone LeftZone;
    [SerializeField] private HideZone RightZone;
    [SerializeField] private float ChangeTime;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        StartCoroutine(ChangeCoroutine());
    }

    private IEnumerator ChangeCoroutine()
    {
        LeftZone.mustDetected = true;
        RightZone.mustDetected = false;
        animator.SetTrigger("Left");

        yield return new WaitForSeconds(ChangeTime);

        LeftZone.mustDetected = false;
        RightZone.mustDetected = true;
        animator.SetTrigger("Right");

        yield return new WaitForSeconds(ChangeTime);

        StartCoroutine(ChangeCoroutine());
    }

}
