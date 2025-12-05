using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipesPrefab;
    public float spawnsPerSecond;
    float secondsPerSpawn;
    float spawnTimer;
    // public float pipeHeightRange;
    // float spawnerHeight;

    [ContextMenu("Spawn Pipe")]
    public void SpawnPipes()
    {
        // Instantiate(pipesPrefab, transform.position, Quaternion.identity);
        Instantiate(pipesPrefab, transform);
    }

    void Start()
    {
        spawnsPerSecond = 1f;
        secondsPerSpawn = 1 / spawnsPerSecond;
        spawnTimer = 0f;
        // spawnerHeight = transform.position.y;
        // pipeHeightRange = 0.5f;
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.State == GameState.Running)
        {
            spawnTimer += Time.fixedDeltaTime;
            if (spawnTimer >= secondsPerSpawn)
            {
                // float offset = Random.Range(-pipeHeightRange, pipeHeightRange);
                // transform.position = new Vector3(transform.position.x, offset + spawnerHeight, transform.position.z);
                SpawnPipes();
                spawnTimer = 0f;
            }
        }
    }
}
