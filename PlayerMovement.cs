using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = GameConfig.Player.speed[0];
    private float baseSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;

    public GameObject energyPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        baseSpeed = speed;

        if (energyPrefab != null)
        {
            energyPrefab.SetActive(false);
        }
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A D hoặc ← →
        float moveY = Input.GetAxis("Vertical");   // W S hoặc ↑ ↓

        movement = new Vector2(moveX, moveY);

        bool isBoost = Input.GetKey(KeyCode.Space);

        // Gọi GameManager để xử lý energy
        GameManager.instance.UpdateEnergy(isBoost);

        // Chỉ boost nếu còn năng lượng
        if (isBoost && GameManager.instance.CanBoost())
        {
            speed = baseSpeed * 1.5f; // tăng tốc khi giữ Space
        }
        else
        {
            speed = baseSpeed; // trở về tốc độ bình thường
        }

        if (energyPrefab != null)
        {
            energyPrefab.SetActive(isBoost && GameManager.instance.CanBoost());
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }
}