using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipesPrefab;
    public float spawnsPerSecond;
    float secondsPerSpawn;
    public float spawnTimer;

    [ContextMenu("Spawn Pipe")]
    public void SpawnPipes()
    {
        Instantiate(pipesPrefab, transform);
    }

    void Start()
    {
        spawnsPerSecond = 1f;
        secondsPerSpawn = 1 / spawnsPerSecond;
        spawnTimer = 0f;
    }

    void FixedUpdate()
    {
        spawnTimer += Time.fixedDeltaTime;
        if (spawnTimer >= secondsPerSpawn)
        {
            SpawnPipes();
            spawnTimer = 0f;
        }
    }
}
