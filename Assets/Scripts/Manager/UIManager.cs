using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [Header("UI")]
    public SkillBox skillBox;
    public GameObject GameoverPanel;

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

    public void MoveScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        StateManager.Instance.Resume();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
