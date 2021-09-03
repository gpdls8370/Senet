
public class Road2DoorFind : InteractObject
{
    public bool isRocked = true;

    private Teleport _teleport;

    private void Start()
    {
        _teleport = GetComponent<Teleport>();
    }

    protected override void DoThis()
    {
        if (isRocked)
        {
            if (Chapter1Manager.Instance.HaveKey)
            {
                Chapter1Manager.Instance.RedLight.SetActive(false);
                Chapter1Manager.Instance.YellowLight.SetActive(true);
                isRocked = false;
                ChapterManager.Instance.Chapter1ClearDoor = true;
            }
            else
            {
                Chapter1Manager.Instance.RockDoorFounded = true;
                UIManager.Instance.Panel_Enable(Chapter1Manager.Instance.Road2_DoorFindPanel);
            }
        }
        else
        {
            _teleport.CanTeleport = true;
            _teleport.TryTeleport();
        }
    }
}
