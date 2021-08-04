using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDetect : MonoBehaviour
{
    public bool isDetected = false;
    public GameObject DetectedIconObject;
    public Sprite DetectedIconImage;

    private NpcSentence _npcSentence;
    private SleepCycle _sleepCycle;

    protected virtual void Start()
    {
        _npcSentence = GetComponent<NpcSentence>();
        _sleepCycle = GetComponent<SleepCycle>();
    }

    public void Detected()
    {
        if (!StateManager.Instance.isDead())
        {
            StateManager.Instance.SetDead();
            isDetected = true;
            if (_sleepCycle != null) { _sleepCycle.SetAwake(); }
            StopAllCoroutines();
            DetectedIconObject.SetActive(true);
            DetectedIconObject.GetComponent<SpriteRenderer>().sprite = DetectedIconImage;
            _npcSentence.TalkNpc();
            StateManager.Instance.PlayerPause();
        }
    }
}
