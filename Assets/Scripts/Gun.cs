using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField, Range(1f, 20f)]
    private float rotationSpeed;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direccion = MousePoint - (Vector2)transform.position;
        transform.up = Vector2.MoveTowards(transform.up, direccion, rotationSpeed * Time.deltaTime);
    }
}
