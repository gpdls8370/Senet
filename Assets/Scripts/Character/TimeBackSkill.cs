using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBackSkill : MonoBehaviour
{
    private KeyCode TimeBackSaveKey;
    private KeyCode TimeBackKey;

    public AudioClip clip;  

    [SerializeField] private float Cooltime;
    [SerializeField] private SpriteRenderer SavePosIcon;
    [SerializeField] private Animator BackEffect;

    [Header("Player Image")]
    [SerializeField] private Sprite Front;
    [SerializeField] private Sprite Back;
    [SerializeField] private Sprite Left;
    [SerializeField] private Sprite Right;

    private bool Saved;
    private bool CanTimeBack;
    private Vector3 savePos;
    private CharacterMovement _characterMovement;
    private float CooltimeCounter;

    private void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        TimeBackKey = InputManager.Instance.TimeBack;
        TimeBackSaveKey = InputManager.Instance.TimeBackSave;
        CanTimeBack = true;
        Saved = false;
        CooltimeCounter = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(TimeBackSaveKey))
        {
            Saved = true;
            savePos = transform.position;

            SavePosIcon.transform.position = savePos;
            SavePosIcon.gameObject.SetActive(true);

            
            
            if (_characterMovement.moveDirection.y < - 0.99)
            {
                SavePosIcon.sprite = Front;
            }
            else if (_characterMovement.moveDirection.y > 0.99)
            {
                SavePosIcon.sprite = Back;
            }
            else if (_characterMovement.moveDirection.x < - 0.5f)
            {
                SavePosIcon.sprite = Left;
            }
            else
            {
                SavePosIcon.sprite = Right;
            }
        }

        if (Input.GetKeyDown(TimeBackKey) && CanTimeBack && Saved)
        {
            SoundManager.instance.SFXPlay("return", clip);

            Saved = false;
            transform.position = savePos;
            StartCoroutine(CooltimeCoroutine());

            SavePosIcon.gameObject.SetActive(false);

            BackEffect.transform.position = new Vector3(savePos.x, savePos.y - 2, savePos.z);
            StartCoroutine(EffectCoroutine());
        }

        if (CooltimeCounter >= 0)
        {
            CooltimeCounter -= Time.deltaTime;

            if (UIManager.Instance.skillBox.TimebackIconImage != null)
            {
                UIManager.Instance.skillBox.TimebackIconImage.fillAmount = 1 - CooltimeCounter / Cooltime;
            }
        }
    }

    private IEnumerator CooltimeCoroutine()
    {
        CanTimeBack = false;
        CooltimeCounter = Cooltime;

        yield return new WaitForSeconds(Cooltime);

        CanTimeBack = true;
    }

    private IEnumerator EffectCoroutine()
    {
        BackEffect.gameObject.SetActive(true);
        BackEffect.SetTrigger("Active");
        StateManager.Instance.PlayerPause();

        yield return new WaitForSeconds(0.3f);
        StateManager.Instance.PlayerResume();

        yield return new WaitForSeconds(0.4f);
        BackEffect.gameObject.SetActive(false);
    }
}
