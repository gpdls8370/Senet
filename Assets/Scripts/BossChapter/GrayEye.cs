using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayEye : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float OpeningDuration;

    [SerializeField] bool UseAutoUnActive;
    [SerializeField] private float CloseDelay;
    [SerializeField] private GameObject GrayZone;

    public void StartAttack()
    {
        animator.SetTrigger("OpenEye");
        StartCoroutine(OpeningCoroutine());
    }

    private IEnumerator OpeningCoroutine()
    {
        yield return new WaitForSeconds(OpeningDuration);

        animator.SetTrigger("CloseEye");

        if (UseAutoUnActive)
        {
            yield return new WaitForSeconds(CloseDelay);
            GrayZone.SetActive(false);
        }
    }
}
