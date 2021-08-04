using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject targetObj;
    public GameObject toObj;
    public Transform CameraMoveTo;

    public bool CanTeleport;
    
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetObj = collision.gameObject;
            TryTeleport();
            
        }
    }

    public void TryTeleport()
    {
        if (CanTeleport)
        {
            StartCoroutine(TeleportRoutine());
        }
    }

    IEnumerator TeleportRoutine()
    {
        yield return null;
        targetObj.transform.position = toObj.transform.position;
        Camera.main.transform.position = new Vector3(CameraMoveTo.position.x, CameraMoveTo.position.y, -30);
    }

}
