using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1 : PatternBase
{
    [Header("패턴1: 검은 눈 회색 눈")]
    [SerializeField] private float DamageStartDelay;
    [SerializeField] private float BlackOpenDelay;
    [SerializeField] private float GrayOpenDelay;

    public GameObject blackEye;
    public GameObject grayEye;

    public override void StartPattern()
    {
        transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360));

        float a = Random.Range(-1, 1);
        if (a < 0) { a = -1; }
        else { a = 1; }

        transform.localScale = new Vector3(1, a, 1);

        SwitchStretch();

        StartCoroutine(PatternCoroutine());
    }

    public override void StopPattern()
    {
        base.StopPattern();

        blackEye.GetComponent<BlackEye>().StopAttack();
        grayEye.GetComponent<GrayEye>().StopAttack();

        blackEye.SetActive(false);
        grayEye.SetActive(false);

        SwitchIdle();
    }

    private IEnumerator PatternCoroutine()
    {
        yield return new WaitForSeconds(1f);    //올라가는 모션 기다리기

        blackEye.SetActive(true);
        grayEye.SetActive(true);

        yield return new WaitForSeconds(BlackOpenDelay);

        blackEye.GetComponent<BlackEye>().StartAttack();

        yield return new WaitForSeconds(GrayOpenDelay);

        grayEye.GetComponent<GrayEye>().StartAttack();
    }

    public override void Reset()
    {
        base.Reset();
    }
}
