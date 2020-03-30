using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite sprite;

    public BoxCollider2D walkieTalike;
    public RuntimeAnimatorController controller;
    private Animator animator;
    private SpriteRenderer spriteRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WalkieTalkie")
        {
            spriteRenderer.sprite = sprite;
            animator.runtimeAnimatorController = controller;
            Destroy(collision.gameObject);
        }
    }
}
