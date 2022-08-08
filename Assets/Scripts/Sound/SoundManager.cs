using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicSource, effectsSource;

    public AudioSource MusicSource { get { return musicSource; } set { musicSource = value; } }
    public AudioSource EffectsSource { get { return effectsSource; } set { effectsSource = value; } }

    [Header("Gameplay")]
    public AudioClip HitSound;
    public AudioClip DieSound;
    public AudioClip JumpSound;
    public AudioClip landSound;
    public AudioClip buttonSound;

    [Header("SoundTrack")]
    public AudioClip mainMenuTheme;
    public AudioClip inGameTheme;

    [Header("Sliders")]
    public Slider fxSlider;
    public TextMeshProUGUI fxValueText;
    public Slider musicSlider;
    public TextMeshProUGUI musicValueText;

    void Start()
    {
        effectsSource.volume = fxSlider.value/100;
        musicSource.volume = musicSlider.value/100;
        fxValueText.text = fxSlider.value.ToString();
        musicValueText.text = musicSlider.value.ToString();
        PlayLoop(inGameTheme);
    }

    public void PlaySound(AudioClip clip)
    {
        effectsSource.clip = clip;
        effectsSource.Play();
    }

    public void PlayLoop(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void SetEffectsVolume(float volume)
    {
        EffectsSource.volume = volume / 100;
        fxValueText.text = volume.ToString();
    }

    public void SetMusicVolume(float mVolume)
    {
        MusicSource.volume = mVolume / 100;
        musicValueText.text = mVolume.ToString();
    }
}