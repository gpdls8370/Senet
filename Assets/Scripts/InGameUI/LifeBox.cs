using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBox : MonoBehaviour
{
    private GameObject[] Lifes;
    private int nowActiveLife;

    private void Start()
    {
        Lifes = new GameObject[PlayerManager.Instance.MaxLife];
        nowActiveLife = PlayerManager.Instance.MaxLife;

        for (int i = 0; i < Lifes.Length; i++)
        {
            Lifes[i] = gameObject.transform.GetChild(i).gameObject;
            Lifes[i].SetActive(true);
        }
    }

    public void LoseLife(int damage)
    {
        for (int i = 0; i < damage; i++)
        {
            Lifes[nowActiveLife - 1 - damage].SetActive(false);
        }

        nowActiveLife -= damage;
    }

}
