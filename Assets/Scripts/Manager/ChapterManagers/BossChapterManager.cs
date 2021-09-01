using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChapterManager : Singleton<BossChapterManager>
{
    [Header("Time")]
    public float TotalBossTime;
    public float NowTime;

    [Header("UI")]
    public LifeBox lifeBox;

    private void Start()
    {
        NowTime = TotalBossTime;
    }

    private void Update()
    {
        NowTime -= Time.deltaTime;
    }
}
