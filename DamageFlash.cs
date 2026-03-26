using UnityEngine;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour
{
    public Image flashImage;
    public float flashDuration = 0.2f;

    public void Flash()
    {
        StopAllCoroutines();
        StartCoroutine(FlashCoroutine());
    }
    
    System.Collections.IEnumerator FlashCoroutine()
    {
        flashImage.color = new Color(1, 80, 80, 0.2f);

        yield return new WaitForSeconds(flashDuration);

        flashImage.color = new Color(1, 0, 0, 0);
    }
}
