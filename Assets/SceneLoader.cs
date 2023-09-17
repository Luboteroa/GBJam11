using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    [SerializeField] private Animator transition; 
    public float transitionTime = 5.0f;
    private bool _buttonClicked;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

    }
    public void LoadNextObject(GameObject Cinematic)
    {
        StartCoroutine(LoadObject(Cinematic));
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        transition.SetTrigger("Start");

        SceneManager.LoadScene(levelIndex);

    }

    IEnumerator LoadObject(GameObject Cinematic)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        transition.SetTrigger("Start");

        Cinematic.SetActive(true);

        yield return new WaitForSeconds(5f);

        LoadNextLevel();

    }
}
