using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] private Button MoveChapterBt;

    private void Awake()
    {
        if (ChapterManager.Instance.MoveChapterScene_Unlock)
        {
            MoveChapterBt.interactable = true;
        }
        else
        {
            MoveChapterBt.interactable = false;
        }
    }
}
