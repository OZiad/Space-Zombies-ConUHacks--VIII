using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public GameObject player;
    public GameObject[] mobs;
    [SerializeField] protected int dmg = 1;
    [SerializeField] public int health = 1;
    public float speed = 1;
    [SerializeField] private float distance = 1;


    public void Start()
    {
        StartCoroutine(RollEvery10Seconds());
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
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
    public void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("WaveSpawner") != null)
        {
            GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveSpawner>().spawnedEnemies.Remove(gameObject);
        }

    }

    public IEnumerator TemporaryStop()
    {
        Debug.Log("Temporary stop started.");
        float originalspeed = speed;
        speed = 0;
        yield return new WaitForSeconds(10);
        speed = originalspeed;
        Debug.Log("Temporary stop ended.");

    }

    public int Roll()
    {
        return Random.Range(1, 3);
    }

    private IEnumerator RollEvery10Seconds()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            int currentRoll = Roll();
            Ability(currentRoll);

        }
    }

    public void Ability(int currentRoll)
    {
        Debug.Log("Ability called.");
        Debug.Log(currentRoll);
        switch (currentRoll)
        {
            case 1:
                StartCoroutine(TemporaryStop());
                break;
            case 2:
                Instantiate(mobs[0], transform.position, Quaternion.identity);
                Instantiate(mobs[1], transform.position, Quaternion.identity);
                Instantiate(mobs[2], transform.position, Quaternion.identity);
                Instantiate(mobs[2], transform.position, Quaternion.identity);
                Instantiate(mobs[2], transform.position, Quaternion.identity);
                Instantiate(mobs[1], transform.position, Quaternion.identity);
                Instantiate(mobs[0], transform.position, Quaternion.identity);
                Instantiate(mobs[1], transform.position, Quaternion.identity);
                Instantiate(mobs[2], transform.position, Quaternion.identity);
                Instantiate(mobs[2], transform.position, Quaternion.identity);
                Instantiate(mobs[2], transform.position, Quaternion.identity);
                Instantiate(mobs[1], transform.position, Quaternion.identity);
                break;
            case 3:
                // Spawn a bunch of enemies
                break;
            case 4:
                // Spawn a bunch of enemies
                break;
            case 5:
                // Spawn a bunch of enemies
                break;
        }
    }
    
}
