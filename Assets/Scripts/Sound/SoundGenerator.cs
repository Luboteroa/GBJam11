using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundGenerator : MonoBehaviour
{
    private AudioSource mAudioSource;
    private void Start()
    {
        mAudioSource = this.AddComponent<AudioSource>();
        mAudioSource.playOnAwake = false;
        mAudioSource.loop = false;
        mAudioSource.volume = GlobalInformation.GeneralSoundVolume;
        mAudioSource.spatialBlend = 0.0f;

        if (this.tag == "Low")
        {
            mAudioSource.volume = 0.01f;
        }
    }

    public void TriggerSound(AudioClip sfxSound)
    {
        mAudioSource.PlayOneShot(sfxSound);
    }
}
