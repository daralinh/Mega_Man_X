using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----Audio Source----")]
    [SerializeField] AudioSource Background;
    [SerializeField] AudioSource SFX;

    [Header("----Audio Clip----")]
    public AudioClip IntroMenu;
    public AudioClip BackgrondGamePlay;
    public AudioClip death;

    public void PlaySFX(AudioClip audio)
    {
        SFX.PlayOneShot(audio);
    }

    public void PlayBackground(AudioClip audio)
    {
        Background.clip = audio;
        Background.Play();
    }
}
