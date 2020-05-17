using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneLoader sceneLoader; 

    public void PlayGame()
    {
        // Load the level.
        sceneLoader.LoadNextScene();
    }

    public void QuitGame()
    {
        // Debug for Unity - doesnt show quitting.
        Debug.Log("Game Exiting...");

        Application.Quit();
    }
}
