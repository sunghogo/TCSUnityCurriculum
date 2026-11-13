using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab;
    public int rows = 3;
    [Header("Columns = 1 + 2 * (HalfColumns - 1)")]
    public int halfColumns = 3; // Number of columns spreading out from the center
    public float brickXOffset = 1;
    public float brickYOffset = 1;
    public float brickWidth = 0f;
    public float brickHeight = 0f;

    [ContextMenu("Create Brick")]
    void CreateBrick(Vector2 spawnPosition)
    {
        Instantiate(brickPrefab, spawnPosition, Quaternion.identity, transform);
    }

    void CreateGrid()
    {
        // New method of just spawning bricks according to specified rows, columns, and offsets
        for (int row = 0; row < rows; ++row)
        {
            // Generate random color
            Color randomColor = Random.ColorHSV(
                0f, 1f, // Hue
                0.8f, 1f, // Saturation
                0.8f, 1f // Value
            );

            for (int column = 0; column < halfColumns; ++column)
            {
                // Calculate the position of the center/right brick and create it
                float spawnX = 0f + column * (brickWidth / 2 + 2 * brickXOffset);
                float spawnY = transform.position.y + row * (brickHeight / 2 + brickYOffset);
                Vector2 spawnPosition = new Vector2(spawnX, spawnY);
                GameObject brick = Instantiate(brickPrefab, spawnPosition, Quaternion.identity, transform);
                brick.GetComponent<SpriteRenderer>().color = randomColor;

                // Create the left block symmetrically across the Y-=axis (after the center block)
                if (spawnX != -spawnX)
                {
                    spawnPosition = new Vector2(-spawnX, spawnY);
                    brick = Instantiate(brickPrefab, spawnPosition, Quaternion.identity, transform);
                    brick.GetComponent<SpriteRenderer>().color = randomColor;
                }
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Retrieve and calculate brick dimensions
        Vector3 brickSize = brickPrefab.GetComponent<SpriteRenderer>().bounds.size;
        brickWidth = brickSize.x;
        brickHeight = brickSize.y;

        CreateGrid();
    }
}
