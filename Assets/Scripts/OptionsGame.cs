using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsGame : MonoBehaviour
{
    public EventSystem eventSystem; 
    public EventSystem eventSystemOptions;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            menu.gameObject.SetActive(true);
            eventSystem.gameObject.SetActive(false);
            eventSystemOptions.gameObject.SetActive(true);
        }
    }
}
