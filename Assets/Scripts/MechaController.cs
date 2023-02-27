using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechaController : MonoBehaviour
{
    [Header("For Movement")]
    [SerializeField] public float speed;
    [SerializeField] Rigidbody2D playerRB;
    public Vector2 input;

    [Header("For Shooring")]
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate;
    private float nextFireTime;
    private Rigidbody2D rb;
    float angle;
    public bool isMoving;
    public static PlayerController instance;
    public GameObject player;

    // Start is called before the first frame update
    public Animator anim;
    public SpriteRenderer sr;
    private TrailRenderer tr;
    private Collider2D coll;

    private float baseGravity;
    public Transform Player;

    public float dashForce = 3000;
    public float dashTime = 0.5f;
    private float Horizontal;

    public bool isDashing = false;
    public bool canDash = true;
    public float candashTime = 1f;
    private float dir;

    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<TrailRenderer>();
        baseGravity = rb.gravityScale;

    }
    private void Awake()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        if (isMoving == true)
        {
            anim.SetBool("Run", true);
        }
        if (isMoving == false)
        {
            anim.SetBool("Run", false);
        }


        
    }

    private void FixedUpdate()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        rb.MovePosition(rb.position + input * speed * Time.fixedDeltaTime);

        if (input.x != 0 || input.y != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (input.x > 0)
        {

            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        if (input.x < 0)
        {

            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        Shooting();

    }

  
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "mecha")
        {
            Debug.Log("hola");
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