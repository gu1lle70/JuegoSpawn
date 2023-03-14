using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;
    [SerializeField] Camera cam;
    [SerializeField] float fireRate;
    private float nextFireTime;
    Vector3 mousePosition;
    
    private void Update()
    {
        // Obtener la posición del ratón en el mundo
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Calcular la dirección hacia la cual debe apuntar el arma
        Vector3 direction = (mousePosition - GameManager.Instance.Gun.transform.position).normalized;

        // Calcular el ángulo de rotación
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotar el objeto que sostiene el arma
        GameManager.Instance.Gun.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));


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