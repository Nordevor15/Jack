using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Rigidbody2D playerRB;
    private Vector2 moveInput;
    private Animator animator;
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
        if (moveInput.x != 0) moveInput.y = 0;
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + moveInput * speed * Time.deltaTime);

    }
}
