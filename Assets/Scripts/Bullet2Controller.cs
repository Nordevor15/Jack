using UnityEngine;

public class Bullet2Controller : MonoBehaviour
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy1")
        {
            Destroy(gameObject);
        }
    }
}
