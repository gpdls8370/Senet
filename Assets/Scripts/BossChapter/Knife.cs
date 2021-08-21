using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float WaitBeforeAttackTime;
    [SerializeField] private float AttackDelay;
    [SerializeField] private float AttackSpeed;

    private enum KnifeType { GrayKnife, BlackKnife }
    [SerializeField] private KnifeType knifeType;

    private CharacterMovement _characterMovement;
    private Transform playerTr;
    private Vector3 direction;
    private Vector3 targetPos;

    public bool UseWaitingPos = false;
    public Transform waitingPos;
    
    private Quaternion targetRotation;
    private float LookSpeed = 500;

    private bool Patroling = false;
    private bool Attacking = false;

    private void Awake()
    {
        playerTr = PlayerManager.Instance.Player.transform;
        _characterMovement = PlayerManager.Instance.Player.GetComponent<CharacterMovement>();
    }

    private void OnEnable()
    {
        StartCoroutine(WaitAttack());
    }

    private void Update()
    {
        if (Patroling)
        {
            DirectionPatrol();
        }
        else
        {
            if (Attacking)
            {
                AttackPlayer();
            }
        }
    }

    private void DirectionPatrol()
    {
        targetPos = playerTr.position;

        if (UseWaitingPos)
        {
            transform.position = waitingPos.position;
        }

        direction = targetPos - transform.position;
        targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, LookSpeed * Time.deltaTime);
    }

    private IEnumerator WaitAttack()
    {
        Patroling = true;

        yield return new WaitForSeconds(WaitBeforeAttackTime);

        Patroling = false;

        yield return new WaitForSeconds(AttackDelay);

        Attacking = true;
    }

    private void AttackPlayer()
    {
        transform.position = Vector2.Lerp(transform.position, targetPos, AttackSpeed);

        //공격 끝났을 때
        if (transform.position.x <= targetPos.x + 0.1f && transform.position.x >= targetPos.x - 0.1f
            && transform.position.y <= targetPos.y + 0.1f && transform.position.y >= targetPos.y - 0.1f)
        {
            Attacking = false;

            if (knifeType == KnifeType.GrayKnife)
            {
                if (!_characterMovement.isMoving)
                {
                    PlayerManager.Instance.LoseLife(1);
                }

            }

            if (knifeType == KnifeType.BlackKnife)
            {
                if (_characterMovement.isMoving)
                {
                    PlayerManager.Instance.LoseLife(1);
                }
            }

            Invoke("DeleteKnife", 1);
        }
    }

    private void DeleteKnife()
    {
        GetComponentInParent<Pattern2>().StopPattern();
        gameObject.SetActive(false);
    }


    public void Reset()
    {
        Patroling = false;
        Attacking = false;
    }
}
