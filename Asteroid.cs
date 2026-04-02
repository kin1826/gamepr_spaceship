using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public int maxHealth = 5;
    private int currentHealth;
    private float scale;

    public GameObject explosionPrefab;
    
    private Transform player;

    public GameObject heartPrefab;
    [Range(0f, 1f)] public float heartDropChance = 0.3f; // 0% đến 100% cơ hội rơi heart

    void Start()
    {
        // currentHealth = maxHealth;
        
        //get Player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        Vector2 dir = (player.position - transform.position).normalized;
        
        //speed
        speed = Random.Range(4f, 8f);
        
        //size
        scale = Random.Range(0.2f, 0.6f);
        transform.localScale = new Vector3(scale, scale, 1);
        
        //hướng bay
        rb2d.linearVelocity = dir * speed;
        
        //rotation
        rb2d.angularVelocity = Random.Range(-200f, 200f);
        
        //health theo size
        currentHealth = maxHealth + Mathf.RoundToInt(scale * 10);
        
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
            int score = Mathf.RoundToInt(scale * 20);
            GameManager.instance.AddScore(score);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //sound
            AudioManager.instance.PlaySFX(AudioManager.instance.explosionSound);
            RandHeartDrop();
            Destroy(gameObject);
        }
    }

    public void RandHeartDrop()
    {
        float rand = Random.value; // 0.0 đến 1.0

        if (rand < heartDropChance)
        {
            Instantiate(heartPrefab, transform.position, Quaternion.identity);
        }
    }
}
