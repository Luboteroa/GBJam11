using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; private set; }

    private GameStatus gameStatus; 
    private void Awake()
    {
        #region SINGLETON
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
        #endregion

        gameStatus = GetComponent<GameStatus>();
    }

    private void Start()
    {
        if (FadeManager.Instance != null)
        {
            FadeManager.Instance.ActiveFade();
        }
    }

    #region DEBUG

    #if UNITY_EDITOR

    private void Update()
    {
        if (Input.GetKeyDown("W"))
        {
            // WIN THIS LEVEL!
            Debug.Log("WON");
        }
    }

#endif

    #endregion
}