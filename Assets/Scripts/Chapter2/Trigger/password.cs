using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private string answer = "hope";

    public void EnterPassword()
    {
        if (inputField.text == answer)
        {
            UIManager.Instance.Panel_Enable(Chapter2Manager.Instance.PasswordSuccess);
            ChapterManager.Instance.Chapter2ClearDoor = true;
        }
        else
        {
            UIManager.Instance.Panel_Enable(Chapter2Manager.Instance.PasswordFail);
        }
    }
}

