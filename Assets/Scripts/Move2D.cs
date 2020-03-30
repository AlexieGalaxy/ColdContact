using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public bool mirror = false;
    public Animator animator;
    private Rigidbody2D body;
    public Collider2D[] ground;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        animator.SetFloat("Speed", movement.x);
        animator.SetBool("Mirror", mirror);

        if (body.velocity.x >= 0.01f)
        {
            sr.flipX = false;
            mirror = false;
        }
        else if (body.velocity.x <= -0.01f)
        {
            sr.flipX = true;
            mirror = true;
        }

        body.velocity += new Vector2(movement.x, movement.y) * moveSpeed;
        body.velocity = new Vector2(Mathf.Clamp(body.velocity.x, -moveSpeed, moveSpeed), body.velocity.y);

    }

    void Jump()
    {
        if (Input.GetKeyDown("space")) {
            foreach (Collider2D collider in ground) {
                if (body.IsTouching(collider))
                {
                    body.AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
                }
            }
        }
    }
}
