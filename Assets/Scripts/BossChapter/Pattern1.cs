using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1 : PatternBase
{
    [Header("패턴1: 검은 눈 회색 눈")]
    public float DamageStartDelay;
    public GameObject BlackEye;
    public GameObject GrayEye;

    private void Update()
    {
        transform.position = BossStateManager.Instance.Boss.transform.position;       
    }

    public override void StartPattern()
    {
        transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360));

        float a = Random.Range(-1, 1);
        if (a < 0) { a = -1; }
        else { a = 1; }

        transform.localScale = new Vector3(1, a, 1);

        BlackEye.SetActive(true);
        GrayEye.SetActive(true);

        StartCoroutine(DamageStartDelayCoroutine());
    }

    public override void StopPattern()
    {
        base.StopPattern();

        BlackEye.SetActive(false);
        GrayEye.SetActive(false);
    }

    private IEnumerator DamageStartDelayCoroutine()
    {
        PlayerManager.Instance.isInvincibleInHide = true;

        yield return new WaitForSeconds(DamageStartDelay);

        PlayerManager.Instance.isInvincibleInHide = false;
    }
}
