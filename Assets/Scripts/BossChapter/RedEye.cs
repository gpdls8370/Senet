using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEye : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public GameObject RedZone;
    [SerializeField] private Sprite CloseImage;

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
        if (animator.isActiveAndEnabled)
        {
            animator.SetTrigger("CloseEye");
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().sprite = CloseImage;
        }
        Invoke("RedZoneOff", 0.5f);
    }

    private void RedZoneOff()
    {
        RedZone.SetActive(false);
    }
}
