using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pattern4 : PatternBase
{
    [SerializeField] private int TypesNum;
    [SerializeField] private Pattern4Type[] IllusionTypes;
    [SerializeField] private Pattern4Type[] RealTypes;

    [SerializeField] private float BetweenRealDelay;

    private int bombType;

    public override void StartPattern()
    {
        SwitchStretch();

        bombType = Random.Range(0, TypesNum);

        StartCoroutine(PatternCoroutine());
    }

    private IEnumerator PatternCoroutine()
    {
        yield return new WaitForSeconds(1f);    //올라가는 모션 기다리기

        IllusionTypes[bombType].TypeActionStart();

        yield return new WaitForSeconds(IllusionTypes[bombType].GetShowTime());
        yield return new WaitForSeconds(BetweenRealDelay);

        RealTypes[bombType].TypeActionStart();

        yield return new WaitForSeconds(RealTypes[bombType].GetShowTime());




        StopPattern();
    }

    public override void StopPattern()
    {
        base.StopPattern();
        SwitchIdle();
    }
}
