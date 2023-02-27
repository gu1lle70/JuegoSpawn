using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MechaController1 : MonoBehaviour
{
    public SpriteRenderer sr;
    public static MechaController Instance;
    public GameObject TextoEntrada;
    public Sprite PlayerMecha;
    public Sprite noPlayerMecha;
    public GameObject Player;
    public GameObject FollowObject;
    public GameObject MuroSalida;
    public Vector2 input;
    bool enterTrigger = false;
    public bool dentro = false;
    public bool isMoving;
    public Camera Camera;
    public Animator anim;
    // Start is called before the first frame update

    private void Awake()
    {
  
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        TextoEntrada.SetActive(false);
    }

    private void FixedUpdate()
    {
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

            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        if (input.x < 0)
        {

            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!dentro)
        {
        enterTrigger = true;
        Debug.Log("Pulsa E");
        TextoEntrada.gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!dentro) 
        {
        TextoEntrada.gameObject.SetActive(false);
        enterTrigger = false;     
        }
    }
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

        if (enterTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Player.transform.position = this.transform.position;
            Debug.Log("Estas dentro");
            Player.GetComponent<BoxCollider2D>().enabled = false;
            this.transform.parent = Player.transform;
            Camera.orthographicSize = 8;
            dentro = true;

            MuroSalida.SetActive(true);
        }
        if(dentro == true)
        {

            Player.GetComponent<SpriteRenderer>().enabled = false;
            sr.sprite = PlayerMecha;


        }
        if (dentro == false)
        {

            Player.GetComponent<SpriteRenderer>().enabled = true;
            sr.sprite = noPlayerMecha;

        }
    }
}
