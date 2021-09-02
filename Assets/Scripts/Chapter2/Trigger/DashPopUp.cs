using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPopUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!ChapterManager.Instance.DashSkillGuideOn)
            {
                UIManager.Instance.Panel_Enable(Chapter2Manager.Instance.DashSkillGuide);
                ChapterManager.Instance.SetDashSkillGuideOn();
                Chapter2Manager.Instance.DashSkillIconOn();
            } 
        }
    }
}
