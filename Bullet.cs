using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = GameConfig.Bullet.damage[0];
    
    public GameObject hitEffectPrefab;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            var asteroid = collision.GetComponent<Asteroid>();

            if (asteroid != null)
            {
                asteroid.TakeDamage(damage);
            }
            
            //xử lý hit effect - Xoay theo hướng mà đạn bắn ra
            GameObject hit = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
            hit.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            //audio hit - no
            // AudioManager.instance.PlaySFX(AudioManager.instance.hitSound);
            
            Destroy(gameObject);
        }
    }
}
