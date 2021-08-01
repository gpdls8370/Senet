using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideZone : MonoBehaviour
{

    public enum HideZoneTypes { HideZone, MustHideZone }
    public HideZoneTypes HideZoneType;

    private HideSkill _hideSkill;
    private SleepCycle _sleepCycle;
    private bool isExitTrigger = false;
    private Collider2D collision;


    private void Awake()
    {
        _hideSkill = StateManager.Instance.Player.GetComponent<HideSkill>();
        _sleepCycle = GetComponentInParent<SleepCycle>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            _sleepCycle.DetectedIcon.SetActive(true);

            if (!UIManager.Instance.HideSkillPopUp)
            {
                UIManager.Instance.HidePanel_Enable();
                UIManager.Instance.HideSkillPopUp = true;
            }
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
                _sleepCycle.Detected();
            }

            else if (_sleepCycle.isAwake)
            {
                _sleepCycle.Detected();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            isExitTrigger = true;
            collision = col;
            Invoke("ExitTrigger", 0.01f);

            _sleepCycle.DetectedIcon.SetActive(false);
        }
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
}
