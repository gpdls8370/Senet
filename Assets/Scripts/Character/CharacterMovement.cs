using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private KeyCode leftMoveKey;
    private KeyCode rightMoveKey;
    private KeyCode upMoveKey;
    private KeyCode downMoveKey;
    private Vector2 movement;
    private Rigidbody2D rb;
    public ParticleSystem FootSteps;


    [Header("Speed")]
    public float WalkSpeed;
    public float RunSpeed;
    
    [HideInInspector]
    public float nowSpeed;
    [HideInInspector]
    public Vector2 moveDirection;
    [HideInInspector]
    public bool isMoving = false;


    void Awake()
    {
        leftMoveKey = InputManager.Instance.LeftMove;
        rightMoveKey = InputManager.Instance.RightMove;
        upMoveKey = InputManager.Instance.UpMove;
        downMoveKey = InputManager.Instance.DownMove;
        nowSpeed = WalkSpeed;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void FixedUpdate()
    {
        movement = Vector2.zero;

        if (Input.GetKey(leftMoveKey))
        {
            movement.x -= nowSpeed;
            transform.localScale = new Vector3(1, 1, 1);   //왼쪽 바라보기
        }
        if (Input.GetKey(rightMoveKey))
        {
            movement.x += nowSpeed;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(upMoveKey))
        {
            movement.y += nowSpeed;
        }
        if (Input.GetKey(downMoveKey))
        {
            movement.y -= nowSpeed;
        }

        if (movement != Vector2.zero)
        {
            WalkStart();
        }
        else
        {
            WalkStop();
        }
    }

    private void WalkStart()
    {
        isMoving = true;

        if (!StateManager.Instance.isRunning() && !StateManager.Instance.isWalking())
        {
            StateManager.Instance.SetPlayerState(StateManager.PlayerStates.Walk);
        }
        rb.position += movement;
        moveDirection = movement.normalized;
        FootSteps.Play();
    }

    private void WalkStop()
    {
        isMoving = false;
        StateManager.Instance.SetPlayerState(StateManager.PlayerStates.Idle);
        FootSteps.Stop();
    }
}
