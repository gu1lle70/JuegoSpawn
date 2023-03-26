using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
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
            GameManager.Instance.Cam.orthographicSize = 7;
            transform.position = Vector3.Lerp(transform.position, GameManager.Instance.Player.transform.position, velocity * Time.deltaTime);
        }
        else
        {
            GameManager.Instance.Cam.orthographicSize = 8;
            transform.position = Vector3.Lerp(transform.position, GameManager.Instance.Mecha.transform.position, velocity * Time.deltaTime);

        }
        
    }
}

