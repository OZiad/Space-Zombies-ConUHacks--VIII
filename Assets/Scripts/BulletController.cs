using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage = 1;
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the colliding object has a specific tag
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Deal dmg here
        }
        Destroy(this.gameObject);
    }
}
