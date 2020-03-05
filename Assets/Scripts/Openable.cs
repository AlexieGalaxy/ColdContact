using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour
{
    public Rigidbody2D player;
    public GameObject prompt;
    public Dialogue dialogue;
    private BoxCollider2D trigger;
    private Vector3 promptPos;

    private bool hasOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        promptPos = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z);
        // Chest sprite
        trigger = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasOpened)
        {
            prompt.transform.position = promptPos;
            prompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown("f") && !hasOpened)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            hasOpened = true;
            prompt.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.SetActive(false);
    }
}
