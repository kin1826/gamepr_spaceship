using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public int maxHealth = 2;
    private int currentHealth;

    public GameObject explosionPrefab;

    void Start()
    {
        currentHealth = maxHealth;
        
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        Vector2 dir = new Vector2(-1f, Random.Range(-0.3f, 0.3f)); 
        
        //speed
        speed = Random.Range(2f, 6f);
        
        //size
        float scale = Random.Range(0.2f, 0.6f);
        transform.localScale = new Vector3(scale, scale, 1);
        
        //hướng bay
        rb2d.linearVelocity = dir.normalized * speed;
        
        //rotation
        rb2d.angularVelocity = Random.Range(-200f, 200f);
        
        //destroy
        Destroy(gameObject, 7f);
    }

    void Update()
    {
        
        // nếu ra khỏi màn hình → xóa
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trúng tàu!");
            
            collision.gameObject.GetComponent<PlayerHeath>().TakeDamage(1);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Asteroid HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
