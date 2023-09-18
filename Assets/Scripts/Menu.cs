using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject creditsObject; 
    void Update()
    {
        if (Input.GetButtonDown("Jump") && creditsObject.activeSelf)
        {
            creditsObject.SetActive(false);
        }
    }
}
