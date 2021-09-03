using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDetect : MonoBehaviour
{
    public bool isDetected = false;
    public bool DeadAfterDetected = true;
    public bool PauseAfterDetected = true;
    public GameObject DetectedYellowIcon;
    public GameObject DetectedRedIcon;

    public int DamageAmount = 1;

    private NpcSentence _npcSentence;
    private SleepCycle _sleepCycle;

    protected virtual void Start()
    {
        _npcSentence = GetComponent<NpcSentence>();
        _sleepCycle = GetComponent<SleepCycle>();
    }

    public virtual void Detected()
    {
        if (!StateManager.Instance.isDead())
        {
            isDetected = true;

            if (_sleepCycle != null)
            {
                _sleepCycle.SetAwake();
            }

            if (DetectedYellowIcon != null && DetectedRedIcon != null)
            {
                DetectedYellowIcon.SetActive(false);
                DetectedRedIcon.SetActive(true);
            }
     
            if (_npcSentence != null) 
            {
                _npcSentence.TalkNpc(); 
            }

            if (DeadAfterDetected) 
            {
                StateManager.Instance.SetDead();
                StateManager.Instance.PlayerPause(); 
            }

            if (PauseAfterDetected)
            {
                StateManager.Instance.PlayerPause();
            }

            StopAllCoroutines();
        }
    }
}
