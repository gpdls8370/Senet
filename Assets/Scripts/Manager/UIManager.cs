using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    public GameObject Road2_EnterPanel;
    public GameObject Road2_DoorFindPanel;
    public GameObject Road2_RoomMoveTryPanel;
    public GameObject Road4_EnterPanel;
    public GameObject HideTextPanel;


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

    public void RestartScene()
    {
        //테스트 빌드 버전에서 사용
        SceneManager.LoadScene(0);
    }
}
