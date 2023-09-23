using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public TMP_Text musicLabel, sfxLabel;
    float volumenLevel = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Button botonseleccionado = EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Button>();
        if (botonseleccionado.gameObject.name == "SFX")
        {
            SetSFXVolumen();
        } else if (botonseleccionado.gameObject.name == "Music")
        {
            SetMusicVolumen();
        }
    }

    void SetSFXVolumen()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DisminuirVolumen(sfxLabel);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            AumentarVolumen(sfxLabel);
        }
    }

    void SetMusicVolumen()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DisminuirVolumen(musicLabel);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            AumentarVolumen(musicLabel);
        }
    }

    public void AumentarVolumen(TMP_Text volumen)
    {
        volumenLevel = Mathf.Min(volumenLevel + 1.0f, 10.0f);

        volumen.SetText(volumenLevel.ToString());

    }

    public void DisminuirVolumen(TMP_Text volumen)
    {
        volumenLevel = Mathf.Max(volumenLevel - 1.0f, 0.0f);

        volumen.SetText(volumenLevel.ToString());
    }
}
