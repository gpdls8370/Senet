using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private InputManager _inputManager;
    private KeyCode leftMoveKey;
    private KeyCode rightMoveKey;
    private KeyCode upMoveKey;
    private KeyCode downMoveKey;

    private Vector3 movement;

    [Header("Speed")]
    public float WalkSpeed;
    
    [HideInInspector]
    public float nowSpeed;
    [HideInInspector]
    public Vector3 moveDirection;


    void Awake()
    {
        _inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
        leftMoveKey = _inputManager.LeftMove;
        rightMoveKey = _inputManager.RightMove;
        upMoveKey = _inputManager.UpMove;
        downMoveKey = _inputManager.DownMove;
        nowSpeed = WalkSpeed;
    }

    void Update()
    {
        movement = Vector3.zero;

        if (Input.GetKey(leftMoveKey))
        {
            movement.x -= nowSpeed;
        }
        if (Input.GetKey(rightMoveKey))
        {
            movement.x += nowSpeed;
        }
        if (Input.GetKey(upMoveKey))
        {
            movement.y += nowSpeed;
        }
        if (Input.GetKey(downMoveKey))
        {
            movement.y -= nowSpeed;
        }

        transform.transform.Translate(movement);
        moveDirection = movement.normalized;
    }
}
