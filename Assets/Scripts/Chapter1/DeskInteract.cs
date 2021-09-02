
public class DeskInteract : InteractObject
{
    public bool isKeyDesk;
    private NpcSentence _npcSentence;

    private void Start()
    {
        _npcSentence = GetComponentInParent<NpcSentence>();
    }

    protected override void DoThis()
    {
        if (isKeyDesk)
        {
            Chapter1Manager.Instance.HaveKey = true;
            _npcSentence.TalkNpc();
            Invoke("PanelOn", 1.5f);
        }

        else
        {
            _npcSentence.TalkNpc();
        }
    }

    private void PanelOn()
    {
        UIManager.Instance.Panel_Enable(Chapter1Manager.Instance.FindKeyPanel);
    }
}
