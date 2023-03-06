using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamExtend : MonoBehaviour
{
    public Camera Camera;
    public Transform Player;
    [SerializeField] float pointerCam;

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Camera.ScreenToWorldPoint(Input.mousePosition );
        Vector3 targetPos = (Player.position + mousePos ) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -pointerCam + Player.position.x, pointerCam + Player.position.x );
        targetPos.y = Mathf.Clamp(targetPos.y, -pointerCam + Player.position.y, pointerCam + Player.position.y );

        this.transform.position = targetPos;
    }
}
