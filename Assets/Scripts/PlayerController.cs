using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("For Movement")]
    [SerializeField] public float speed;
    [SerializeField] Rigidbody2D playerRB;

    [Header("For Shooring")]
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate;
    private float nextFireTime;
    private Rigidbody2D rb;
    Vector2 input;
    float angle;
    public bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * speed * Time.fixedDeltaTime);
        Shooting();
    }
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");

        input.y = Input.GetAxis("Vertical");

        if (input.x != 0 || input.y != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

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
