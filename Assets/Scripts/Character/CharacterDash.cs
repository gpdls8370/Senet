using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDash : MonoBehaviour
{
    private InputManager _inputManager;
    private KeyCode dashKey;

    private CharacterMovement _characterMovement;

    private bool isDashing = false;
    private float dashTime;
    private Vector3 dashDestination;
    private Vector3 newPosition;

    [Header("Dash")]
    public float DashDuration;
    public float DashDistance;


    void Awake()
    {
        _inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
        dashKey = _inputManager.Dash;
        _characterMovement = GetComponent<CharacterMovement>();
    }


    void Update()
    {
        if (Input.GetKeyDown(dashKey))
        {
            DashStart();
        }

        if (isDashing)
        {
            if (dashTime < DashDuration)
            {
                newPosition = Vector3.Lerp(this.transform.position, dashDestination, 0.1f);
                dashTime += Time.deltaTime;
                this.transform.position = newPosition;
            }
            else
            {
                isDashing = false;
            }
        }
    }

    private void DashStart()
    {
        isDashing = true;
        dashTime = 0f;
        dashDestination = this.transform.position + _characterMovement.moveDirection * DashDistance;
    }

}
