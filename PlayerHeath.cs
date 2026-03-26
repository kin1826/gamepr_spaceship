using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public UIHealth uiHealth;
    
    public GameObject explosionPrefab;
    
    public CameraShake cameraShake;
    
    public DamageFlash damageFlash;
    
    void Start()
    {
        currentHealth = maxHealth;
        uiHealth.UpdateHearts(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        cameraShake.Shake();
        damageFlash.Flash();
        
        if (currentHealth <= 0) 
            currentHealth = 0;
        
        uiHealth.UpdateHearts(currentHealth);

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Game Over");
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
