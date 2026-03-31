using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public float lifetime = 0.1f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
