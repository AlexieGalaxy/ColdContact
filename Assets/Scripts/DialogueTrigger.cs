using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Rigidbody2D player;
    private BoxCollider2D trigger;
    public Dialogue dialogue;

    private bool hasTouched = false;

    void Start()
    {
        trigger = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (player.IsTouching(trigger) && !hasTouched)
        {
            TriggerDialogue();
            hasTouched = true;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
