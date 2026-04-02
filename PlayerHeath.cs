using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    public static PlayerHeath instance;
    
    public int maxHealth = 5; //Not change
    public int currentHealth;

    public UIHealth uiHealth;
    
    public GameObject explosionPrefab;
    
    public CameraShake cameraShake;
    
    public DamageFlash damageFlash;

    public PlayerShield playerShield;
    
    void Start()
    {
        instance = this;
        currentHealth = maxHealth;
        uiHealth.UpdateHearts(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (playerShield != null && playerShield.IsShieldActive())
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.explosionSound);
            return;
        }
            
        currentHealth -= damage;
        cameraShake.Shake();
        damageFlash.Flash();
        
        if (currentHealth <= 0) 
            currentHealth = 0;
        
        uiHealth.UpdateHearts(currentHealth);
        
        //sound effect
        AudioManager.instance.PlaySFX(AudioManager.instance.damageSound);

        if (currentHealth <= 0)
            Die();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        uiHealth.UpdateHearts(currentHealth);
    }

    void Die()
    {
        
        //sound effect
        AudioManager.instance.PlaySFX(AudioManager.instance.shipDestroySound);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
        GameManager.instance.GameOver();
    }
}
