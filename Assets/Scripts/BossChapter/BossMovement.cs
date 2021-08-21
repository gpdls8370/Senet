using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    [Header("Speed")]
    public float WalkSpeed;

    private bool isPatroling;

    private Transform playerTr;
    private NavMeshAgent nvAgent;

    public ParticleSystem FootSteps;

    private void Start()
    {
        playerTr = PlayerManager.Instance.Player.transform;

        nvAgent = GetComponent<NavMeshAgent>();
        nvAgent.speed = WalkSpeed;
        nvAgent.updateRotation = false;
        nvAgent.updateUpAxis = false;

        isPatroling = true;
    }

    private void Update()
    {
        if (isPatroling)
        {
            nvAgent.SetDestination(playerTr.position);
            if (nvAgent.remainingDistance >= nvAgent.stoppingDistance)
            {
                WalkStart();
            }

            else
            {
                WalkStop();
            }
        }
    }

    public void PatrolStart()
    {
        isPatroling = true;
        nvAgent.isStopped = false;
    }

    public void PatrolStop()
    {
        isPatroling = false;
        nvAgent.isStopped = true;
    }

    private void WalkStart()
    {
        if (!BossStateManager.Instance.isWalking())
        {
            BossStateManager.Instance.SetMovementState(BossStateManager.MovementStates.Walk);
            FootSteps.Play();
        }
    }

    private void WalkStop()
    {
        if (BossStateManager.Instance.isWalking())
        {
            BossStateManager.Instance.SetMovementState(BossStateManager.MovementStates.Idle);
            FootSteps.Stop();
        }
    }
}
