using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("For Movement")]
    [SerializeField] public float speed;
    [SerializeField] Rigidbody2D playerRB;
    public Vector2 input;
    [SerializeField] Sprite shootArriba;
    [SerializeField] Sprite shootHorizontal;

    [Header("For Shooring")]
    [SerializeField] GameObject bullet;
    private Rigidbody2D rb;

    [Header("For Shooting Direction")]
    public Transform gun;
    public Vector2 direction;

    public bool isMoving;
    public static PlayerController instance;
    public GameObject player;

    // Start is called before the first frame update
    public Animator anim;
    public SpriteRenderer sr;
    private TrailRenderer tr;
    private Collider2D coll;

    private float baseGravity;

    public float dashForce = 3000;
    public float dashTime = 0.5f;
    private float Horizontal;

    public bool isDashing = false;
    public bool canDash = true;
    public float candashTime = 1f;

    
    
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
        instance = this;
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


        if (Input.GetKeyDown(KeyCode.F) && canDash)
        {

            StartCoroutine(Dash());

            Debug.Log("DASHED");

        }
    }


    private void FixedUpdate()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (input.x != 0 || input.y !=0)
        {
            transform.position += new Vector3(speed * input.x * Time.deltaTime, speed * input.y * Time.deltaTime);
        }
        if (input.x != 0 || input.y != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }


        isMoving = input.magnitude > 0;


        // Determinar la posición del mouse en relación con la pantalla
       

        // Girar el personaje hacia la izquierda o hacia la derecha según la posición del mouse
        if (GameManager.Instance.isMouseOnLeft)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
           
    }
    public IEnumerator Dash()
    {
        if (input.x > 0 && canDash)
        {
            isDashing = true;
            canDash = false;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(dashForce * transform.localScale.x, 0);
            anim.SetTrigger("Dash");
            tr.emitting = true;
            coll.sharedMaterial.friction = 1f;
            yield return new WaitForSeconds(dashTime);
            isDashing = false;
            rb.gravityScale = baseGravity;
            tr.emitting = false;
            yield return new WaitForSeconds(candashTime);
            canDash = true;

        }
        if (input.y < 0 && canDash)
        {
            isDashing = true;
            canDash = false;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(dashForce * -transform.localScale.x, 0);
            anim.SetTrigger("Dash");
            tr.emitting = true;
            coll.sharedMaterial.friction = 1f;
            yield return new WaitForSeconds(dashTime);
            isDashing = false;
            rb.gravityScale = baseGravity;
            tr.emitting = false;
            yield return new WaitForSeconds(candashTime);
            canDash = true;

        }



    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "mecha")
        {
            Debug.Log("hola");
        }
    }
    
}