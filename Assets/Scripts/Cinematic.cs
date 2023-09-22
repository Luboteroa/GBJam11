using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    [SerializeField] private Animator transition;
    private float transitionTime = 3.0f;
    public Dialogue dialogue;
    public GameObject Cinematica;

    private void Start()
    {
        transitionTime = FindObjectOfType<SceneLoader>().transitionTime;
    }
    private void Update()
    {
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
