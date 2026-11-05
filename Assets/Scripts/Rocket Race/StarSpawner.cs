using UnityEngine;
using System.Collections.Generic;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public List<GameObject> stars = new List<GameObject>();
    public int timeToSpawn = 3;
    int lastTimeSpawned = 0; // Prevent multiple spawns within the second it is valid to spawn

    float maxX = 12.833f;
    float minX = -12.833f;
    float maxY = 9.5f;
    float minY = -9.5F;

    // [ContextMenu("Spawn Star")]
    void SpawnStar()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(randomX, randomY, transform.position.z);
        GameObject starGameObject = Instantiate(starPrefab, spawnPosition, Quaternion.identity, transform);
        stars.Add(starGameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Code to spawn stars every x seconds
        int timeElapsed = (int) Time.time;
        if (timeElapsed != lastTimeSpawned && timeElapsed % timeToSpawn == 0)
        {
            SpawnStar();
            lastTimeSpawned = timeElapsed;  
        }
    }
}
