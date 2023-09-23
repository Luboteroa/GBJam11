using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] private Animator transition;
    private float transitionTime = 3.0f;
    public Dialogue dialogue;
    public GameObject Cinematica;

    #region SINGLETON
    public static CinematicManager Instance{ get; private set; }
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

    private void Start()
    {
        transitionTime = FindObjectOfType<SceneLoader>().transitionTime;
    }
    
    public void LoadNextObject()
    {
        StartCoroutine(LoadObject());
    }

    IEnumerator LoadObject()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        Cinematica.SetActive(true);

        transition.SetTrigger("Start");

        yield return new WaitForSeconds (2.0f);

        DialogueTrigger();
    }

    public void DialogueTrigger()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
