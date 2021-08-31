using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBackSkill : MonoBehaviour
{
    private KeyCode TimeBackSaveKey;
    private KeyCode TimeBackKey;

    [SerializeField] private float SkillCooltime;
    [SerializeField] private SpriteRenderer SavePosIcon;
    [SerializeField] private ParticleSystem BackEffect;

    [Header("Player Image")]
    [SerializeField] private Sprite Front;
    [SerializeField] private Sprite Back;
    [SerializeField] private Sprite Left;
    [SerializeField] private Sprite Right;

    private bool Saved;
    private bool CanTimeBack;
    private Vector3 savePos;
    private CharacterMovement _characterMovement;

    private void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        TimeBackKey = InputManager.Instance.TimeBack;
        TimeBackSaveKey = InputManager.Instance.TimeBackSave;
        CanTimeBack = true;
        Saved = false;
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
            Saved = false;
            transform.position = savePos;
            StartCoroutine(CooltimeCoroutine());

            SavePosIcon.gameObject.SetActive(false);

            BackEffect.transform.position = savePos;
            StartCoroutine(EffectCoroutine());
        }
    }

    private IEnumerator CooltimeCoroutine()
    {
        CanTimeBack = false;

        yield return new WaitForSeconds(SkillCooltime);

        CanTimeBack = true;
    }

    private IEnumerator EffectCoroutine()
    {
        BackEffect.gameObject.SetActive(true);
        BackEffect.Play();

        yield return new WaitForSeconds(0.3f);

        BackEffect.Stop();
        BackEffect.gameObject.SetActive(false);
    }
}
