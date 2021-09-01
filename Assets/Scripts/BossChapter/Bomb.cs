using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float BombFallingDealy;
    [SerializeField] private float InvincibleTime;
    [SerializeField] private bool Illusion;

    private bool isEnable;
    private bool isInvincible;

    private void OnEnable()
    {
        isEnable = true;
        isInvincible = false;
        StartCoroutine(BombTimeCoroutine());
    }

    private IEnumerator BombTimeCoroutine()
    {
        yield return new WaitForSeconds(BombFallingDealy);

        gameObject.SetActive(false);
    }

    private IEnumerator InvincibleCoroutine()
    {
        isInvincible = true;

        yield return new WaitForSeconds(InvincibleTime);

        isInvincible = false;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
           if (!Illusion && isEnable && !isInvincible)
            {
                PlayerManager.Instance.LoseLife(1);
                StartCoroutine(InvincibleCoroutine());
            }
        }
    }

    private void OnDisable()
    {
        isEnable = false;
    }

}
