
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
            if (!_npcSentence.isChatting)
            {
                Invoke("PanelOn", 0.7f);
            }
            _npcSentence.TalkNpc();
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
