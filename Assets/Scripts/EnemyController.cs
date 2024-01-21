using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // public PlayerHealth playerHealth;
    [SerializeField] public int maxHealth = 1;
    [SerializeField] public int health;
    [SerializeField] protected int dmg = 1;

    private GameObject player;
    private Score score;
    void start()
    {
        health = maxHealth;
    }
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
                    UpdateScore();
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
    private void UpdateScore()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        score = player.GetComponent<Score>();

        Debug.Log(player == null);
        if (score != null)
        {
            score.UpdateScore(maxHealth);
        }
        else
        {
            Debug.LogError("Score script not found on the player!");
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
