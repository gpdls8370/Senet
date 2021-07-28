using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideZone : MonoBehaviour
{

    public enum HideZoneTypes { HideZone, MustHideZone }
    public HideZoneTypes HideZoneType;

    private HideSkill _hideSkill;
    private SleepCycle _sleepCycle;
    private NpcSentence _npcSentence;
    private bool isExitTrigger = false;
    private Collider2D collision;


    private bool isDetected = false;

    private void Awake()
    {
        _hideSkill = StateManager.Instance.Player.GetComponent<HideSkill>();
        _sleepCycle = GetComponentInParent<SleepCycle>();
        _npcSentence = GetComponentInParent<NpcSentence>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !UIManager.Instance.HideSkillPopUp)
        {
            UIManager.Instance.HidePanel_Enable();
            UIManager.Instance.HideSkillPopUp = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        isExitTrigger = false;

        if (col.tag == "Player")
        {
            if (HideZoneType == HideZoneTypes.HideZone && !_hideSkill.CanHide)
            {
                _hideSkill.CanHide = true;
            }

            if (HideZoneType == HideZoneTypes.MustHideZone && !StateManager.Instance.isHiding())
            {
                Detected();
            }

            else if (_sleepCycle.isAwake)
            {
                Detected();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        isExitTrigger = true;
        collision = col;
        Invoke("ExitTrigger", 0.01f);
    }

    private void ExitTrigger()
    {
        if (isExitTrigger)
        {
            if (collision.tag == "Player")
            {
                if (HideZoneType == HideZoneTypes.HideZone)
                {
                    _hideSkill.CanHide = false;
                }
            }
        }
    }

    private void Detected()
    {
        if (!isDetected) 
        {
            isDetected = true;
            StateManager.Instance.SetDead();
            _sleepCycle.SetAwake();
            _sleepCycle.StopAllCoroutines();
            _sleepCycle.DetectedIcon.SetActive(true);
            _npcSentence.TalkNpc();
        }
    }    
}
