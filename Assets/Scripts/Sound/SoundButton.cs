using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static System.TimeZoneInfo;

public class SoundButton : MonoBehaviour, ISelectHandler
{
    private AudioClip soundHover;
    private AudioClip soundBack;
    private AudioClip soundClick;

    private void Start()
    {
        soundHover = FindObjectOfType<Menu>().soundHover;
        soundBack = FindObjectOfType<Menu>().soundBack;
        soundClick = FindObjectOfType<Menu>().soundClick;
    }

    public void OnSelect(BaseEventData eventData)
    {
        //SoundManager.Instance.PlayAudioSFX(soundHover);
    }

    public void OnClick()
    {
        //SoundManager.Instance.PlayAudioSFX(soundClick);
    }
    public void OnBack()
    {
        //SoundManager.Instance.PlayAudioSFX(soundBack);
    }

}
