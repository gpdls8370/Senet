using System.Collections;
using UnityEngine;

public class cctvZone : MonoBehaviour
{
    public AudioClip clip;
    private bool cctvON;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(CCTVCoroutine());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && cctvON)
        {
            UIManager.Instance.Panel_Enable(Chapter2Manager.Instance.cctcDetected);
        }
    }

    private IEnumerator CCTVCoroutine()
    {
        if (clip != null && SoundManager.instance != null)
        {
            SoundManager.instance.SFXPlay("thunder", clip);
        }

        yield return new WaitForSeconds(0.9f);

        cctvON = false;
        spriteRenderer.enabled = false;

        yield return new WaitForSeconds(1.5f);

        cctvON = true;
        spriteRenderer.enabled = true;

        yield return new WaitForSeconds(Chapter2Manager.Instance.LightingTime -0.5f - 0.9f);


        StartCoroutine(CCTVCoroutine());
    }
}
