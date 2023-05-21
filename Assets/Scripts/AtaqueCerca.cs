using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueCerca : MonoBehaviour
{
    public float attackDistance = 1f; // Distancia a la que el jugador puede atacar
    public string enemyTag = "Enemy1"; // Etiqueta asignada a los enemigos
    public int attackDamage = 1; // Daño que hace el jugador al atacar

    void Update()
    {
        // Detectar si el jugador presionó la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Detectar si hay un enemigo cerca del jugador
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackDistance);

            // Si hay un enemigo cerca, reducir su vida
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.CompareTag(enemyTag))
                {
                    enemy.GetComponent<EnemyMovement>().TakeDamage(attackDamage);
                }
            }
        }
    }

    // Dibujar un círculo en la escena para visualizar el rango de ataque del jugador
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}