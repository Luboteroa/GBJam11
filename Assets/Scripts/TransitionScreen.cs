using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TransitionScreen : MonoBehaviour
{
    public GameObject Object;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Load(Object));
            
        }

    }

    IEnumerator Load(GameObject Cinematic)
    {
        SceneLoader.Instance.LoadNextObject(Object);

        yield return new WaitForSeconds(2.0f);

        this.gameObject.SetActive(false);
    }
}
