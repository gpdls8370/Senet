using System.Collections;
using UnityEngine;

public class HideZone : MonoBehaviour
{
    public GameObject TargetEnemy;
    private HideSkill _hideSkill;
    private HideDetect _hideDetect;
    private SleepCycle _sleepCycle;

    private bool mustHide = false;
    public bool mustDetected = false;
    public float MustHideDelay = 0.5f;

    private void Awake()
    {
        _hideSkill = StateManager.Instance.Player.GetComponent<HideSkill>();

        if (TargetEnemy != null)
        {
            _hideDetect = TargetEnemy.GetComponent<HideDetect>();
            _sleepCycle = TargetEnemy.GetComponent<SleepCycle>();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            _hideSkill.HideZoneCount++;
            StartCoroutine(HideTimeCountCoroutine());
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (!_hideSkill.CanHide)
            {
                _hideSkill.CanHide = true;
            }

            if (_hideDetect != null && _hideDetect.DetectedYellowIcon != null)
            {
                _hideDetect.DetectedYellowIcon.SetActive(true);
            }

            if (!_hideDetect.isDetected)
            {
                if (PlayerManager.Instance != null)
                {
                    if (PlayerManager.Instance.isInvincibleInHide)
                    {
                        return;
                    }
                }

                if (_sleepCycle != null) 
                {
                    if (_sleepCycle.isAwake)
                    {
                        _hideDetect.Detected();
                        _sleepCycle.GetComponentInChildren<Animator>().enabled = false;
                        _sleepCycle.SleepingIcon.SetActive(false);
                        _sleepCycle.enabled = false;
                    }
                }
                
                if (mustHide && !StateManager.Instance.isHiding())
                {
                    _hideDetect.Detected();
                    if(GetComponentInParent<ShakeEnemy>() != null)
                    {
                        GetComponentInParent<ShakeEnemy>().transform.GetComponentInChildren<Animator>().enabled = false;
                    }
                }

                if (mustDetected)
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
            if (_hideDetect.DetectedYellowIcon != null)
            {
                _hideDetect.DetectedYellowIcon.SetActive(false);
            }
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
