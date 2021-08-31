using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern3 : PatternBase
{
    [SerializeField] private GameObject[] PlayerPatterns;
    [SerializeField] private GameObject[] IllusionPatterns;

    [SerializeField] private GameObject IllusionCharacter;
    [SerializeField] private float IllusionAttackDelay;
    [SerializeField] private float IllusionEndTime;
    [SerializeField] private float PlayerPatternSpawnDelay;

    private int[] RandomPattern;

    protected override void Update()
    {
        base.Update();
    }

    private void Start()
    {
        RandomPattern = new int[3];
    }

    public override void StartPattern()
    {
        SwitchStretch();
        StartCoroutine(SpawnIllusion());
    }

    private IEnumerator SpawnIllusion()
    {
        yield return new WaitForSeconds(1f);    //올라가는 모션 기다리기

        IllusionCharacter.SetActive(true);

        yield return new WaitForSeconds(IllusionAttackDelay);

        SpawnIllusionPattern();

        yield return new WaitForSeconds(IllusionEndTime);

        DespawnIllusion();

        yield return new WaitForSeconds(PlayerPatternSpawnDelay);

        SpawnPlayerPattern();

    }

    private void SpawnIllusionPattern()
    {
        for (int i = 0; i < 3;)
        {
            RandomPattern[i] = Random.Range(0, 5);

            if (!IllusionPatterns[RandomPattern[i]].activeInHierarchy)
            {
                IllusionPatterns[RandomPattern[i]].SetActive(true);
                i++;
            }
        }
    }

    private void DespawnIllusion()
    {
        IllusionCharacter.SetActive(false);

        for (int i = 0; i < IllusionPatterns.Length; i++)
        {
            IllusionPatterns[i].SetActive(false);
        }
    }

    private void SpawnPlayerPattern()
    {
        for (int i = 0; i < 3;)
        {
            if (!PlayerPatterns[RandomPattern[i]].activeInHierarchy)
            {
                PlayerPatterns[RandomPattern[i]].SetActive(true);
                i++;
            }
        }
    }

    public override void StopPattern()
    {
        base.StopPattern();
        SwitchIdle();
    }

    public override void Reset()
    {
        RandomPattern = new int[3];
    }
}
