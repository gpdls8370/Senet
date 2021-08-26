using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern4 : PatternBase
{
    [SerializeField] private int TypesNum;
    [SerializeField] private Pattern4Type[] IllusionTypes;
    [SerializeField] private Pattern4Type[] RealTypes;

    [SerializeField] private float IllusionDuration;
    [SerializeField] private float BetweenRealDelay;
    [SerializeField] private float RealDuration;

    private int bombType;

    public override void StartPattern()
    {
        bombType = Random.Range(0, TypesNum);

        StartCoroutine(PatternCoroutine());
    }

    private IEnumerator PatternCoroutine()
    {
        IllusionTypes[bombType].TypeActionStart();

        yield return new WaitForSeconds(IllusionDuration);

        IllusionTypes[bombType].TypeActionEnd();

        yield return new WaitForSeconds(BetweenRealDelay);

        RealTypes[bombType].TypeActionStart();

        yield return new WaitForSeconds(RealDuration);

        RealTypes[bombType].TypeActionEnd();

    }

    public override void StopPattern()
    {
        base.StopPattern();
        
    }
}
