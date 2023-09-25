using System;
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
    float volumenLevelSFX = 7.0f;
    float volumenLevelMusic = 7.0f;

    private void Start()
    {
        volumenLevelMusic = GlobalInformation.GeneralMusicVolume * 10;
        volumenLevelSFX = GlobalInformation.GeneralSoundVolume * 10;
        musicLabel.text = (volumenLevelMusic).ToString();
        sfxLabel.text = (volumenLevelSFX).ToString();
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
            //SoundManager.Instance.PlayAudioSFX(soundClick);
            DisminuirVolumen(sfxLabel, "SFXVol", ref volumenLevelSFX);
            GlobalInformation.ChangeSoundVolume(volumenLevelSFX/10);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //SoundManager.Instance.PlayAudioSFX(soundClick);
            AumentarVolumen(sfxLabel, "SFXVol", ref volumenLevelSFX);
            GlobalInformation.ChangeSoundVolume(volumenLevelSFX/10);
        }
    }

    void SetMusicVolumen()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //SoundManager.Instance.PlayAudioSFX(soundClick);
            DisminuirVolumen(musicLabel, "MusicVol", ref volumenLevelMusic);
            GlobalInformation.ChangeMusicVolume(volumenLevelMusic/10);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //SoundManager.Instance.PlayAudioSFX(soundClick);
            AumentarVolumen(musicLabel, "MusicVol", ref volumenLevelMusic);
            GlobalInformation.ChangeMusicVolume(volumenLevelMusic/10);
        }
    }

    public void AumentarVolumen(TMP_Text volumen, string group, ref float volumenLevel)
    {
        volumenLevel = Mathf.Min(volumenLevel + 1.0f, 10.0f);
        if (volumen.text == musicLabel.text)
            SoundManager.Instance.ChangeVolume(volumenLevel/10);
        volumen.SetText(volumenLevel.ToString());
    }

    public void DisminuirVolumen(TMP_Text volumen, string group, ref float volumenLevel)
    {
        volumenLevel = Mathf.Max(volumenLevel - 1.0f, 0.0f);
        if (volumen.text == musicLabel.text)
            SoundManager.Instance.ChangeVolume(volumenLevel/10);
        volumen.SetText(volumenLevel.ToString());
    }
}
