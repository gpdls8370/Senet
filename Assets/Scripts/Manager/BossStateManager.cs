using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : Singleton<BossStateManager>
{
    public enum MovementStates { Idle, Walk }
    public MovementStates nowMovementState;


    public GameObject Boss;
    private Animator animator;
    private BossMovement bossMovement;

    protected override void Awake()
    {
        base.Awake();
        animator = Boss.GetComponentInChildren<Animator>();
        bossMovement = Boss.GetComponent<BossMovement>();
    }

    public void SetMovementState(MovementStates state)
    {
        nowMovementState = state;
        UpdateAnimator();
    }


    private void UpdateAnimator()
    {
        animator.SetBool("Idle", nowMovementState == MovementStates.Idle);
        animator.SetBool("Walking", nowMovementState == MovementStates.Walk);
    }

    public bool isWalking() { return nowMovementState == MovementStates.Walk; }

}
