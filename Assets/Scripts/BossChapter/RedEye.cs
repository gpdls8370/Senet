using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEye : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject RedZone;

    public void StartAttack()
    {
        animator.SetTrigger("OpenEye");
        Invoke("RedZoneOn", 0.5f);
    }

    private void RedZoneOn()
    {
        RedZone.SetActive(true);
    }

    public void StopAttack()
    {
        animator.SetTrigger("CloseEye");
        Invoke("RedZoneOff", 0.5f);
    }

    private void RedZoneOff()
    {
        RedZone.SetActive(false);
    }
}
