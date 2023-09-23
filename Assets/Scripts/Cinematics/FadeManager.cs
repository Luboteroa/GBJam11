using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    [Header("Animation Settings")] 
    [SerializeField] private Animator fadeAnimator;
    
    public static string KEY_Fade = "Fade";
    
    private bool isFading = false;
    
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
        }
    }
    #endregion

    public static void ActiveFadeIn()
    {
        Instance.isFading = true;
        Instance.fadeAnimator.SetTrigger(KEY_Fade);
    }

    public void FadeInCompleted()
    {
        isFading = false;
    }

    public void FadeOutCompleted()
    {
        isFading = false;
    }
}
