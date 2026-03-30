using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject asteroidPrefab;

    public float spawnRate = 2f;
    public float minY = -4f;
    public float maxY = 4f;
    public float minX = -4f;
    public float maxX = 4f;

    void Start()
    {
        InvokeRepeating("Spawn", 0.2f, spawnRate);
    }

    void Spawn()
    {
        float y = Random.Range(minY, maxY);
        
        float x = Random.Range(minX, maxX);

        Vector3 spawnPos = new Vector3(10, y, 0);

        Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
    }
}