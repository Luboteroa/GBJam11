using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField]private AudioSource audioSource;
    [SerializeField] public AudioMixer audioMixer;
    [SerializeField] public AudioMixerGroup sfxGroup;
    [SerializeField] public AudioMixerGroup musicGroup;
    [SerializeField] private float fadeDuration = 1.0f;
    
    private float beginTime;
    private float initVolume;
    private float targetVolume;
    private bool fadeInVolume, fadeOutVolume;

    public AudioSource MainAudioSource => audioSource;
    
    #region SINGLETON
    public static SoundManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
#if DEBUG
            Debug.LogWarning("You created two instances for " + this.name + "! Please check!");
#endif
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        audioSource = GetComponent<AudioSource>();
    }
    #endregion

    public void LerpFadeIn()
    {
        fadeInVolume = true;
        fadeOutVolume = false;
    }

    public void LerpFadeOut()
    {
        fadeInVolume = false;
        fadeOutVolume = true;
    }

    private void Start()
    {
        beginTime = Time.time;
        initVolume = 0;
        targetVolume = GlobalInformation.GeneralMusicVolume;
        fadeDuration = FadeManager.Instance.AnimationTime * 3;
        fadeInVolume = false;
        fadeOutVolume = false;
    }

    private void Update()
    {
        if (fadeInVolume)
        {
            float time = Time.time - beginTime;
            float progress = Mathf.Clamp01(time / fadeDuration);

            audioSource.volume = Mathf.Lerp(initVolume, targetVolume, progress);
            if (progress > targetVolume)
                fadeInVolume = false;
        }
        else if (fadeOutVolume)
        {
            float time = Time.time - beginTime;
            float progress = Mathf.Clamp01(time / fadeDuration/3);

            audioSource.volume = Mathf.Lerp(this.audioSource.volume, initVolume, progress);
            if (progress > initVolume)
                fadeOutVolume = false;
        }
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
