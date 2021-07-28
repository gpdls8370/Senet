using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : Singleton<StateManager>
{
    public enum PlayerStates { Idle, Walk, Run, Dead }
    public enum SkillStates { Idle, Hide  }
    public PlayerStates nowPlayerState;
    public SkillStates nowSkillState;

    public GameObject Player;
    private Animator animator;


    protected override void Awake()
    {
        base.Awake();
        animator = Player.GetComponentInChildren<Animator>();
    }

    public void SetPlayerState(PlayerStates state)
    {
        nowPlayerState = state;
        UpdateAnimator();
    }

    public void SetSkillState(SkillStates state)
    {
        nowSkillState = state;
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        animator.SetBool("Idle", nowPlayerState == PlayerStates.Idle);
        animator.SetBool("Walking", nowPlayerState == PlayerStates.Walk);
        animator.SetBool("Running", nowPlayerState == PlayerStates.Run);
        animator.SetBool("Hide", nowSkillState == SkillStates.Hide);
    }

    public void SetDead()
    {
        nowPlayerState = PlayerStates.Dead;
        animator.SetBool("Dead", nowPlayerState == PlayerStates.Dead);  
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }


    public bool isWalking() { return nowPlayerState == PlayerStates.Walk; }
    public bool isRunning() { return nowPlayerState == PlayerStates.Run; }
    public bool isHiding() { return nowSkillState == SkillStates.Hide; }
    public bool isDead() { return nowPlayerState == PlayerStates.Dead; }
}
