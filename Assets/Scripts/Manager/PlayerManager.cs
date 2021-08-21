using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public GameObject Player;

    public int MaxLife;
    public int NowLife;

    public bool isInvincibleInHide = false;

    protected override void Awake()
    {
        base.Awake();
        
    }

    private void Start()
    {
        NowLife = MaxLife;
    }

    public void LoseLife(int damage)
    {
        NowLife -= damage;
        UIManager.Instance.lifeBox.LoseLife(damage);
        
        if (NowLife <= 0)
        {
            Dead();
        }
    
    }

    private void Dead()
    {
        StateManager.Instance.SetDead();
        StateManager.Instance.PlayerPause();
    }


}
