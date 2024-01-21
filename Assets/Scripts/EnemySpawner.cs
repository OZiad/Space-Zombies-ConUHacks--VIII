using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private bool canSpawn = true;

    [SerializeField] private GameObject player;



    public void Start()
    {
        StartCoroutine(Spawner());
    }

    public IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            SpawnEnemy();

        }
    }

        public IEnumerator BossAbilitySpawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            BossAbility();

        }
    }

    private void SpawnEnemy()
    {
        int rand = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyToSpawn = enemyPrefabs[rand];
        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
    }

    public void BossAbility()
    {
        int rand = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyToSpawn = enemyPrefabs[rand];

        if (Vector3.Distance(transform.position, player.transform.position) < 300) {
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
