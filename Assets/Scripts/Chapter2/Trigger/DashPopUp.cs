using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPopUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!Chapter2Manager.Instance.DashPopupOn)
            {
                UIManager.Instance.Panel_Enable(Chapter2Manager.Instance.DashSkillGuide);
                Chapter2Manager.Instance.DashPopupOn = true;
                Chapter2Manager.Instance.DashSkillIconOn();
            } 
        }
    }
}
