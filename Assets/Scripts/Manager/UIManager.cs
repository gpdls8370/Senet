using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public bool HideSkillPopUp = false;

    public GameObject Road2_EnterPanel;
    public GameObject Road2_DoorFindPanel;
    public GameObject Road2_RoomMoveTryPanel;
    public GameObject Road4_EnterPanel;
    public GameObject HideTextPanel;

    //패널 띄워야 되는 곳에 Panel_Enable(UIManager.Instance.위에중에패널);

    public void Panel_Enable(GameObject panel)
    {
        panel.SetActive(true);
        StateManager.Instance.Pause();
    }

    public void Panel_MoveButton_Move(GameObject movePanel)
    {
        movePanel.SetActive(true);
    }

    public void Panel_MoveButton_NowExit(GameObject nowPanel)
    {
        nowPanel.SetActive(false);
    }

    public void Panel_EndButton(GameObject panel)
    {
        panel.SetActive(false);
        StateManager.Instance.Resume();
    }   

}
