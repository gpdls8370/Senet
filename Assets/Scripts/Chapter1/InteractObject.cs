using UnityEngine;

public class InteractObject : MonoBehaviour
{
    private bool trigger = false;

    private void Update()
    {
        if (trigger && Input.GetKeyDown(InputManager.Instance.Interaction))
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
        //상호작용 시에 할 행동
    }
}
