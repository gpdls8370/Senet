using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2 : PatternBase
{
    [SerializeField] private GameObject[] KnifeList;
    [SerializeField] private float SpawnKnifeDelay = 1f;

    public AudioClip clip1;
    public AudioClip clip2;

    private bool KnifeSpawned;

    public override void StartPattern()
    {
        SwitchThrow();
        StartCoroutine(SpawnKnife());  
    }

    protected override void Update()
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
        SoundManager.instance.SFXPlay("knife throw", clip1);
        yield return new WaitForSeconds(1f);    //칼 던지는 모션 기다리기

        for (int i = 0; i < 3;)
        {
            int r = Random.Range(0, 10);

            if (!KnifeList[r].activeInHierarchy)
            {
                KnifeList[r].SetActive(true);
                SoundManager.instance.SFXPlay("knife spawn", clip2);
                i++;

                yield return new WaitForSeconds(SpawnKnifeDelay);           
            }
        }

        KnifeSpawned = true;
    }

    public override void StopPattern()
    {
        BossPatternManager.Instance.StopPattern();
        SwitchIdle();
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
