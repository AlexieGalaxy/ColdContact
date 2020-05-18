using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transitionOut;

    public bool isEnd = false;

    public bool isCredits = false;

    public GameObject animator;

    public float transitionTime;

    public void LoadNextScene()
    { 
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMenuScene()
    {
        StartCoroutine(LoadLevel(0));
    }

    // Co-routine
    IEnumerator LoadLevel(int sceneIndex)
    {
        if (isCredits)
        {
            // Wait
            yield return new WaitForSeconds(25);

            animator.GetComponent<Animator>().enabled = true;

            // Wait
            yield return new WaitForSeconds(transitionTime);

        }
        if (isEnd)
        {
            // Wait
            yield return new WaitForSeconds(10);

            animator.GetComponent<Animator>().enabled = true;

            // Wait
            yield return new WaitForSeconds(transitionTime);

        }
        else
        {
            // Wait
            yield return new WaitForSeconds(transitionTime);

        }
        // Load Scene.
        SceneManager.LoadScene(sceneIndex);
    }
}
