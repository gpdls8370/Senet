using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideEye : MonoBehaviour
{
    private enum EyeStates { BlackEye, GrayEye, RedEye }
    [SerializeField] private EyeStates eyeState;
    
    [SerializeField] private float EyeOpenDelay;
    [SerializeField] private float EndDelayAfterEyeOpen;

    [SerializeField] private Animator animator;

    [Header("Position")]
    public Transform waitingPos;

    [Header("Illusion")]
    [SerializeField] private bool illusion;
    [SerializeField] private GameObject illusionPlayer;

    [Header("BlackEye")]
    [SerializeField] private GameObject HideZone;

    [Header("GrayEye")]
    [SerializeField] private GameObject EyeZone;

    private bool isPatroling;
    private Vector3 direction;
    private Vector3 targetPos;

    private void Awake()
    {
        if (eyeState == EyeStates.BlackEye && !illusion)
        {
            HideZone.GetComponent<HideZone>().MustHideDelay = EyeOpenDelay;
        }
    }

    private void Update()
    {
        if (isPatroling)
        {
            DirectionPatrol();
        }
    }

    private void OnEnable()
    {
        StartCoroutine(EyeOpenDelayCoroutine());
        isPatroling = true;
    }

    private void DirectionPatrol()
    {
        transform.position = waitingPos.position;

        if (illusion)
        {
            targetPos = illusionPlayer.transform.position;
        }
        else
        {
            targetPos = PlayerManager.Instance.Player.transform.position;
        }

        direction = targetPos - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500 * Time.deltaTime);
    }

    private IEnumerator EyeOpenDelayCoroutine()
    {
        yield return new WaitForSeconds(EyeOpenDelay);

        isPatroling = false;

        if (eyeState == EyeStates.GrayEye)
        {
            EyeZone.SetActive(false);
            if (illusion)
            {
                animator.SetTrigger("OpenEye");
            }
            else
            {
                GetComponent<GrayEye>().StartAttack();
            }
        }

        else if(eyeState == EyeStates.BlackEye)
        {
            if (illusion)
            {
                animator.SetTrigger("OpenEye");
                Invoke("HideZoneOn", 0.5f);
            }
            else
            {
                GetComponent<BlackEye>().StartAttack();
            }
        }

        //레드도

        yield return new WaitForSeconds(EndDelayAfterEyeOpen);

        gameObject.SetActive(false);
    }

    private void HideZoneOn()
    {
        HideZone.SetActive(true);
    }
}
