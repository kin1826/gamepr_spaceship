using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float speed = 1f;
    public float width;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= -width)
        {
            transform.position += new Vector3(width * 2, 0, 0);
        }
    }
}