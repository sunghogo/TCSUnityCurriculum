using UnityEngine;

public class BrickSpawner2 : MonoBehaviour
{
    public GameObject brickPrefab;
    int halfWidth = 13;
    int halfHeight = 10;
    int brickWidth = 0;
    int brickHeight = 0;

    [ContextMenu("Create Brick")]
    void CreateBrick(Vector2 spawnPosition)
    {
        Instantiate(brickPrefab, spawnPosition, Quaternion.identity, transform);
    }

    void CreateGrid()
    {
        for (int x = -halfWidth + brickWidth / 2; x <= halfWidth; x += brickWidth + 1)
        {
            for (int y = 0; y <= halfHeight; y += brickHeight + 1)
            {
                Vector2 spawnPosition = new Vector2(x, y);
                CreateBrick(spawnPosition);
            }           
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 brickSize = brickPrefab.GetComponent<SpriteRenderer>().bounds.size;
        brickWidth = (int) brickSize.x;
        brickHeight = (int) brickSize.y;

        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
