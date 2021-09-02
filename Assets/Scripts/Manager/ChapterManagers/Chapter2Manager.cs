using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter2Manager : Singleton<Chapter2Manager>
{
    public Camera MainCamera;
    public float LightingTime;      //시작후 번개 친 다음 1초 쉬고, 다시 6초 뒤 번개 (번개치고 7초뒤 다시번개)
    [SerializeField] private GameObject DashIcon;

    [HideInInspector] public bool DashPopupOn = false;

    [Header("Panel")]
    public GameObject TrashCanInteract;
    public GameObject DashSkillGuide;
    public GameObject cctcDetected;
    public GameObject PasswordPanel;
    public GameObject PasswordFail;
    public GameObject PasswordSuccess;

    [Header("Card Back")]
    [SerializeField] private GameObject HeartBack;
    [SerializeField] private GameObject DiamondBack;
    [SerializeField] private GameObject SpadeBack;
    [SerializeField] private GameObject CloverBack;

    public void DashSkillIconOn()
    {
        DashIcon.SetActive(true);
    }

    public void SetHeartGet()
    {
        HeartBack.SetActive(false);
    }

    public void SetDiamondGet()
    {
        DiamondBack.SetActive(false);
    }

    public void SetSpadeGet()
    {
        SpadeBack.SetActive(false);
    }

    public void SetCloverGet()
    {
        CloverBack.SetActive(false);
    }
}
