using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternBase : MonoBehaviour
{
    [SerializeField] protected Animator BossAnimator;
    protected bool goUp = false;
    protected bool goDown = false;
    private float goTime = 0f;
    private Vector2 newPosition;

    protected virtual void Update()
    {
        if (goUp)
        {
            if (goTime < 2)
            {
                newPosition = Vector2.Lerp(BossAnimator.transform.position, new Vector2(0, 3), goTime / 2) ;
                goTime += Time.deltaTime;
                BossAnimator.transform.position = newPosition;
            }
            else
            {
                goUp = false;
            }
        }

        if (goDown)
        {
            if (goTime < 2)
            {
                newPosition = Vector2.Lerp(BossAnimator.transform.position, new Vector2(0, 0), goTime / 2);
                goTime += Time.deltaTime;
                BossAnimator.transform.position = newPosition;
            }
            else
            {
                goDown = false;
            }
        }
    }

    protected void SwitchStretch()
    {
        ResetTrigger();
        goTime = 0f;
        goUp = true;
        BossAnimator.SetTrigger("Stretch");
    }

    protected void SwitchIdle()
    {
        ResetTrigger();
        goTime = 0f;
        goDown = true;
        BossAnimator.SetTrigger("Idle");   
    }

    protected void SwitchThrow()
    {
        ResetTrigger();
        BossAnimator.SetTrigger("Throw");
    }

    public virtual void StartPattern()
    {

    }

    public virtual void StopPattern()
    {
        Reset();
    }

    public virtual void Reset()
    {
        
    }
    private void ResetTrigger()
    {
        BossAnimator.ResetTrigger("Idle");
        BossAnimator.ResetTrigger("Stretch");
        BossAnimator.ResetTrigger("Throw");
    }
}
