using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Openable : MonoBehaviour
{
    public Rigidbody2D player;
    public GameObject prompt;
    public Dialogue dialogue;
    private BoxCollider2D trigger;
    private Vector3 promptPos;
    public GameObject relevantText;
    public bool isSceneLoader = false;
    public SceneLoader sceneLoader;
    public GameObject animator;
    public bool isSpriteUpdater = false;
    public GameObject sprite3;
    public GameObject sprite4;
    public GameObject sprite;
    public GameObject sprite2;
    public bool isMusicPlayer = false;
    public AudioSource source;
    public bool isAnimationUpdater = false;
    public Animator animatior2;
    public RuntimeAnimatorController controller;
    public BoxCollider2D wall;

    private bool hasOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        promptPos = new Vector3(transform.position.x - 1.0f, transform.position.y + 1.0f, transform.position.z);
        // Chest sprite
        trigger = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasOpened)
        {
            prompt.transform.position = promptPos;
            prompt.SetActive(true);
            relevantText.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown("f") && !hasOpened)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            hasOpened = true;
            prompt.SetActive(false);
            relevantText.SetActive(false);
            if(isAnimationUpdater)
            {
                animatior2.runtimeAnimatorController = controller;
            }
            if(isSpriteUpdater)
            {
                wall.enabled = false;
                sprite.SetActive(false);
                sprite2.SetActive(false);
                sprite3.SetActive(true);
                sprite4.SetActive(true);
            }
            if (isMusicPlayer)
            {
                source.Play();
            }
            if (isSceneLoader)
            {
                sceneLoader.isEnd = true;
                sceneLoader.LoadNextScene();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.SetActive(false);
        relevantText.SetActive(false);
    }
}
