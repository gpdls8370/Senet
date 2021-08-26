using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2 : PatternBase
{
    [SerializeField] private GameObject[] KnifeList;
    [SerializeField] private float SpawnKnifeDelay = 1f;

    private bool KnifeSpawned;

    public override void StartPattern()
    {
        StartCoroutine(SpawnKnife());   
    }

    private void Update()
    {
        if (KnifeSpawned)
        {
            for (int i=0;i< KnifeList.Length; i++)
            {
                if (KnifeList[i].activeInHierarchy)
                {
                    return;
                }
            }
            StopPattern();
        }
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

        KnifeSpawned = true;
    }

    public override void StopPattern()
    {
        BossPatternManager.Instance.StopPattern();
        Reset();
    }

    public override void Reset()
    {
        KnifeSpawned = false;

        for (int i = 0; i < KnifeList.Length; i++)
        {
            KnifeList[i].GetComponent<Knife>().Reset();
        }
    }
}
