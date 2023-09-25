using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SoundGenerator soundGenerator;
    [SerializeField] private AudioClip moveAudio, clickAudio, backAudio;
    private void Start()
    {
        if(FadeManager.Instance != null)
            FadeManager.Instance.ActiveFade();
    }

    public void PlayButton()
    {
        if (FadeManager.Instance != null)
        {
            FadeManager.Instance.ActiveFade();
            Invoke(nameof(ChangeScene), 1.0f);
        }
        
    }

    private void ChangeScene()
    {
        LevelHandler.Instance.LoadLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            soundGenerator.TriggerSound(moveAudio);
        }
        else if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
        {
            soundGenerator.TriggerSound(clickAudio);
        }
    }

    public void Back()
    {
        soundGenerator.TriggerSound(backAudio);
    }
}
