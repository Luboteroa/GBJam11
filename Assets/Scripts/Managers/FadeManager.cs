using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    [Header("Animation Settings")] 
    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private float animationTime = 1f;
    public float AnimationTime => animationTime;
    
    public static string KEY_Fade = "Fade";
    
    private bool isFadeInActive = true;
    
    #region SINGLETON
    public static FadeManager Instance{ get; private set; }
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
#if DEBUG
            Debug.LogWarning("You created two instances for " + this.name + "! Please check!");
#endif
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion

    public void ActiveFade()
    {
        fadeAnimator.SetTrigger(KEY_Fade);

        if (isFadeInActive)
        {  
            SoundManager.Instance.LerpFadeIn();
        }
        else
        {
            SoundManager.Instance.LerpFadeOut();
        }

        isFadeInActive = !isFadeInActive;
    }
}
