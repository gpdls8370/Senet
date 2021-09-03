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
                if (StageName == "chap2 after" && ChapterManager.Instance != null) 
                {
                    ChapterManager.Instance.SetChapter3Available();
                }
            }
            else
            {
                StartCoroutine(TeleportRoutine());
            }
        }
    }

    private IEnumerator TeleportRoutine()
    {
        yield return null;
        targetObj.transform.position = new Vector3(toObj.transform.position.x, toObj.transform.position.y, 0);

        if (Chapter1Manager.Instance != null)
        {
            Chapter1Manager.Instance.MainCamera.transform.position = new Vector3(CameraMoveTo.position.x, CameraMoveTo.position.y, -20);
        }

        else if (Chapter2Manager.Instance != null)
        {
            Chapter2Manager.Instance.MainCamera.transform.position = new Vector3(CameraMoveTo.position.x, CameraMoveTo.position.y, -20);
        }
    }

    public void MovePlayer()
    {
        targetObj = StateManager.Instance.Player;
        StartCoroutine(TeleportRoutine());
    }

}
