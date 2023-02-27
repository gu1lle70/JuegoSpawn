using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salida : MonoBehaviour
{
    public GameObject Object;
    public GameObject MuroSalida;
    public GameObject Player;
    public GameObject mecha;
    public GameObject PlayerPosition;
    public GameObject MechaPosition;
    public bool salida;
    public Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        MuroSalida.SetActive(false);
    }

    // Update is called once per frame

    private void OnTriggerStay2D(Collider2D collision)
    {

        Object.gameObject.SetActive(true);
        salida = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Object.gameObject.SetActive(false);
        salida = false;
    }


    void Update()
    {
        if(Mecha.Instance.dentro == true)
        {

            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (salida == true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pulsar e");
            mecha.transform.parent = null;

            Player.gameObject.transform.position = PlayerPosition.transform.position;
            mecha.gameObject.transform.position = MechaPosition.transform.position;
            Player.GetComponent<Collider2D>().enabled = true;
            Object.SetActive(false);
            
            Camera.orthographicSize = 5;
            Mecha.Instance.dentro = false;
            MuroSalida.SetActive(false);
            salida=false;
            



        }
    }
}
