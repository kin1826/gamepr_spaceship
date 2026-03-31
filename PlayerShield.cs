using UnityEngine;
using System.Collections;

public class PlayerShield : MonoBehaviour
{
    public GameObject shieldObject; // object khiên
    public float duration = GameConfig.Shields.duration;
    public float blinkTime = GameConfig.Shields.blinkTime; // thời gian chớp trước khi hết

    private SpriteRenderer sr;
    private bool isActive = false;

    void Start()
    {
        sr = shieldObject.GetComponent<SpriteRenderer>();
        shieldObject.SetActive(false);
    }
    void Update()
    {
        if (isActive)
        {
            shieldObject.transform.Rotate(0, 0, 200 * Time.deltaTime);
        }
    }

    public void ActivateShield()
    {
        StopAllCoroutines();
        StartCoroutine(ShieldRoutine());
    }

    IEnumerator ShieldRoutine()
    {
        isActive = true;
        shieldObject.SetActive(true);

        float timer = 0f;

        // 👉 chạy bình thường
        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        // 👉 nháy 3 lần
        for (int i = 0; i < 3; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.3f);

            sr.enabled = true;
            yield return new WaitForSeconds(0.3f);
        }

        // 👉 tắt hẳn
        shieldObject.SetActive(false);
        isActive = false;
    }

    public bool IsShieldActive()
    {
        return isActive;
    }
}