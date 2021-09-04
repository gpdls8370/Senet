using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterSceneManager : MonoBehaviour
{
    [SerializeField] private Button Chapter1Bt;
    [SerializeField] private Button Chapter2Bt;
    [SerializeField] private Button Chapter3Bt;

    private void Awake()
    {
        if (ChapterManager.Instance.Chapter1_Unlock)
        {
            Chapter1Bt.interactable = true;
        }
        else
        {
            Chapter1Bt.interactable = false;
        }

        if (ChapterManager.Instance.Chapter2_Unlock)
        {
            Chapter2Bt.interactable = true;
        }
        else
        {
            Chapter2Bt.interactable = false;
        }

        if (ChapterManager.Instance.Chapter3_Unlock)
        {
            Chapter3Bt.interactable = true;
        }
        else
        {
            Chapter3Bt.interactable = false;
        }
    }

    public void SaveReset()
    {
        ChapterManager.Instance.Chapter1ClearDoor = false;
        ChapterManager.Instance.Chapter2ClearDoor = false;
    }
}
