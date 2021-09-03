using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : Singleton<StateManager>
{
    public enum MovementStates { Idle, Walk, Run, Dead }
    public enum SkillStates { Idle, Hide }
    public MovementStates nowMovementState;
    public SkillStates nowSkillState;

    public GameObject Player;
    private Animator animator;
    private Image GameoverImage;

    protected override void Awake()
    {
        base.Awake();
        animator = Player.GetComponentInChildren<Animator>();
        GameoverImage = UIManager.Instance.GameoverPanel.GetComponent<Image>();
        Resume();
        PlayerResume();
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

        UIManager.Instance.GameoverPanel.SetActive(true);
        UIManager.Instance.GameoverPanel.transform.GetChild(0).gameObject.SetActive(false);
        UIManager.Instance.GameoverPanel.transform.GetChild(1).gameObject.SetActive(false);
        PlayerPause();
        StartCoroutine(FadeCoroutine());
 
        //UIManager.Instance.Panel_Enable(UIManager.Instance.GameoverPanel);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PlayerPause();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PlayerResume();
    }

    public void PlayerPause()
    {
        Player.GetComponent<CharacterMovement>().enabled = false;
        Player.GetComponent<CharacterDash>().enabled = false;
        Player.GetComponent<BoxCollider2D>().enabled = false;
        SetMovementState(MovementStates.Idle);
    }

    public void PlayerResume()
    {
        Player.GetComponent<CharacterMovement>().enabled = true;
        Player.GetComponent<CharacterDash>().enabled = true;
        Player.GetComponent<BoxCollider2D>().enabled = true;
    }

    public bool isWalking() { return nowMovementState == MovementStates.Walk; }
    public bool isRunning() { return nowMovementState == MovementStates.Run; }
    public bool isHiding() { return nowSkillState == SkillStates.Hide; }
    public bool isDead() { return nowMovementState == MovementStates.Dead; }

    private IEnumerator FadeCoroutine()
    {
        Debug.Log("11");
        float fadeCount = 0;
        while(fadeCount < 1.0f)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);
            GameoverImage.color = new Color(1, 1, 1, fadeCount);
        }

        UIManager.Instance.GameoverPanel.transform.GetChild(0).gameObject.SetActive(true);
        UIManager.Instance.GameoverPanel.transform.GetChild(1).gameObject.SetActive(true);
        Pause();
    }

}
