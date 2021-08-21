using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2 : PatternBase
{
    [SerializeField] private GameObject[] KnifeList;
    [SerializeField] private float SpawnKnifeDelay = 1f;

    private int StopKnifeCount = 0;

    public override void StartPattern()
    {
        StartCoroutine(SpawnKnife());   
    }

    private IEnumerator SpawnKnife()
    {
        for (int i = 0; i < 3;)
        {
            int r = Random.Range(0, 10);

            if (!KnifeList[r].activeInHierarchy)
            {
                KnifeList[r].SetActive(true);
                i++;

                yield return new WaitForSeconds(SpawnKnifeDelay);           
            }
        }
    }

    public override void StopPattern()
    {
        StopKnifeCount++;

        if (StopKnifeCount >= 3)
        {
            BossPatternManager.Instance.StopPattern();
            Reset();
        }      
    }

    public override void Reset()
    {
        StopKnifeCount = 0;

        for (int i = 0; i < KnifeList.Length; i++)
        {
            KnifeList[i].GetComponent<Knife>().Reset();
        }
    }
}
