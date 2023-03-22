using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamExtend : MonoBehaviour
{
    [SerializeField] float maxCam;

    // Update is called once per frame
    void Update()
    {
 
        Vector3 targetPos = (GameManager.Instance.Player.transform.position + GameManager.Instance.mousePos) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -maxCam + GameManager.Instance.Player.transform.position.x, maxCam + GameManager.Instance.Player.transform.position.x );
        targetPos.y = Mathf.Clamp(targetPos.y, -maxCam + GameManager.Instance.Player.transform.position.y, maxCam + GameManager.Instance.Player.transform.position.y );

        this.transform.position = targetPos;
    }
}
