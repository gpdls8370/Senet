using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private GameObject targetObj;
    public GameObject toObj;
    public Transform CameraMoveTo;

    public bool CanTeleport;

    [SerializeField] private bool StageMove = false;
    [SerializeField] private string StageName;
    
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
            if (StageMove)
            {
                SceneManager.LoadScene(StageName);
            }
            else
            {
                StartCoroutine(TeleportRoutine());
            }
        }
    }

    IEnumerator TeleportRoutine()
    {
        yield return null;
        targetObj.transform.position = new Vector3(toObj.transform.position.x, toObj.transform.position.y, 0);

        if (Chapter1Manager.Instance != null)
        {
            Chapter1Manager.Instance.MainCamera.transform.position = new Vector3(CameraMoveTo.position.x, CameraMoveTo.position.y, CameraMoveTo.position.z);
        }

        else if (Chapter2Manager.Instance != null)
        {
            Chapter2Manager.Instance.MainCamera.transform.position = new Vector3(CameraMoveTo.position.x, CameraMoveTo.position.y, CameraMoveTo.position.z);
        }
    }

    public void MovePlayer()
    {
        targetObj = StateManager.Instance.Player;
        if (ChapterManager.Instance != null)
        {
            ChapterManager.Instance.SetChapter3Available();
        }
        StartCoroutine(TeleportRoutine());
    }

}
