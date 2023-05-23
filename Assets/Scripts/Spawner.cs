using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo que queremos generar
    public float spawnDelay = 2f; // Tiempo entre generación de enemigos
    private float spawnTimer = 0f; // Contador de tiempo para la generación de enemigos
    private int enemyCount = 0; // Contador de enemigos generados
    public int enemyRemaining = 20; // Cantidad total de enemigos en la escena. La hacemos pública para acceder desde otro script.

    void Update()
    {
    // Contar el tiempo para la generación de enemigos
        spawnTimer += Time.deltaTime;

    // Si ha pasado suficiente tiempo y no se han generado todos los enemigos, generar un enemigo en una ubicación aleatoria
    if (spawnTimer >= spawnDelay && enemyCount < 20)
    {
        SpawnEnemy();
        spawnTimer = 0f; // Reiniciar el contador de tiempo
    }

    // Verificar si no quedan enemigos en la escena y cargar la escena de victoria
    if (enemyRemaining == 0)
        {
        SceneManager.LoadScene("Victory"); // Reemplaza "VictoryScene" con el nombre de tu escena de victoria
        }
    }

    void SpawnEnemy()
    {
        // Calcular una posición aleatoria en el área de juego
        Vector2 spawnPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));

        // Instanciar un enemigo en la posición aleatoria
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        enemyCount++; // Incrementar el contador de enemigos generados
    }
}
