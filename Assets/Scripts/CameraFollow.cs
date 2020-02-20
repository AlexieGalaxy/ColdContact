using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.3f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    // FixedUpdate is called once per frame in physics loop.
    void LateUpdate()
    {
        // By the time this function s called, the player has already completed all of its movement.
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        // if we want the camera to rotate and follow the player
        // transform.LookAt(target);
    }
}
