using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueCerca : MonoBehaviour
{
    public float attackDistance = 1f; 
    public string enemyTag = "Enemy1"; 
    public int attackDamage = 1;

    void Update()
    {
        
        if (Input.GetButtonDown("Fire2"))
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackDistance);

            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.CompareTag(enemyTag))
                {
                    enemy.GetComponent<EnemyMovement>().TakeDamage(attackDamage);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}