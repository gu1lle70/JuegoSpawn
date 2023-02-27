using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3000;
    [SerializeField] Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = player.position - transform.position;
        transform.Translate(newPosition * moveSpeed * Time.deltaTime);
    }
  

}
