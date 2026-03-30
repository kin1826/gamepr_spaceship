using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed;
    
    public GameObject receivePrefab;
    
    private Transform player;
    
    void Start()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();

        // random hướng bất kỳ - hơi hướng về tâm
        Vector2 toCenter = (Vector2.zero - (Vector2)transform.position).normalized;
        Vector2 randomOffset = Random.insideUnitCircle * 0.5f;

        Vector2 dir = (toCenter + randomOffset).normalized;

        speed = Random.Range(2f, 5f);

        rb2d.linearVelocity = dir * speed;

        rb2d.angularVelocity = Random.Range(-200f, 200f);

        Destroy(gameObject, 7f);
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // collision.gameObject.GetComponent<Player>()
            Instantiate(receivePrefab, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(AudioManager.instance.starSound);
            GameManager.instance.AddProcess(1);
            Destroy(gameObject);
        }
    }
}
