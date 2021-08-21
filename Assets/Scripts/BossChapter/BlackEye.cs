using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEye : HideDetect
{
    public float InvincibleDelay = 0.5f;

    protected override void Start()
    {
        base.Start();
        DeadAfterDetected = false;
    }

    public override void Detected()
    {
        base.Detected();

        PlayerManager.Instance.LoseLife(1);
        StartCoroutine(HideInvincibleTime());

        Debug.Log(PlayerManager.Instance.NowLife);
    }

    private IEnumerator HideInvincibleTime()
    {
        PlayerManager.Instance.isInvincibleInHide = true;

        yield return new WaitForSeconds(InvincibleDelay);

        PlayerManager.Instance.isInvincibleInHide = false;
    }
}
