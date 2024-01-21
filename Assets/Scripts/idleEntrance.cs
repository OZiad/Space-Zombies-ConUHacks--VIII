using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleEntrance : MonoBehaviour
{
    private Animator mAnimator;
    private float speed;
    private Vector3 vel;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator.SetTrigger("TrEntrance"); 

        mAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        vel = rb.velocity;
        speed = rb.velocity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if(mAnimator != null){
            //walk

            if(speed != 0){
                mAnimator.SetTrigger("TrWalk");
            }
        }
    }
}
