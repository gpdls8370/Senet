using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingWindow : MonoBehaviour
{
    private SpriteRenderer spr;
    private bool Disappearing;
    private Color color;
    [SerializeField] private float removeDuration;
    private float nowTime;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        StartCoroutine(LightCoroutine());
    }

    private void Update()
    {

        if (Disappearing && color.a > 0)
        {
            nowTime -= Time.deltaTime;
            spr.color = new Color(1, 1, 1, nowTime / removeDuration);
        }

        if (spr.color.a <= 0)
        {
            Disappearing = false;
        }
    }

    private IEnumerator LightCoroutine()
    {
        yield return new WaitForSeconds(1f);

        nowTime = removeDuration;
        spr.enabled = true;
        color.a = 1f;
        Disappearing = true;

        yield return new WaitForSeconds(Chapter2Manager.Instance.LightingTime);

        StartCoroutine(LightCoroutine());
    }
}
