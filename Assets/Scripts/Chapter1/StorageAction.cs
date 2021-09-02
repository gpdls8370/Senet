using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorageAction : MonoBehaviour
{
    private bool isAction = false;
    private Vector3 newPosition;
    private float TimeCount;
    [SerializeField] private Transform targetPos;
    [SerializeField] private Transform Top;
    [SerializeField] private Transform Buttom;
    [SerializeField] private Transform topTargetPos;
    [SerializeField] private Transform buttomTargetPos;

    private void Update()
    {
        if (isAction)
        { 
            newPosition = Vector2.Lerp(StateManager.Instance.Player.transform.position, targetPos.position, TimeCount / 1000);
            TimeCount += Time.deltaTime;
            StateManager.Instance.Player.transform.position = newPosition;
           
            if (TimeCount < 4)
            {
                Top.position = Vector2.Lerp(Top.position, topTargetPos.position, TimeCount / 2000);
                Buttom.position = Vector2.Lerp(Buttom.position, buttomTargetPos.position, TimeCount / 2000);
            }

            if (TimeCount > 5.5f)
            {
                isAction = false;
                StateManager.Instance.Player.GetComponentInChildren<Animator>().SetTrigger("WalkEnd");
                Invoke("MoveScene", 2f);
            }
        }
    }

    private void MoveScene()
    {
        StateManager.Instance.PlayerResume();
        if (ChapterManager.Instance != null)
        {
            ChapterManager.Instance.SetChapter2Available();
        }
        SceneManager.LoadScene("chap1 after");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StateManager.Instance.PlayerPause();
            StateManager.Instance.Player.GetComponentInChildren<Animator>().SetTrigger("BackWalk");
            isAction = true;
        }
    }


}
