using UnityEngine;
using System.Collections.Generic;
using System.Drawing;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject planetPrefab;
    public List<GameObject> planets = new List<GameObject>();
    public int timeToSpawn = 7;
    int lastTimeSpawned = 0; // Prevent multiple spawns within the second it is valid to spawn

    float maxX = 12.833f;
    float minX = -12.833f;
    float maxY = 9.5f;
    float minY = -9.5F;
    
    public float minScale = 1f;
    public float maxScale = 4f;

    // [ContextMenu("Spawn Planet")] s
    void SpawnPlanet()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(randomX, randomY, transform.position.z);
        GameObject planetGameObject = Instantiate(planetPrefab, spawnPosition, Quaternion.identity, transform);
        float randomScale = Random.Range(minScale, maxScale);
        float randomAngle = Random.Range(0f, 360f);
        planetGameObject.transform.localScale = new Vector3(randomScale, randomScale, 1f); 
        planetGameObject.transform.Rotate(0f, 0f, randomAngle);
        planets.Add(planetGameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Code to spawn stars every x seconds
        int timeElapsed = (int) Time.time;
        if (timeElapsed != lastTimeSpawned && timeElapsed % timeToSpawn == 0)
        {
            SpawnPlanet();
            lastTimeSpawned = timeElapsed;  
        }
    }
}
