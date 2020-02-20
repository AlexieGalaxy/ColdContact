using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI dialogueText;

    public Animator animator;
    public AudioSource audioSource;

    private Queue<string> sentences;
    private Queue<AudioClip> audioClips;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        audioClips = new Queue<AudioClip>();
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (AudioClip clip in dialogue.audioClips)
        {
            audioClips.Enqueue(clip);
        }

        DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {

        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        AudioClip clip = audioClips.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, clip));

    }

    IEnumerator TypeSentence(string sentence, AudioClip audioClip)
    {
        dialogueText.text = "";

        audioSource.clip = audioClip;
        audioSource.Play();

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
