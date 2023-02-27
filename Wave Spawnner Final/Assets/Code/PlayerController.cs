using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("For Movement")]
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D playerRB;

    [Header("For Shooring")]
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate;
    private float nextFireTime;





    private void FixedUpdate()
    {
        Movement(Input.GetAxis("Horizontal"));
        Shooting();
    }

    void Movement(float moveDirection)
    {
        playerRB.velocity = new Vector2(moveDirection * speed * Time.fixedDeltaTime, playerRB.velocity.y);
    }

    void Shooting()
    {
        if (Input.GetKey(KeyCode.Space) && nextFireTime < Time.time)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            nextFireTime = fireRate + Time.time;
        }
    }
}
