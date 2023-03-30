using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : BaseCharacter
{
    public GameObject enemyPrefab;
    public float spawnRate = 10;
    private float timer = 0;
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            SpawnEnemy();
            timer = spawnRate;
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
