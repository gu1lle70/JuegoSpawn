using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed*Time.deltaTime);

        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Colided");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
