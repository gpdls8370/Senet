using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (NowTime <= 0)
        {
            //클리어
            SceneManager.LoadScene("chap boss end");
        }
    }
}
