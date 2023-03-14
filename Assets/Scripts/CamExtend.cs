using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamExtend : MonoBehaviour
{
    public Camera Camera;
    [SerializeField] float pointerCam;

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Camera.ScreenToWorldPoint(Input.mousePosition );
        Vector3 targetPos = (GameManager.Instance.Player.transform.position + mousePos ) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -pointerCam + GameManager.Instance.Player.transform.position.x, pointerCam + GameManager.Instance.Player.transform.position.x );
        targetPos.y = Mathf.Clamp(targetPos.y, -pointerCam + GameManager.Instance.Player.transform.position.y, pointerCam + GameManager.Instance.Player.transform.position.y );

        this.transform.position = targetPos;
    }
}
