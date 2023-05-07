using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life;
    private Renderer brunito;

    private void Start()
    {
        brunito = GetComponent<Renderer>();
    }
    void ChangeLife(int value)
    {
        life += value;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bala2"))
        {
            StartCoroutine(rodrigo());
            ChangeLife(-1);
            Destroy(collision.gameObject);
        }
    }
    IEnumerator rodrigo()
    {
        brunito.material.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        brunito.material.color = Color.white;
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
