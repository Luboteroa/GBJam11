using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] private string nextSceneToLoad = "1_MainMenu";

    private void Start()
    {
        FadeManager.Instance.ActiveFade();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            FadeManager.Instance.ActiveFade();
            Invoke(nameof(NextSceneToLoad), 1.0f);
        }
    }

    private void NextSceneToLoad()
    {
        LevelHandler.Instance.LoadExactScene(nextSceneToLoad);
    }
}
