using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] private Image flashImage;
    [SerializeField] private float flashDuration = 0.3f;

    public void Flash()
    {
        if (flashImage == null)
        {
            Debug.LogError("flashImage chưa được gán!");
            return;
        }

        StopAllCoroutines();
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        flashImage.color = new Color(1f, 0f, 0f, 0.3f);

        yield return new WaitForSeconds(flashDuration);

        flashImage.color = new Color(1f, 0f, 0f, 0f);
    }
}
