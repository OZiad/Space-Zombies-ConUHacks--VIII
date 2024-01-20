using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // public PlayerHealth playerHealth;
    [SerializeField] public int health = 1;
    [SerializeField] protected int dmg = 1;

    // public EnemyController(int health, int dmg)
    // {
    //     this.health = health;
    //     this.dmg = dmg;
    // }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            BulletController bullet = other.gameObject.GetComponent<BulletController>();
            if (bullet != null)
            {
                health -= bullet.damage;
                if (health <= 0)
                {
                    Die();
                }
            }
        }
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(dmg);
            Die();
        }
    }
    private void Die()
    {
        // Play death animation, effects, etc. here
        Destroy(gameObject);
    }
    void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("WaveSpawner") != null)
        {
            GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveSpawner>().spawnedEnemies.Remove(gameObject);
        }

    }
}
