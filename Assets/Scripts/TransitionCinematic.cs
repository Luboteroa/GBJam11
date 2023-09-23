using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static System.TimeZoneInfo;

public class TransitionCinematic : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneLoader.Instance.LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }
}
