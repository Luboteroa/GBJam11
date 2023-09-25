using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] public AudioMixer audioMixer;

    [SerializeField] public AudioMixerGroup sfxGroup;
    [SerializeField] public AudioMixerGroup musicGroup;
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
            DontDestroyOnLoad(this);
        }

        audioSource = GetComponent<AudioSource>();
    }
    #endregion

    public void PlayAudioSFX(AudioClip audio)
    {
        audioSource.outputAudioMixerGroup = sfxGroup;
        audioSource.clip = audio;
        audioSource.PlayOneShot(audio);
    }
    public void PlayAudioMusic(AudioClip audio)
    {
        audioSource.outputAudioMixerGroup = musicGroup;
        audioSource.clip = audio;
        audioSource.loop = true;
        audioSource.PlayOneShot(audio);
    }
}
