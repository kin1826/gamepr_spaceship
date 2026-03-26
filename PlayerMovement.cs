using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A D hoặc ← →
        float moveY = Input.GetAxis("Vertical");   // W S hoặc ↑ ↓

        movement = new Vector2(moveX, moveY);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }
}