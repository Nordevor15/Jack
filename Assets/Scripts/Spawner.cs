using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay = 2f;
    private float spawnTimer = 0f;
    private int enemyCount = 0;
    public int enemy = 20;

    void Update()
    {
        spawnTimer += Time.deltaTime;

    if (spawnTimer >= spawnDelay && enemyCount < 20)
    {
        SpawnEnemy();
        spawnTimer = 0f; 
    }
    if (enemy == 0)
        {
        SceneManager.LoadScene("Victory");
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        enemyCount++;
    }
}
