using UnityEngine;

public class Chapter1Manager : Singleton<Chapter1Manager>
{
    public Camera MainCamera;

    public bool HaveKey = false;
    public bool RockDoorFounded = false;

    public GameObject RedLight;
    public GameObject YellowLight;

    [Header("Panel")]
    public GameObject Road2_EnterPanel;
    public GameObject Road2_DoorFindPanel;
    public GameObject Road2_RoomMoveTryPanel;
    public GameObject Road4_EnterPanel;
    public GameObject HideTextPanel;
    public GameObject FindKeyPanel;
}
