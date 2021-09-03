using System.Collections;
using UnityEngine;

public class Road2CannotGoRoom : MonoBehaviour
{
    private Teleport _teleport;
    private bool PanelOn;

    private void Start()
    {
        _teleport = GetComponent<Teleport>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (!Chapter1Manager.Instance.RockDoorFounded)
            {
                if (!PanelOn)
                {
                    _teleport.CanTeleport = false;
                    UIManager.Instance.Panel_Enable(Chapter1Manager.Instance.Road2_RoomMoveTryPanel);
                    StartCoroutine(PanelOffCoroutine());
                }
            }
            else
            {
                _teleport.CanTeleport = true;
                _teleport.TryTeleport();
            }
        }
    }

    private IEnumerator PanelOffCoroutine()
    {
        PanelOn = true;
        yield return new WaitForSeconds(1f);
        PanelOn = false;
    }

}
