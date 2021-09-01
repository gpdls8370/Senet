using System.Collections;
using UnityEngine;

public class cctvZone : MonoBehaviour
{
    private bool cctvON;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(CCTVCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && cctvON)
        {
            StateManager.Instance.SetDead();
        }
    }

    private IEnumerator CCTVCoroutine()
    {
        cctvON = true;
        spriteRenderer.enabled = true;

        yield return new WaitForSeconds(6f);

        cctvON = false;
        spriteRenderer.enabled = false;

        yield return new WaitForSeconds(1f);

        StartCoroutine(CCTVCoroutine());
    }
}
