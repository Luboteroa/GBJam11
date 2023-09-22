using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStatus : MonoBehaviour
{
    [Header("Player Statistics")]
    [SerializeField] private int localHp = 3;
    
    [Header("Inputs")]
    [SerializeField] private InputActionProperty pauseMenuButton;
    [SerializeField] private InputActionProperty selectButton;

    //Pause Menu
    private bool isGamePaused = false;
    
    //Select Button, it's true by default
    private bool isSelectTriggered = true;

    #region PUBLIC ACTION EVENTS
    public static event Action onLevelStarted;
    public static event Action onLevelCompleted;
    public static event Action onGamePaused;
    public static event Action onGameResumed;
    public static event Action onSelectEnabled;
    public static event Action onSelectDisabled;
    public static event Action<float> onPlayerHurt;
    public static event Action onPlayerLost;
    #endregion

    #region INITIALIZATION
    private void OnEnable()
    {
        pauseMenuButton.action.Enable();
        selectButton.action.Enable();
    }

    private void OnDisable()
    {
        pauseMenuButton.action.Disable();
        selectButton.action.Disable();
    }

    private void Start()
    {
        // Level Started
        onLevelStarted?.Invoke();
        
        // Input Actions
        pauseMenuButton.action.started += OnPauseMenuTriggered;
        selectButton.action.started += OnSelectTriggered;
        
        // Select is enabled by default
        onSelectEnabled?.Invoke();
    }
    #endregion
    
    #region TRIGGER METHODS
    public void RemoveHealth(int amount)
    {
        localHp -= amount;
        onPlayerHurt?.Invoke(amount);

        if (localHp <= 0)
        {
            onPlayerLost?.Invoke();
        }
    }

    public void OnPauseMenuTriggered(InputAction.CallbackContext context)
    {
        if (isGamePaused)
        {
            // Resume Game
            onGameResumed?.Invoke();
        }
        else
        {
            // Pause Game
            onGamePaused?.Invoke();
        }
        
        isGamePaused = !isGamePaused;
    }
    
    public void OnSelectTriggered(InputAction.CallbackContext context)
    {
        if (isSelectTriggered)
        {
            // Disable Select
            onSelectDisabled?.Invoke();
        }
        else
        {
            // Enable Select
            onSelectEnabled?.Invoke();
        }
        
        isSelectTriggered = !isSelectTriggered;
    }

    public void LevelCompleted()
    {
        onLevelCompleted?.Invoke();
    }
    
    #endregion
    
    #region DEBUG
#if UNITY_EDITOR

    [ContextMenu("On Level Started")]
    private void OnLevelStarted_DEBUG() => onLevelStarted?.Invoke();

    [ContextMenu("On Game Paused")]
    private void OnGamePaused_DEBUG() => onGamePaused?.Invoke();

    [ContextMenu("On Game Resumed")]
    private void OnGameResumed_DEBUG() => onGameResumed?.Invoke();

    [ContextMenu("On Player Won")]
    private void OnPlayerWon_DEBUG() => onLevelCompleted?.Invoke();

    [ContextMenu("On Player Hurt")]
    private void OnPlayerHut_DEBUG() => onPlayerHurt?.Invoke(1);

    [ContextMenu("On Player Lost")]
    private void OnPlayerLost_DEBUG() => onPlayerLost?.Invoke();

#endif

    #endregion
}
