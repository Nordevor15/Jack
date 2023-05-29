using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector3 direction)
    {
        Vector2 directionNormalized = direction.normalized;
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