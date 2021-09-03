using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    public AudioClip[] bglist;
    private AudioSource audiosource;
    private GameObject go;

    public static SoundManager instance;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SFXPlay(string sfxName,AudioClip clip)
    {
        if (sfxName != "thunder")
        {
            go = new GameObject(sfxName + "Sound");
            audiosource = go.AddComponent<AudioSource>();
            audiosource.clip = clip;
            audiosource.Play();
            Destroy(go, clip.length);
        }
        else
        {
            audiosource = GameObject.Find("thunderSound").GetComponent<AudioSource>();
            audiosource.Play();
        }    
    }
}