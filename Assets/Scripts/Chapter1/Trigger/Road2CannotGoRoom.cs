using UnityEngine;

public class Road2CannotGoRoom : MonoBehaviour
{
    private Teleport _teleport;

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
                _teleport.CanTeleport = false;
                UIManager.Instance.Panel_Enable(Chapter1Manager.Instance.Road2_RoomMoveTryPanel);
            }
            else
            {
                _teleport.CanTeleport = true;
                _teleport.TryTeleport();
            }
        }
    }

}
