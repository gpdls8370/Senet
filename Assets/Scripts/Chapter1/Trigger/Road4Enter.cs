using UnityEngine;

public class Road4Enter : MonoBehaviour
{
    public bool Entered = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !Entered)
        {
            Entered = true;
            UIManager.Instance.Panel_Enable(Chapter1Manager.Instance.Road4_EnterPanel);
        }
    }
}
