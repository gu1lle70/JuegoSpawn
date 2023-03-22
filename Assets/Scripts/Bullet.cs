using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 inputBullet;
    [SerializeField] float bulletSpeed = 5 ;

    void FixedUpdate()
    {
        rb.AddForce(transform.right * bulletSpeed );
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

