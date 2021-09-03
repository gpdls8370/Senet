using System.Collections;
using UnityEngine;

public class HideSkill : MonoBehaviour
{
    private KeyCode HideKey;
    private CharacterMovement _characterMovement;
    private SpriteRenderer _spriteRenderer;
    private GameObject[] Sounds;

    [SerializeField] private float HideAlpha = 0.5f;
    private float HideSpeed;
    private bool soundChangeOnStart = false;
    private bool soundChangeOnEnd = false;

    [HideInInspector]
    public bool CanHide = false;
    [HideInInspector]
    public int HideZoneCount = 0;
    
    private void Awake()
    {
        HideKey = InputManager.Instance.Hide;
        _characterMovement = GetComponent<CharacterMovement>();
        HideSpeed = _characterMovement.WalkSpeed / 2;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        Sounds = new GameObject[GameObject.Find("Sounds").transform.childCount];
        for(int i = 0; i < Sounds.Length; i++)
        {
            Sounds[i] = GameObject.Find("Sounds").transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        if (Input.GetKey(HideKey) && CanHide)
        {
            HideStart();
        }

        if (Input.GetKeyUp(HideKey) && StateManager.Instance.isHiding())
        {
            HideEnd();
        }

        if (StateManager.Instance.isHiding() && !CanHide && HideZoneCount == 0)
        {
            HideEnd();
        }

        if (CanHide)
        {
            UIManager.Instance.skillBox.HideIconEnable();
        }
        else
        {
            UIManager.Instance.skillBox.HideIconUnable();
        }
    }

    private void HideStart()
    {
        _characterMovement.nowSpeed = HideSpeed;
        StateManager.Instance.SetPlayerState(StateManager.SkillStates.Hide);
        _spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);

        if (!soundChangeOnStart)
        {
            soundChangeOnEnd = false;

            foreach (GameObject sound in Sounds)
            {
                float f = sound.GetComponent<AudioSource>().volume / 2;
                sound.GetComponent<AudioSource>().volume = f;
            }
            soundChangeOnStart = true;
        }
    }

    public void HideEnd()
    {

        _characterMovement.nowSpeed = _characterMovement.WalkSpeed;
        StateManager.Instance.SetPlayerState(StateManager.SkillStates.Idle);
        _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);

        if (!soundChangeOnEnd)
        {
            soundChangeOnStart = false;

            foreach (GameObject sound in Sounds)
            {
                float f = sound.GetComponent<AudioSource>().volume * 2;
                sound.GetComponent<AudioSource>().volume = f;
            }
            soundChangeOnEnd = true;
        }
    }

}
