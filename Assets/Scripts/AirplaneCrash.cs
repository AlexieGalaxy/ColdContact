using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneCrash : MonoBehaviour
{
    public Animator animator;

    public float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Blend", time);
        if (time < 1.0f) {
            time += Time.deltaTime;
        }
    }
}
