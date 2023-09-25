using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundButtonOptions : MonoBehaviour, ISelectHandler
{
    private AudioClip soundHover;
    private AudioClip soundBack;

    private void Start()
    {
        soundHover = FindObjectOfType<OptionsGame>().soundHover;
        soundBack = FindObjectOfType<OptionsGame>().soundBack;
    }

    public void OnSelect(BaseEventData eventData)
    {
        //SoundManager.Instance.PlayAudioSFX(soundHover);
    }

    public void OnBack()
    {
        //SoundManager.Instance.PlayAudioSFX(soundBack);
    }

}
