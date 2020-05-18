using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEndSceneChange : MonoBehaviour
{
    public GameObject cableCar;
    public SceneLoader sceneLoader;
    public GameObject animator;

    // Update is called once per frame
    void Update()
    {
        if (cableCar.transform.position.x == 16.9f)
        {
            animator.GetComponent<Animator>().enabled = true;
            sceneLoader.LoadNextScene();
        }
    }
}
