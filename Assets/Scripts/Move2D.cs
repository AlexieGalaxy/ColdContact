using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody2D body;
    public EdgeCollider2D ground;

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
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void Jump()
    {
        if (Input.GetKeyDown("space") && body.IsTouching(ground)) {
            body.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }
}
