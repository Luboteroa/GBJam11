using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    [Header("Animation Settings")] 
    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private float animationTime = 1f;
    
    public static string KEY_Fade = "Fade";
    
    private bool isAnimating = false;
    private bool isFadeInActive = false;
    
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
        isAnimating = true;
        fadeAnimator.SetTrigger(KEY_Fade);
        
        if(isFadeInActive)
            Invoke(nameof(FadeOutCompleted), animationTime);
        else
            Invoke(nameof(FadeInCompleted), animationTime);
        
        isFadeInActive = !isFadeInActive;
    }

    public void FadeInCompleted()
    {
        isAnimating = false;
    }

    public void FadeOutCompleted()
    {
        isAnimating = false;
    }
}
