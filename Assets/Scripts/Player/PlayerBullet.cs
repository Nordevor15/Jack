using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fuerzaDisparo = 10f;
    public Transform puntoDisparo;
    void Update()
    {
        if(Input.GetButtonDown ("Fire1"))
        {
            ShootBullet();
        } 
    }

    private void ShootBullet()
    {
        Vector3 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posicionMouse.z = 0f;
        Vector2 direccion = (posicionMouse - puntoDisparo.position).normalized;
        GameObject bala = Instantiate(bulletPrefab, puntoDisparo.position, puntoDisparo.rotation);
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        bala.transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
        bala.GetComponent<Rigidbody2D>().AddForce(direccion * fuerzaDisparo, ForceMode2D.Impulse);
    }
}