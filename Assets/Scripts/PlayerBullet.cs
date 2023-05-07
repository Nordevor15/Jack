using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bullet2Prefab;
    public float bulletSpeed = 50f;
    public float bullet2Speed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootBullet();
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
}