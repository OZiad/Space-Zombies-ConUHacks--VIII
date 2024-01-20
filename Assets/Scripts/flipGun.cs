using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGun : MonoBehaviour
{
    Vector3 lookDirection;
    bool facingRight = true;
 
    void Update()
    {
        fGun();
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(180f, 0f, 0f);
    }
    private void fGun()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (lookDirection.x > transform.position.x && !facingRight)
        {
            flip();
        }
        else if (lookDirection.x < transform.position.x && facingRight)
        {
            flip();
        }
    }
}
