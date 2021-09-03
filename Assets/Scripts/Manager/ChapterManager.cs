using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : Singleton<ChapterManager>
{
    public bool MoveChapterScene_Unlock;
    public bool Chapter1_Unlock;     //처음부터 되어있음
    public bool Chapter2_Unlock;     //1챕터를 클리어 했을 때
    public bool Chapter3_Unlock ;    //2챕터를 클리어 했을 때

    [Header("Middle Save")]
    public bool Chapter1ClearDoor;
    public bool Chapter2ClearDoor;

    [Header("Guide UI")]
    public bool HideSkillGuideOn;
    public bool DashSkillGuideOn;
    public bool TimebackSkillGuideOn;

    protected override void Awake()
    {
        ChapterManager[] obj = FindObjectsOfType<ChapterManager>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMoveChapterAvailable()
    {
        MoveChapterScene_Unlock = true;
    }

    public void SetChapter1Available()
    {
        Chapter1_Unlock = true;
    }

    public void SetChapter2Available()
    {
        Chapter2_Unlock = true;
        Chapter1ClearDoor = false;
    }

    public void SetChapter3Available()
    {
        Chapter3_Unlock = true;
        Chapter2ClearDoor = false;
    }

    public void SetHideSkillGuideOn()
    {
        HideSkillGuideOn = true;
    }

    public void SetDashSkillGuideOn()
    {
        DashSkillGuideOn = true;
    }

    public void SetTimebackSkillGuideOn()
    {
        TimebackSkillGuideOn = true;
    }
}

    

