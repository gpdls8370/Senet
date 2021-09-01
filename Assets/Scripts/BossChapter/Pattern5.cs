using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern5 : PatternBase
{
    [SerializeField] private GameObject BlackEye;
    [SerializeField] private GameObject GrayEye;
    [SerializeField] private GameObject RedEye;

    [SerializeField] private float Red_BlackGap;
    [SerializeField] private float Black_GrayGap;
    [SerializeField] private float RedBlackStartDelay;
    [SerializeField] private float RedBlackEndDelay;
    [SerializeField] private float GrayStartDelay;
    [SerializeField] private float PatternEndDelay;

    public override void StartPattern()
    {
        SwitchStretch();
        StartCoroutine(PatternCoroutine());
    }

    private IEnumerator PatternCoroutine()
    {
        yield return new WaitForSeconds(1f);    //올라가는 모션 기다리기

        RedEye.SetActive(true);

        yield return new WaitForSeconds(Red_BlackGap);

        BlackEye.SetActive(true);

        yield return new WaitForSeconds(Black_GrayGap);

        GrayEye.SetActive(true);

        yield return new WaitForSeconds(RedBlackStartDelay);

        BlackEye.GetComponent<BlackEye>().StartAttack();
        RedEye.GetComponent<RedEye>().StartAttack();

        yield return new WaitForSeconds(RedBlackEndDelay);

        BlackEye.GetComponent<BlackEye>().StopAttack();
        RedEye.GetComponent<RedEye>().StopAttack();

        yield return new WaitForSeconds(GrayStartDelay);

        GrayEye.GetComponent<GrayEye>().StartAttack();

        //GrayEye는 자체적으로 눈 감음

        yield return new WaitForSeconds(PatternEndDelay);

        StopPattern();
    }

    public override void StopPattern()
    {
        base.StopPattern();

        SwitchIdle();

        RedEye.SetActive(false);
        BlackEye.SetActive(false);
        GrayEye.SetActive(false);
    }

}
