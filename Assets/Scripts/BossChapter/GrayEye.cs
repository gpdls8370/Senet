using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayEye : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float OpeningDuration;

    [SerializeField] bool UseAutoUnActive;
    [SerializeField] private float CloseDelay;
    public GameObject GrayZone;
    [SerializeField] private Sprite CloseImage;

    public void StartAttack()
    {
        animator.SetTrigger("OpenEye");
        StartCoroutine(OpeningCoroutine());
    }

    public void StopAttack()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = CloseImage;
  
        Invoke("ZoneOff", 0.5f);
    }

    private IEnumerator OpeningCoroutine()
    {
        Invoke("ZoneOn", 0.5f);

        yield return new WaitForSeconds(OpeningDuration);

        animator.SetTrigger("CloseEye");

        if (UseAutoUnActive)
        {
            yield return new WaitForSeconds(CloseDelay);
            GrayZone.SetActive(false);
        }
    }

    private void ZoneOn()
    {
        GrayZone.SetActive(true);
    }

    private void ZoneOff()
    {
        GrayZone.SetActive(false);
    }
}
