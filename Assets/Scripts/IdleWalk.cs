using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWalk : MonoBehaviour
{

    private Animator mAnimator;
    private float speed;
    private Vector3 vel;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()   
    {
        vel = rb.velocity;
        speed = rb.velocity.magnitude;
        if(mAnimator != null){
            if(speed != 0){
                mAnimator.SetTrigger("TrWalk"); 
            }

            if(speed == 0){
                mAnimator.SetTrigger("TrIdle");
            }
        }
    }
}
