using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    private bool isCinematicActive = false;
    
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
        isCinematicActive = true;
    }

    public void DiactiveCinematic()
    {
        isCinematicActive = false;
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
}

