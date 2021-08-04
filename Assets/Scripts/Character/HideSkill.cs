using System.Collections;
using UnityEngine;

public class HideSkill : MonoBehaviour
{
    private KeyCode HideKey;
    private CharacterMovement _characterMovement;
    private SpriteRenderer _spriteRenderer;

    public float HideSpeed;
    public float HideAlpha = 0.5f;

    [HideInInspector]
    public bool CanHide = false;
    public int HideZoneCount = 0;

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

        if (StateManager.Instance.isHiding() && !CanHide && HideZoneCount == 0)
        {
            HideEnd();
        }
    }

    private void HideStart()
    {
        _characterMovement.nowSpeed = HideSpeed;
        StateManager.Instance.SetPlayerState(StateManager.SkillStates.Hide);
        _spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
    }

    public void HideEnd()
    {
        _characterMovement.nowSpeed = _characterMovement.WalkSpeed;
        StateManager.Instance.SetPlayerState(StateManager.SkillStates.Idle);
        _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

}
