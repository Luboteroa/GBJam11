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
}
