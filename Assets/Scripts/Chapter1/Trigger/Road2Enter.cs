using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road2Enter : MonoBehaviour
{
    public bool Entered = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !Entered)
        {
            Entered = true;
            UIManager.Instance.Panel_Enable(UIManager.Instance.Road2_EnterPanel);
        }
    }
}
