using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCanvas_Debug : MonoBehaviour
{
    [SerializeField] private GameObject canvasGO;

    void Start()
    {
        GameStatus.onGamePaused += ActiveCanvas;
        GameStatus.onGameResumed += DiactiveCanvas;
    }

    private void ActiveCanvas() => canvasGO.SetActive(true);
    private void DiactiveCanvas() => canvasGO.SetActive(false);
}
