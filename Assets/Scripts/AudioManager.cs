using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------------- Audio Source -----------------")]
    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxSource;

    [Header("------------------- Audio Clip -----------------")]
    public AudioClip bgm;
    public AudioClip gameOver;
    public AudioClip jump;
    public AudioClip scoring;

    private void Start()
    {
        bgmSource.clip = bgm;
        bgmSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }


}
