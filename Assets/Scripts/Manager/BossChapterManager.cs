using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChapterManager : Singleton<BossChapterManager>
{
    public float TotalBossTime;
    public float NowTime;

    private void Start()
    {
        NowTime = TotalBossTime;
    }

    private void Update()
    {
        NowTime -= Time.deltaTime;
    }
}
