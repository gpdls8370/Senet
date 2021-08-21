using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayEyeZone : MonoBehaviour
{
    private bool PlayerOn = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Invoke("PlayerOut", 0.1f);
        }
    }

    private void PlayerOut()
    {
        PlayerOn = false;
    }


    private void OnDisable()
    {
        if (!PlayerOn)
        {
            PlayerManager.Instance.LoseLife(1);
        }
    }

}
