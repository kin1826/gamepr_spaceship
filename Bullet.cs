using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            var asteroid = collision.GetComponent<Asteroid>();

            if (asteroid != null)
            {
                asteroid.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
