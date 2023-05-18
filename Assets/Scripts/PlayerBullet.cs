using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fuerzaDisparo = 10f;
    public Transform puntoDisparo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown ("Fire1"))
        {
            ShootBullet();
        } 
    }

    private void ShootBullet()
    {
        // Se obtiene la posición del puntero del mouse en el mundo
        Vector3 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posicionMouse.z = 0f;

        // Se calcula la dirección en la que se debe mover la bala
        Vector2 direccion = (posicionMouse - puntoDisparo.position).normalized;

        // Se instancia la bala
        GameObject bala = Instantiate(bulletPrefab, puntoDisparo.position, puntoDisparo.rotation);

        // Se rota la bala para que apunte en la dirección del movimiento
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        bala.transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);

        // Se le añade fuerza a la bala para que se mueva en la dirección calculada
        bala.GetComponent<Rigidbody2D>().AddForce(direccion * fuerzaDisparo, ForceMode2D.Impulse);
    }
}