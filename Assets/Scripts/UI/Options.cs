using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public TMP_Text musicLabel, sfxLabel;
    float volumenLevelSFX = 10.0f;
    float volumenLevelMusic = 10.0f;

    private AudioClip soundClick;
    private AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        soundClick = FindObjectOfType<Menu>().soundClick;
        audioMixer = FindObjectOfType<SoundManager>().audioMixer;
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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SoundManager.Instance.PlayAudioSFX(soundClick);
            DisminuirVolumen(sfxLabel, "SFXVol", ref volumenLevelSFX);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SoundManager.Instance.PlayAudioSFX(soundClick);
            AumentarVolumen(sfxLabel, "SFXVol", ref volumenLevelSFX);
        }
    }

    void SetMusicVolumen()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SoundManager.Instance.PlayAudioSFX(soundClick);
            DisminuirVolumen(musicLabel, "MusicVol", ref volumenLevelMusic);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SoundManager.Instance.PlayAudioSFX(soundClick);
            AumentarVolumen(musicLabel, "MusicVol", ref volumenLevelMusic);
        }
    }

    public void AumentarVolumen(TMP_Text volumen, string group, ref float volumenLevel)
    {
        volumenLevel = Mathf.Min(volumenLevel + 1.0f, 10.0f);
        audioMixer.SetFloat(group, -5 * (10 - volumenLevel));
        volumen.SetText(volumenLevel.ToString());

    }

    public void DisminuirVolumen(TMP_Text volumen, string group, ref float volumenLevel)
    {
        Debug.Log(volumenLevel);
        volumenLevel = Mathf.Max(volumenLevel - 1.0f, 0.0f);
        audioMixer.SetFloat(group, -5 * (10 - volumenLevel));
        volumen.SetText(volumenLevel.ToString());
    }
}
