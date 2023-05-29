using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int life = 10;
    public float moveSpeed = 5f; 
    private Spawner spawner;

    
    public PlayerController playerController;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawner = FindObjectOfType<Spawner>();
    }

    void FixedUpdate()
    {
        //MoveTowardsPlayer();
    }
    void MoveTowardsPlayer()
    {
        // si el jugador está vivo
        if (playerController.life > 0)
        {
            Vector2 direction = playerController.transform.position - transform.position;
            direction.Normalize();
            rb.velocity = direction * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala1")
        {
            life -= 1;
        }
        if (collision.gameObject.tag == "Bala2")
        {
            life -= 2;
        }
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
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
