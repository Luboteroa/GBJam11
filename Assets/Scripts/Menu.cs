using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Update()
    {
    }

    public void LoadCredits()
    {
        SceneLoader.Instance.LoadLevel("Credits");
    }

}
