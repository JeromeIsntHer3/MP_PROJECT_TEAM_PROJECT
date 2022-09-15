using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public SettingsData settings;

    [SerializeField]
    private AudioSource musicSource, effectsSource;

    [Header("Gameplay")]
    public AudioClip JumpSound;
    public AudioClip buttonSound;

    [Header("SoundTrack")]
    public AudioClip mainMenuTheme;
    public AudioClip inGameTheme;

    [Header("Sliders")]
    public Slider effectsSlider;
    public TextMeshProUGUI fxValueText;
    public Slider musicSlider;
    public TextMeshProUGUI musicValueText;

    void Awake()
    {
        instance = FindObjectOfType(typeof(SoundManager)) as SoundManager;
    }

    void Start()
    {
        effectsSlider.value = settings.inGameSettingsData.effectsVolume;
        musicSlider.value = settings.inGameSettingsData.musicVolume;

        effectsSource.volume = effectsSlider.value/100;
        musicSource.volume = musicSlider.value/100;
        fxValueText.text = effectsSlider.value.ToString();
        musicValueText.text = musicSlider.value.ToString();
        PlayLoop(inGameTheme);
    }

    public void PlaySound(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
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
        settings.inGameSettingsData.effectsVolume = volume;
        effectsSource.volume = volume / 100;
        fxValueText.text = volume.ToString();
    }

    public void SetMusicVolume(float mVolume)
    {
        settings.inGameSettingsData.musicVolume = mVolume;
        musicSource.volume = mVolume / 100;
        musicValueText.text = mVolume.ToString();
    }
}