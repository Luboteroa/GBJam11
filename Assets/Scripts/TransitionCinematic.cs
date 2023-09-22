using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static System.TimeZoneInfo;

public class TransitionCinematic : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
