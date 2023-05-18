using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // En este ejemplo, no hacemos nada en el Update(), ya que la bala se mueve
        // a través de la fuerza que se aplica en el método SetDirection().
    }

    public void SetDirection(Vector3 direction)
    {
        // Normalizamos la dirección para obtener un vector de longitud 1.
        Vector2 directionNormalized = direction.normalized;
        // Aplicamos una fuerza a la bala en la dirección normalizada.
        rb.AddForce(directionNormalized * speed, ForceMode2D.Impulse);
    }

    //si la bala colisiona con el enemy ,que se destruya 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy1")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            DestroyBullet();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        // Desactivar el Collider2D para evitar futuras colisiones
        GetComponent<Collider2D>().enabled = false;
        
        // Desactivar el Rigidbody2D para detener el movimiento de la bala
        GetComponent<Rigidbody2D>().simulated = false;
        
        // Esperar un pequeño tiempo para asegurar que la bala se ha detenido
        // y luego destruirla
        Destroy(gameObject, 0.1f);
    }
}