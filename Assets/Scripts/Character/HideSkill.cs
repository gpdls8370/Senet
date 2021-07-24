using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSkill : MonoBehaviour
{
    private KeyCode HideKey;
    private CharacterMovement _characterMovement;
    private SpriteRenderer _spriteRenderer;

    public float HideSpeed;
    public float HideAlpha = 0.5f;

    private bool CanHide = false;
    private bool MustHide = false;
    private bool isExitTrigger = false;
    Collider2D collision;

    private void Awake()
    {
        HideKey = InputManager.Instance.Hide;
        _characterMovement = GetComponent<CharacterMovement>();
        HideSpeed = _characterMovement.WalkSpeed / 2;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(HideKey) && CanHide)
        {
            HideStart();
        }

        if (Input.GetKeyUp(HideKey) && StateManager.Instance.isHiding())
        {
            HideEnd();
        }

        if (MustHide && !StateManager.Instance.isHiding() && !StateManager.Instance.isDead())
        {
            StateManager.Instance.SetDead();
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        isExitTrigger = false;

        if (col.tag == "HideZone")
        {
            CanHide = true;
            if (col.GetComponentInParent<SleepCycle>().isAwake && !StateManager.Instance.isDead())
            {
                StateManager.Instance.SetDead();
            }
        }
        if (col.tag == "MustHideZone")
        {
            MustHide = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        isExitTrigger = true;

        collision = col;
        Invoke("ExitTrigger", 0.01f);
        
    }

    private void ExitTrigger()
    {
        if (isExitTrigger)
        {
            if (collision.tag == "HideZone")
            {
                CanHide = false;
                if (StateManager.Instance.isHiding())
                {
                    HideEnd();
                }
            }
            if (collision.tag == "MustHideZone")
            {
                MustHide = false;
            }
        }
    }

    private void HideStart()
    {
        _characterMovement.nowSpeed = HideSpeed;
        StateManager.Instance.SetSkillState(StateManager.SkillStates.Hide);
        _spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
    }

    private void HideEnd()
    {
        _characterMovement.nowSpeed = _characterMovement.WalkSpeed;
        StateManager.Instance.SetSkillState(StateManager.SkillStates.Idle);
        _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

}
