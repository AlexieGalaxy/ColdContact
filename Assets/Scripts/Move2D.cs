using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public bool mirror = false;
    public Animator animator;
    private Rigidbody2D body;
    public SpriteRenderer sr;
    private bool onGround = false;
    public PhysicsMaterial2D physicsMat;
    public PhysicsMaterial2D physicsMat0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (onGround && Input.GetKeyDown("space"))
        {
            body.AddForce(new Vector2(0f, 8.5f), ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position + new Vector3(0.03f, -0.5f, 0f), 0.1f);

        onGround = false;

        foreach (Collider2D collider in hits)
        {
            if (collider.tag == "Ground")
            {
                onGround = true;
                break;
            }
        }
        if (!onGround)
        {
            body.sharedMaterial = physicsMat0;
        } else
        {
            body.sharedMaterial = physicsMat;
        }

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

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + new Vector3(0.03f, -0.5f, 0f), 0.1f);
    }
}
