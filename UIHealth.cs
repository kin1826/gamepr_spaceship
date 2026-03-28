using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Image[] hearts;

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // hearts[i].enabled = i < currentHealth;
            
            hearts[i].color = (i < currentHealth) 
                ? Color.white 
                : new Color(1,1,1,0.3f);
        }
    }
}