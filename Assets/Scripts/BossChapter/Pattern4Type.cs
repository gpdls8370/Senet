﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BombArray
{
    public GameObject[] Bombs;
}

public class Pattern4Type : MonoBehaviour
{
    [SerializeField] private float ShowDelayTime;
    [SerializeField] private BombArray[] BombList;

    public void TypeActionStart()
    {
        StartCoroutine(TypeCoroutine());
    }

    private IEnumerator TypeCoroutine()
    {    
        for (int i = 0; i < BombList.Length; i++)
        {
            foreach (GameObject bomb in BombList[i].Bombs)
            {
                bomb.SetActive(true);
            }
            yield return new WaitForSeconds(ShowDelayTime);
        }
    }

    public float GetShowTime()
    {
        return BombList.Length * ShowDelayTime;
    }
}
