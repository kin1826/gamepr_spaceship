using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePointLeft;
    public Transform firePointRight;
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Fire(firePointLeft);
        Fire(firePointRight);
    }

    void Fire(Transform firePoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.linearVelocity = transform.up * bulletSpeed;

        Destroy(bullet, 3f); // sau 3 giây tự hủy
    }
}