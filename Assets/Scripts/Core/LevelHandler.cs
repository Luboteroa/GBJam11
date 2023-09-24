using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private string scenePrefix = "Level ";
    public static LevelHandler Instance { get; private set; }

    private string currentLevel = "";

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
        GameStatus.onLevelCompleted += LoadNextLevel;
        GameStatus.onPlayerLost += PlayerDead;
    }

    #region LEVEL METHODS

    private void LoadNextLevel()
    {
        GlobalInformation.UpgradeSublevelCount();
        LoadLevel();
    }

    private void ResetSubLevel()
    {
        GlobalInformation.ResetSublevelCount();
        LoadLevel();
    }

    private void ResetCurrentLevel()
    {
        LoadLevel();
    }
    
    private bool MustResetSubLevel()
    {
        int currentRemainingLifes = GlobalInformation.GlobalRemainingLifes-1;
        GlobalInformation.ChangeGlobalLifes(currentRemainingLifes);

        if (currentRemainingLifes > 0)
            return true;
        else
            return false;
    }

    #region PUBLIC FUNCTIONS

    public void LoadLevel()
    {
        currentLevel = scenePrefix + GlobalInformation.LevelLoaded + "-" + GlobalInformation.SubLevelLoaded;
        SceneManager.LoadScene(currentLevel);
    } 
    public void LoadExactScene(string sceneName) => SceneManager.LoadScene(sceneName);

    #endregion
    
    #endregion

    #region PLAYER METHODS
    private void PlayerDead()
    {
        if (MustResetSubLevel())
        {
            ResetSubLevel();
        }
        else
        {
            ResetCurrentLevel();
        }
    }
    
    #endregion
}
