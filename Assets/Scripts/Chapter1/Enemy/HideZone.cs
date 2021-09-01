using System.Collections;
using UnityEngine;

public class HideZone : MonoBehaviour
{
    public GameObject TargetEnemy;
    private HideSkill _hideSkill;
    private HideDetect _hideDetect;
    private SleepCycle _sleepCycle;

    private bool mustHide = false;
    public float MustHideDelay = 0.5f;
    

    private void Awake()
    {
        _hideSkill = StateManager.Instance.Player.GetComponent<HideSkill>();
        _hideDetect = TargetEnemy.GetComponent<HideDetect>();
        _sleepCycle = TargetEnemy.GetComponent<SleepCycle>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (!_hideSkill.CanHide)
            {
                _hideSkill.CanHide = true;
            }

            _hideDetect.DetectedIconObject.SetActive(true);
            _hideSkill.HideZoneCount++;
            StartCoroutine(HideTimeCountCoroutine());
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (!_hideDetect.isDetected)
            {
                if (_sleepCycle != null) 
                {
                    if (_sleepCycle.isAwake)
                    {
                        _hideDetect.Detected();
                    }
                }
                
                if (mustHide && !StateManager.Instance.isHiding())
                {
                    _hideDetect.Detected();
                }           
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            _hideSkill.CanHide = false;
            UIManager.Instance.skillBox.HideIconUnable();
            mustHide = false;
            _hideDetect.DetectedIconObject.SetActive(false);
            _hideSkill.HideZoneCount--;
            StopAllCoroutines();
        }
    }

    private IEnumerator HideTimeCountCoroutine()
    {
        yield return new WaitForSeconds(MustHideDelay);
        mustHide = true;

        if (!StateManager.Instance.isHiding())
        {
            _hideDetect.Detected();
        }
    }
}
