using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCharacter : MonoBehaviour
{
    public PlayerController PlayerController;
    public MechaController MechaController;
    public GameObject Player;
    public GameObject Mecha;
    public bool playerActive = true;
    public bool isIn;
    public static SwapCharacter Instance;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isIn = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isIn == true)
        {
            SwitchPlayer();
        }
    }
    public void SwitchPlayer()
    {
        if (playerActive)
        {
            PlayerController.enabled = false;
            MechaController.enabled = true;
            Player.GetComponent<SpriteRenderer>().enabled = false;
            Player.GetComponent<BoxCollider2D>().enabled = false;
            Mecha.GetComponent<SpriteRenderer>().enabled = true;
            Mecha.GetComponent<CircleCollider2D>().enabled = true;
            this.GetComponent<SpriteRenderer>().enabled = false;
            playerActive = false;
        }
        else
        {
            PlayerController.enabled = true;
            Player.GetComponent<SpriteRenderer>().enabled = true;
            Player.GetComponent<BoxCollider2D>().enabled = true;
            Mecha.GetComponent<SpriteRenderer>().enabled = false;
            Mecha.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = true;
            MechaController.enabled = false;
            playerActive = true;   

        }
    }
}
