using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGuide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !ChapterManager.Instance.HideSkillGuideOn)
        {
            ChapterManager.Instance.SetHideSkillGuideOn();
            UIManager.Instance.Panel_Enable(Chapter1Manager.Instance.HideTextPanel); 
        }
    }
}
