using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
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

    public void PlayAudio(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
