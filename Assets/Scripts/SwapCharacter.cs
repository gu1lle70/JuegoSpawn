using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCharacter : MonoBehaviour
{
    public PlayerController PlayerController;
    public MechaController MechaController;
    public Weapon WeaponController;
    public CamExtend CamPlayer;
    public Follow CamMecha;

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
            //DesactivarScript Player-Arma-Cam
            PlayerController.enabled = false;
            WeaponController.enabled = false;
            //Camara
            CamPlayer.enabled = false;
            CamMecha.enabled = true;
            //ActivarMecha
            MechaController.enabled = true;
            //Desactivar spriteArma
            GameManager.Instance.Gun.GetComponent<SpriteRenderer>().enabled = false;
            //Desactivar Player sprite-collider
            GameManager.Instance.Player.GetComponent<SpriteRenderer>().enabled = false;
            GameManager.Instance.Player.GetComponent<BoxCollider2D>().enabled = false;
            //ActivarMecha sprite-collider
            GameManager.Instance.Mecha.GetComponent<SpriteRenderer>().enabled = true;
            GameManager.Instance.Mecha.GetComponent<CircleCollider2D>().enabled = true;

            this.GetComponent<SpriteRenderer>().enabled = false;
            playerActive = false;
        }
        else
        {
            //ActivarScript Player-Arma-Cam
            PlayerController.enabled = true;
            WeaponController.enabled = true;

            //Camera
            CamPlayer.enabled = true;
            CamMecha.enabled = false;
            //ActivarMecha
            MechaController.enabled = false;
            //Activar spriteArma
            GameManager.Instance.Gun.GetComponent<SpriteRenderer>().enabled = true;
            //Activar Player sprite-collider
            GameManager.Instance.Player.GetComponent<SpriteRenderer>().enabled = true;
            GameManager.Instance.Player.GetComponent<BoxCollider2D>().enabled = true;
            //DesActivarMecha sprite-collider
            GameManager.Instance.Mecha.GetComponent<SpriteRenderer>().enabled = false;
            GameManager.Instance.Mecha.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = true;
            
            GameManager.Instance.Mecha.transform.position = this.transform.position;
            playerActive = true;   

        }
    }
}
