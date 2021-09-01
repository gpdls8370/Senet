using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDetect : MonoBehaviour
{
    public bool isDetected = false;
    public bool DeadAfterDetected = true;
    public GameObject DetectedIconObject;
    public Sprite DetectedIconImage;

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

            if (DetectedIconObject != null)
            {
                DetectedIconObject.SetActive(true);
                DetectedIconObject.GetComponent<SpriteRenderer>().sprite = DetectedIconImage;
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

            StopAllCoroutines();
        }
    }
}
