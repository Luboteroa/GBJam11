using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneLoader.Instance.LoadLevel("MainSceneTemplate");
        }

    }
}
