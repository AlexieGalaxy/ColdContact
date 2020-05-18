using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableCarAnimation : MonoBehaviour
{
    public Animator cableCarAnimator;
    public RuntimeAnimatorController MovingController;

    // Start is called before the first frame update
    void Start()
    {
        cableCarAnimator.runtimeAnimatorController = MovingController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
