using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    [Header("---- Audio ----")]
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider backgroundSlider;
    [SerializeField] private Slider sFXSlider;

    [Header("---- Audio Source ----")]
    [SerializeField] private AudioSource BackgroundSourece;
    [SerializeField] private AudioSource SFXSourece;

    [Header("---- Background music ----")]
    public AudioClip IntroMenu;
    public AudioClip BackgrondGamePlay;

    [Header("---- SFX ----")]
    public AudioClip death;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        backgroundSlider.onValueChanged.AddListener(ChangeVolumeBackground);
        sFXSlider.onValueChanged.AddListener(ChangeVolumeSFX);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        backgroundSlider.value = 1;
        sFXSlider.value = 1;
    }

    public void PlaySFX(AudioClip audio)
    {
        SFXSourece.PlayOneShot(audio);
    }

    public void PlayBackground(AudioClip audio)
    {
        BackgroundSourece.clip = audio;
        BackgroundSourece.Play();
    }

    public void StopSFX()
    {
        SFXSourece.Stop();
    }

    public void StopBackground()
    {
        BackgroundSourece.Stop();
    }

    public void ChangeVolumeBackground(float value)
    {
        BackgroundSourece.volume = value;
    }

    public void ChangeVolumeSFX(float value)
    {
        SFXSourece.volume = value;
    }
}
