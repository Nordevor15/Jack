using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo que queremos generar
    public float spawnDelay = 2f; // Tiempo entre generación de enemigos
    private float spawnTimer = 0f; // Contador de tiempo para la generación de enemigos

    void Update()
    {
        // Contar el tiempo para la generación de enemigos
        spawnTimer += Time.deltaTime;

        // Si ha pasado suficiente tiempo, generar un enemigo en una ubicación aleatoria
        if (spawnTimer >= spawnDelay)
        {
            SpawnEnemy();
            spawnTimer = 0f; // Reiniciar el contador de tiempo
        }
    }

    void SpawnEnemy()
    {
        // Calcular una posición aleatoria en el área de juego
        Vector2 spawnPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));

        // Instanciar un enemigo en la posición aleatoria
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}