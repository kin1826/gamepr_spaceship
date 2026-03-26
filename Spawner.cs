using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject asteroidPrefab;

    public float spawnRate = 2f;
    public float minY = -4f;
    public float maxY = 4f;

    void Start()
    {
        InvokeRepeating("Spawn", 1f, spawnRate);
    }

    void Spawn()
    {
        float y = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(10, y, 0);

        Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
    }
}