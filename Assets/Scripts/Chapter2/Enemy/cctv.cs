using System.Collections;
using UnityEngine;

public class Cctv : MonoBehaviour
{
    private GameObject targetObj;
    public GameObject toObj;
    public Transform CameraMoveTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            targetObj = collision.gameObject;
            invoke("cctvon", 1.0f);
        }
    }

    public void cctvon()
    {
        if (collision.CompareTag("Plater"))
        {
            setDead();
        }
        invoke("cctvoff", 6.0f);
    }
    public void cctvoff()
    {
        invoke("cctvon", 1.0f);
    }
}
