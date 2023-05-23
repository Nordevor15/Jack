using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int life = 10;
    public float moveSpeed = 5f; 
    private Spawner spawner; // referencia al Spawner

    
    public PlayerController playerController; // referencia al PlayerController

    private Rigidbody2D rb; // referencia al Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // obtener la referencia al Rigidbody2D
        spawner = FindObjectOfType<Spawner>(); // obtener la referencia al Spawner
    }

    void FixedUpdate()
    {
        // mover el enemigo hacia el jugador
        MoveTowardsPlayer();
    }
    void MoveTowardsPlayer()
    {
        // si el jugador está vivo
        if (playerController.life > 0)
        {
            // obtener la dirección hacia el jugador
            Vector2 direction = playerController.transform.position - transform.position;
            direction.Normalize(); // normalizar la dirección para una velocidad constante
            rb.velocity = direction * moveSpeed; // mover el enemigo en la dirección del jugador
        }
        else
        {
            // si el jugador está muerto, detener el movimiento del enemigo
            rb.velocity = Vector2.zero;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala1")
        {
            //quitar 1 de vida
            life -= 1;
        }
        //si colisiona con la bala2 quitar 2 de vida
        if (collision.gameObject.tag == "Bala2")
        {
            //quitar 2 de vida
            life -= 2;
        }
        //si la vida es 0 destruir al enemigo
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        // si el enemigo es destruido, decrementar el contador de enemigos restantes
        spawner.enemyRemaining--;
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
