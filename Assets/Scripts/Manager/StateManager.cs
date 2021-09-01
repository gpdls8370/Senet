using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : Singleton<StateManager>
{
    public enum MovementStates { Idle, Walk, Run, Dead }
    public enum SkillStates { Idle, Hide }
    public MovementStates nowMovementState;
    public SkillStates nowSkillState;

    public GameObject Player;
    private Animator animator;


    protected override void Awake()
    {
        base.Awake();
        animator = Player.GetComponentInChildren<Animator>();
    }

    public void SetMovementState(MovementStates state)
    {
        nowMovementState = state;
        UpdateAnimator();
    }

    public void SetPlayerState(SkillStates state)
    {
        nowSkillState = state;
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        animator.SetBool("Idle", nowMovementState == MovementStates.Idle);
        animator.SetBool("Walking", nowMovementState == MovementStates.Walk);
        animator.SetBool("Running", nowMovementState == MovementStates.Run);
    }

    public void UpdateWalkingDirection(Vector2 direction)
    {
        animator.SetFloat("DirectionX", direction.x);
        animator.SetFloat("DirectionY", direction.y);
    }

    public void SetDead()
    {
        nowMovementState = MovementStates.Dead;
        animator.SetBool("Dead", nowMovementState == MovementStates.Dead);  
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void PlayerPause()
    {
        Player.GetComponent<CharacterMovement>().enabled = false;
    }

    public bool isWalking() { return nowMovementState == MovementStates.Walk; }
    public bool isRunning() { return nowMovementState == MovementStates.Run; }
    public bool isHiding() { return nowSkillState == SkillStates.Hide; }
    public bool isDead() { return nowMovementState == MovementStates.Dead; }

}
