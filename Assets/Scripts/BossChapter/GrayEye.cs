using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayEye : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float OpeningTime;

    [SerializeField] bool UseAutoUnActive;
    [SerializeField] private float CloseDelay;

    public void StartAttack()
    {
        animator.SetTrigger("OpenEye");
        StartCoroutine(OpeningCoroutine());
    }

    private IEnumerator OpeningCoroutine()
    {
        yield return new WaitForSeconds(OpeningTime);

        animator.SetTrigger("CloseEye");

        if (UseAutoUnActive)
        {
            yield return new WaitForSeconds(CloseDelay);
            gameObject.SetActive(false);
        }
    }
}
