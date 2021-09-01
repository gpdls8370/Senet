using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float damageCooltime;
    private bool CanDamaged = true;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && CanDamaged)
        {
            PlayerManager.Instance.LoseLife(damage);
            StartCoroutine(DamageCooltimeCoroutine());
        }
    }

    private IEnumerator DamageCooltimeCoroutine()
    {
        CanDamaged = false;

        yield return new WaitForSeconds(damageCooltime);

        CanDamaged = true;
    }
}
