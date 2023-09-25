using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    #region DIALOG STRUCT
    [System.Serializable]
    private struct Dialog
    {
        public Monolog[] monologs;
    }

    [System.Serializable]
    private struct Monolog
    {
        public string speacherName;
        public string speech;
        public Sprite photo;
        public AudioClip sound;
    }
    #endregion
    
    [Header("Animation")]
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text speech;
    [SerializeField] private Image faceImg;
    [SerializeField] private Animator dialogAnimator;
    
    [Header("Settings")]
    [SerializeField] private bool firstDialogIsOnCinematic = false;

    [Header("Sound")] 
    [SerializeField] private AudioClip[] textSound;
    [SerializeField] private SoundGenerator soundGeneratorSpeech, soundGeneratorText;
    
    [Header("Dialogs")]
    [SerializeField] private Dialog[] dialogs;

    private int currentDialogCount = -1, currentMonologCount = -1;
    private bool isSpeeching = false;
    private int characterIndex;
    private float timer;
    private int currentTriggerSound = 0;
    private bool doSoundSpeech = true;

    #region SINGLETON
    public static DialogSystem Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
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

    private void Start()
    {
        if(firstDialogIsOnCinematic)
            NextDialog();
    }

    public void NextDialog()
    {
        currentDialogCount++;
        dialogAnimator.SetTrigger("Trigger");
    }

    private void EndDialog()
    {
        if (firstDialogIsOnCinematic)
        {
            Cinematic.Instance.DiactiveCinematic();
        }
            
        dialogAnimator.SetTrigger("Trigger");
    }

    public void StartSpeech()
    {
        speech.text = "";
        currentMonologCount++;
        isSpeeching = true;
        soundGeneratorSpeech.TriggerSound(dialogs[currentDialogCount].monologs[currentMonologCount].sound);
        name.text = dialogs[currentDialogCount].monologs[currentMonologCount].speacherName;
        faceImg.sprite = dialogs[currentDialogCount].monologs[currentMonologCount].photo;
        doSoundSpeech = true;
    }

    private void Update()
    {
        AddWriter();
        
        if(!isSpeeching)
            return;
        
        if(Input.GetKeyDown(KeyCode.J))
            NextMonolog();
    }

    private void AddWriter()
    {
        if (isSpeeching)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer += 0.05f;
                characterIndex++;
                speech.text = dialogs[currentDialogCount].monologs[currentMonologCount].speech.Substring(0, characterIndex);

                if (doSoundSpeech)
                {
                    soundGeneratorText.TriggerSound(textSound[currentTriggerSound]);
                    currentTriggerSound++;
                    if (currentTriggerSound >= 5)
                        currentTriggerSound = 0;
                }
                doSoundSpeech = !doSoundSpeech;
                
                if (characterIndex >= dialogs[currentDialogCount].monologs[currentMonologCount].speech.Length)
                {
                    Invoke("NextMonolog", 1.0f);
                    isSpeeching = false;
                }
            }
        }
    }

    private void NextMonolog()
    {
        currentMonologCount++;
        if (currentMonologCount >= dialogs[currentDialogCount].monologs.Length)
        {
            EndDialog();
        }
        else
        {
            StartSpeech();
        }
    }
}
