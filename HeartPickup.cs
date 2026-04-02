using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public int healAmount = 1; // Số lượng máu hồi phục khi nhặt heart

    void Start()
    {
        transform.localScale = new Vector3(0.3f, 0.3f, 1f);

        Destroy(gameObject, 5f); // Xóa heart sau 10 giây nếu không được nhặt
    }

    void Update()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHeath.instance.Heal(healAmount);
            //sound effect
            AudioManager.instance.PlaySFX(AudioManager.instance.healSound);
            Destroy(gameObject); // Xóa heart sau khi nhặt
        }
    }
}
