using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEye : HideDetect
{
    [SerializeField] private float InvincibleDelay = 0.5f;
    [SerializeField] private GameObject HideZone;
    [SerializeField] private Animator animator;

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
