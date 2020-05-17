using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transitionOut;

    public float transitionTime;

    public void LoadNextScene()
    { 
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    // Co-routine
    IEnumerator LoadLevel(int sceneIndex)
    {
        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load Scene.
        SceneManager.LoadScene(sceneIndex);
    }
}
