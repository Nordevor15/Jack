using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move2 : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Rigidbody2D playerRB;
    private Vector2 moveInput;
    private Animator animator;
    public int life = 10;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
    }

    
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2 (moveX, moveY).normalized;
        animator.SetFloat("horizontal", moveX);
        animator.SetFloat("vertical", moveY);
        animator.SetFloat("speed", moveInput.sqrMagnitude);
        
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + moveInput * speed * Time.deltaTime);

    }
    //si colsiiona con un enemigo pierde vida
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy1")
        {
            life--;
            if (life == 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Defeat");
            }
        }
    }
}