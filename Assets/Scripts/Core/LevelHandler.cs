using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler Instance { get; private set; }

    #region PUBLIC EVENTS

    public static event Action onLoadLevel;

    #endregion

    private void Awake()
    {
        #region SINGLETON

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
            DontDestroyOnLoad(this.gameObject);
        }

        #endregion
    }

    private void Start()
    {
        
    }

    #region PUBLIC FUNCTIONS

    public void TriggerNextLevel()
    {
        onLoadLevel?.Invoke();
    }

    public void ResetCurrentLevel()
    {
        onLoadLevel?.Invoke();
    }

    public void ResetGlobalLevel()
    {
        onLoadLevel?.Invoke();
    }

    public void LoadCurrentLevel()
    {
        onLoadLevel?.Invoke();
    }

    #endregion

    private int GetCurrentGlobalLives()
    {
        return 0;
    }

    private int GetCurrentLevel()
    {
        return 0;
    }

    private int GetCurrentSublevel()
    {
        return 0;
    }
}
