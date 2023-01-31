using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay = 1f;
    [SerializeField] private int maxEnemies = 10;
    private int currentEnemies = 0;
    private float spawnTimer = 0f;
    private Vector3 spawnPosition;

    private void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        if (currentEnemies < maxEnemies)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnDelay)
            {
                spawnTimer = 0f;
                SpawnEnemy();
            }
        }
    }
    
    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3( transform.position.x, transform.position.y, 0f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        currentEnemies++;
    }
}
