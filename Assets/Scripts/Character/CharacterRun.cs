using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRun : MonoBehaviour
{
    private KeyCode runKey;
    private CharacterMovement _characterMovement;

    void Awake()
    {
        runKey = InputManager.Instance.Run;
        _characterMovement = GetComponent<CharacterMovement>();
    }


    void Update()
    {
        if (Input.GetKey(runKey)) 
        {
            if (_characterMovement.isMoving && !StateManager.Instance.isHiding())
            {
                RunStart();
            }
        }
        if (Input.GetKeyUp(runKey) && StateManager.Instance.isRunning())
        {
            RunStop();
        }
    }

    private void RunStart()
    {
        StateManager.Instance.SetMovementState(StateManager.MovementStates.Run);
        _characterMovement.nowSpeed = _characterMovement.RunSpeed;
    }

    private void RunStop()
    {
        StateManager.Instance.SetMovementState(StateManager.MovementStates.Idle);
        _characterMovement.nowSpeed = _characterMovement.WalkSpeed;
    }
}
