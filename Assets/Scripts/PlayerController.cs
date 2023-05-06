using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bullet2Prefab;
    public float bulletSpeed = 50f;
    public float bullet2Speed = 50f;
    public float moveSpeed = 5f;
    public int life = 10;
    private Vector2 moveDirection;
    public Rigidbody2D rb;
    public int direction;

    public GameObject spriteRight;
    public GameObject spriteLeft;
    public GameObject spriteUp;
    public GameObject spriteDown;

    private Animator animator;
    private bool Ismoving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        MovePlayer();
        ShootBullet();
        UpdateSprite();
    }
    

    private void MovePlayer()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("horizontal", horizontalInput);
        float verticalInput = Input.GetAxisRaw("Vertical");
        animator.SetFloat("vertical", verticalInput);
        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        //Obtener la posición actual del jugador
        Vector3 currentPosition = transform.position;

        //Calcular la nueva posición del jugador
        Vector3 newPosition = currentPosition + new Vector3(moveDirection.x, moveDirection.y, 0f) * moveSpeed * Time.deltaTime;
        
        //Establecer la nueva posición del jugador
        transform.position = newPosition;
    }
   

    private void ShootBullet()
    {
        if (Input.GetMouseButtonDown(0)) // botón izquierdo
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 playerPos = transform.position;
            Vector3 direction = (mousePos - playerPos).normalized;

            GameObject bullet = Instantiate(bulletPrefab, playerPos, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = direction * bulletSpeed;


        }
        
        else if (Input.GetMouseButtonDown(1)) // botón derecho
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 playerPos = transform.position;
            Vector3 direction = (mousePos - playerPos).normalized;

            GameObject bullet = Instantiate(bullet2Prefab, playerPos, Quaternion.identity);
            Rigidbody2D bullet2Rigidbody = bullet.GetComponent<Rigidbody2D>();
            bullet2Rigidbody.velocity = direction * bullet2Speed;

            
        }
    }

    private void UpdateSprite()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPos = transform.position;
        Vector3 direction = (mousePos - playerPos).normalized;
        UpdateSprite(direction);
    }


    private void UpdateSprite(Vector3 direction)
    {
        double alpha = Math.Atan(direction.y / direction.x)*180/Math.PI; //math pi para ponerlo en decimales y no radianes
        if (direction.x < 0)
        {
            alpha *= -1;
        }
        if (alpha < -45)
        {
            print("down");
            //spritedown
        }
        else if (alpha > 45)
        {
            print("up");
            //spriteUp;
        }
        else
        {
            if (direction.x < 0)
            {
                print("left");
                //spriteLeft;
            }
            else
                print("right");
            //spriteRight;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy1")
        {
            //quitar 1 de vida
            life -= 1;

        }
        //si la vida es 0 destruir al player
        if (life == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Life")
        {
            //sumar 1 de vida
            life += 1;
            //destruir el objeto
        }
        //si la vida es 0 destruir al player
        if (life == 0)
        {
            Destroy(gameObject);
        }
    }
}
