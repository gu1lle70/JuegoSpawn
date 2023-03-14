using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3000;
    public Transform player;
    public Transform mecha;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mecha = GameObject.FindGameObjectWithTag("mecha").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPlayerPosition = player.position - transform.position;
        Vector2 newMechaPosition = mecha.position - transform.position;

        if(SwapCharacter.Instance.playerActive == true)
        {
            transform.Translate(newPlayerPosition * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(newMechaPosition * moveSpeed * Time.deltaTime);

        }

        
    }
  

}
