using UnityEngine;

public class Chapter1Manager : Singleton<Chapter1Manager>
{
    public bool HaveKey = false;
    public bool RockDoorFounded = false;
    public bool HideSkillPopUp = false;

    public GameObject RedLight;
    public GameObject YellowLight;
}
