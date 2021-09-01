using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBox : MonoBehaviour
{
    public GameObject HideIcon;

    public Image HideIconImage;
    public Image DashIconImage;
    public Image TimebackIconImage;

    public float BoxUnableAlpha = 0.3f;

    public void HideIconEnable()
    {
        HideIcon.SetActive(true);
        HideIcon.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void HideIconUnable()
    {
        HideIcon.SetActive(true);
        HideIcon.GetComponent<Image>().color = new Color(1f, 1f, 1f, BoxUnableAlpha);
    }
}
