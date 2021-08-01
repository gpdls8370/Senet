using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject HideTextPanel;
    public bool HideSkillPopUp = false;

    public void HidePanel_Enable()
    {
        HideTextPanel.gameObject.SetActive(true);
    }

    public void HidePanel_Endbt()
    {
        HideTextPanel.gameObject.SetActive(false);
    }
}
