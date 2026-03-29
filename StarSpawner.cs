using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public float spawnRate = 1.5f;

    public float minY = -4f;
    public float maxY = 4f;
    public float minX = -4f;
    public float maxX = 4f;

    public float spawnoffset = 1.5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnStar), 1f, spawnRate);
    }

    void SpawnStar()
    {
        // float y = Random.Range(minX, maxY);
        //
        // float x = Random.Range(minX, maxX);
        
        int side = Random.Range(0, 4); // 0: trái, 1: phải, 2: trên, 3: dưới

        float x = 0f;
        float y = 0f;

        switch (side)
        {
            case 0: // trái
                x = minX - spawnoffset;
                y = Random.Range(minY, maxY);
                break;

            case 1: // phải
                x = maxX + spawnoffset;
                y = Random.Range(minY, maxY);
                break;

            case 2: // trên
                x = Random.Range(minX, maxX);
                y = maxY + spawnoffset;
                break;

            case 3: // dưới
                x = Random.Range(minX, maxX);
                y = minY - spawnoffset;
                break;
        }

        Vector3 spawnPos = new Vector3(x, y, 0);

        Instantiate(starPrefab, spawnPos, Quaternion.identity);
    }
}