using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    public bool scroll = false;
    public Animator animator;
    public RuntimeAnimatorController scroller;

    // Start is called before the first frame update
    void Start()
    {
        if (scroll) {
            animator.runtimeAnimatorController = scroller;
        }
    }
}
