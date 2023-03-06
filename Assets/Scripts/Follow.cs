using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Camera Camera;
    public Transform Player;
    public Transform Mecha;
    public float velocity;
    [SerializeField] float pointerCam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        if (SwapCharacter.Instance.playerActive == true)
        {
            Camera.orthographicSize = 6;
            transform.position = Vector3.Lerp(transform.position, Player.transform.position, velocity * Time.deltaTime);
        }
        else
        {
            Camera.orthographicSize = 8;
            transform.position = Vector3.Lerp(transform.position, Mecha.transform.position, velocity * Time.deltaTime);
        }  

        
    }
}

