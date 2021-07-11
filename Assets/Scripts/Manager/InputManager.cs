using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Movement")]
    public KeyCode LeftMove;
    public KeyCode RightMove;
    public KeyCode UpMove;
    public KeyCode DownMove;

    [Header("Dash")]
    public KeyCode Dash;

    [Header("Interaction")]
    public KeyCode Interaction;

    [Header("Skill")]
    public KeyCode Hide;
    public KeyCode StopTime;

}
