using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovement : MonoBehaviour
{
    public float scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 camPos = new Vector3(transform.position.x + scrollSpeed, transform.position.y, transform.position.z);
        transform.position = camPos;
    }
}
