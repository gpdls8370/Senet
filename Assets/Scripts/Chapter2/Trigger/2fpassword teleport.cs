using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 2fpasswordteleport : MonoBehaviour
{
     private bool trigger = false;

    private void Update()
    {
        if (trigger == true && Input.GetKeyDown(InputManager.Instance.Interaction) && 2fpassword==true )
        {
            DoThis();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            trigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger = false;
    }

    protected virtual void DoThis()
    {
    
    }

}
