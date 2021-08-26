using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float BombDealyAfterFall;
    [SerializeField] private bool Illusion;

    private bool PlayerOn;

    private void OnEnable()
    {
        StartCoroutine(BombTimeCoroutine());
        //떨어지는 애니메이션
    }

    private IEnumerator BombTimeCoroutine()
    {
        yield return new WaitForSeconds(BombDealyAfterFall);

        //터지는 애니메이션

        if (!Illusion && PlayerOn)
        {
            PlayerManager.Instance.LoseLife(1);
        }

        //터진 후 딜레이 필요하면 넣기

        gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerOn = false;
        }
    }

    private void OnDisable()
    {
        PlayerOn = false;
    }

}
