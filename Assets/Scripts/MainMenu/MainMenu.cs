using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
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
}
