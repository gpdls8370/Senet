using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEye : HideDetect
{
    [SerializeField] private float InvincibleDelay = 0.5f;
 
    [Header("BlackEye")]
    public GameObject HideZone;
    [SerializeField] private Animator animator;
    [SerializeField] private Sprite CloseImage;

    protected override void Start()
    {
        base.Start();
        DeadAfterDetected = false;
    }

    public void StartAttack()
    {
        animator.SetTrigger("OpenEye");
        Invoke("HideZoneOn", 0.5f);
    }

    private void HideZoneOn()
    {
        HideZone.SetActive(true);
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
        Invoke("HideZoneOff", 0.5f);
    }

    private void HideZoneOff()
    {
        HideZone.SetActive(false);
    }

    public override void Detected()
    {
        base.Detected();

        PlayerManager.Instance.LoseLife(1);
        StartCoroutine(HideInvincibleTime());
    }

    private IEnumerator HideInvincibleTime()
    {
        PlayerManager.Instance.isInvincibleInHide = true;

        yield return new WaitForSeconds(InvincibleDelay);

        PlayerManager.Instance.isInvincibleInHide = false;
    }
}
