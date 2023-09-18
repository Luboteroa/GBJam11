using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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

    }
}
