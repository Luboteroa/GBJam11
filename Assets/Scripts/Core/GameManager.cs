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
        if (Cinematic.Instance != null)
        {
            // Have to deploy cinematic!
            Cinematic.Instance.ActiveCinematic();
        }
        else
        {
            // There is no cinematic for this level!
            // ActiveStageCanvas();
        }
    }

    public void StartGame()
    {
        FadeManager.Instance.ActiveFade();
    }

    #region DEBUG

    #if UNITY_EDITOR

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // WON THIS LEVEL!
            Debug.Log("WON");
        }
    }

#endif

    #endregion
}