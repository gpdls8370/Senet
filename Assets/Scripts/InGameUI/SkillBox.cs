using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBox : MonoBehaviour
{
    public GameObject HideIcon;
    public Image HideIconImage;

    public GameObject DashIcon;
    public Image DashIconImage;

    public Image TimebackIconImage;

    public float BoxUnableAlpha = 0.3f;

    public void HideIconEnable()
    {
        HideIcon.SetActive(true);
        HideIconImage.color = new Color(1f, 1f, 1f, 1f);
    }

    public void HideIconUnable()
    {
        if(BoxUnableAlpha == 0)
        {
            HideIcon.SetActive(false);
        }
        else
        {
            HideIcon.SetActive(true);
            HideIconImage.color = new Color(1f, 1f, 1f, BoxUnableAlpha);
        }
    }
}
