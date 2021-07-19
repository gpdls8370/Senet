using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRun : MonoBehaviour
{
    private KeyCode runKey;
    private CharacterMovement _characterMovement;
    private Animator animator;

    void Awake()
    {
        runKey = InputManager.Instance.Run;
        _characterMovement = GetComponent<CharacterMovement>();
        animator = _characterMovement.animator;
    }


    void Update()
    {
        if (Input.GetKey(runKey))
        {
            if (_characterMovement.isMoving)
            {
                RunStart();
            }
        }
        if (Input.GetKeyUp(runKey))
        {
            RunStop();
        }
    }

    private void RunStart()
    {
        animator.SetBool("Running", true);
        _characterMovement.nowSpeed = _characterMovement.RunSpeed;
    }

    private void RunStop()
    {
        animator.SetBool("Running", false);
        _characterMovement.nowSpeed = _characterMovement.WalkSpeed;
    }
}
