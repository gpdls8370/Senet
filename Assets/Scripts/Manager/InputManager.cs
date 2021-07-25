using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [Header("Movement")]
    public KeyCode LeftMove;
    public KeyCode RightMove;
    public KeyCode UpMove;
    public KeyCode DownMove;

    [Header("Run")]
    public KeyCode Run;

    [Header("Dash")]
    public KeyCode Dash;

    [Header("Interaction")]
    public KeyCode Interaction;

    [Header("Skill")]
    public KeyCode Hide;
    public KeyCode StopTime;

}
