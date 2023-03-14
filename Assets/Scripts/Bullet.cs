using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    public Rigidbody2D rb;
    public Vector2 inputBullet;

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

