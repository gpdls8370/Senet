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

    public override void StartPattern()
    {
        SwitchStretch();
        transform.position = PlayerManager.Instance.Player.transform.position;
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
