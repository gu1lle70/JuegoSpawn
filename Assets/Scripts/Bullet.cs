using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    public Rigidbody2D rb;
    public Vector2 inputBullet;

    [SerializeField] public Transform player;
    [SerializeField] public Transform gun;
    [SerializeField] public Camera cam;

    void Start()
    {
        if (inputBullet.x == 0)
        {
            rb.AddForce(transform.right * bulletSpeed);
        }

        if (inputBullet.x == -1)
        {
            rb.AddForce(-transform.right * bulletSpeed);
        }

        if (inputBullet.y == -1)
        {
            rb.AddForce(-transform.up * bulletSpeed);
        }

        if (inputBullet.y == 1)
        {
            rb.AddForce(transform.up * bulletSpeed);
        }
    }

    void Update()
    {
        inputBullet = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Obtener la posición del mouse en el mundo
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        // Calcular la dirección del arma hacia el mouse
        Vector3 gunDir = mousePos - gun.position;
        gunDir.z = 0;

        // Girar el arma hacia la dirección del mouse
        gun.right = gunDir.normalized;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}

