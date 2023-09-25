using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    #region SINGLETON
    public static Cinematic Instance{ get; private set; }
    private void Awake()
    {
        if(Instance != null && Instance != this)
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
    }
    #endregion

    public void ActiveCinematic()
    {
        FadeManager.Instance.ActiveFade();
    }

    public void DiactiveCinematic()
    {
        if (FadeManager.Instance != null)
        {
            FadeManager.Instance.ActiveFade();
        }
        
        Destroy(this.gameObject, 1.0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            // Saltar cinemática
            DiactiveCinematic();
        }
    }

    private void OnDestroy()
    {
        if(GameManager.Instance != null)
            GameManager.Instance.StartGame();
    }
}

