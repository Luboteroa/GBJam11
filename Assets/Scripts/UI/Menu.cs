using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioClip soundHover;
    public AudioClip soundClick;
    public AudioClip soundBack;
    public void LoadCredits()
    {
        SceneLoader.Instance.LoadLevel("18_Credits");
    }
}
