using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate;

    private float nextFireTime;
    public Rigidbody2D rb;
    
    private void Update()
    {
        
        Vector3 difference = GameManager.Instance.mousePos - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90)
        {



            if (GameManager.Instance.Player.transform.eulerAngles.y == 0)
            {


                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);


            }
            else if (GameManager.Instance.Player.transform.eulerAngles.y == 180)
            {


                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);


            }

        }

          Shooting();
        
 }

    void Shooting()
    {

        if (Input.GetButton("Fire1") && nextFireTime < Time.time)
        {
            Debug.Log("Has disparado");
            Instantiate(bullet, transform.position, transform.rotation);    
          
            nextFireTime = fireRate + Time.time;
          
        }

    }
}