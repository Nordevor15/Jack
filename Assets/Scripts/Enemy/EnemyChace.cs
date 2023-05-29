using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChace : MonoBehaviour
{
    float moveSpeed = 2.5f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirect;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (target)
        {
            Vector3 direct = (target.position - transform.position).normalized;
            float alpha = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
            rb.rotation = alpha;
            moveDirect = direct;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirect.x, moveDirect.y) * moveSpeed;
        }
    }
}