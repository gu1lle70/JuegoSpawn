using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    public Rigidbody2D rb;

    public Vector2 inputBullet;

    [SerializeField] public Transform Player;
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
    private void Update()
    {
        inputBullet = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    private void FixedUpdate()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Colided");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}

