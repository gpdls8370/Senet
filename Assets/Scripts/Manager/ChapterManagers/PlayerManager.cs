using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public GameObject Player;

    public int MaxLife;
    public int NowLife;

    public bool isInvincibleInHide = false;

    private SpriteRenderer spr;

    protected override void Awake()
    {
        base.Awake();
        spr = Player.GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        NowLife = MaxLife;
    }

    public void LoseLife(int damage)
    {
        StartCoroutine(DamageEffect());
        NowLife -= damage;

        BossChapterManager.Instance.lifeBox.LoseLife(damage);

        if (NowLife <= 0)
        {
            StateManager.Instance.PlayerPause();
            Invoke("Dead", 1f);
        }
    }

    private void Dead()
    {
        StateManager.Instance.SetDead();
    }

    private IEnumerator DamageEffect()
    {
        for (int i = 0; i < 3; i++) {
            spr.color = new Color(1, 1, 1, 0.3f);
            yield return new WaitForSeconds(0.1f);
            spr.color = new Color(1, 1, 1, 1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
