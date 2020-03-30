using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DebugOverlay : MonoBehaviour
{
    public static bool overlayShown = false;
    public GameObject debugOverlayUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("`"))
        {
            if (overlayShown)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        debugOverlayUI.SetActive(false);
        overlayShown = false;
    }

    void Pause()
    {
        debugOverlayUI.SetActive(true);
        overlayShown = true;
    }
}
