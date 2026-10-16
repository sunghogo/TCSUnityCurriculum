using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab;
    public int gridHalfWidth = 10;
    public int gridHalfHeight = 10;


    [ContextMenu("Create Brick")]
    void CreateBrick(float x, float y)
    {
        Instantiate(brickPrefab, new Vector3(x, y, transform.position.z), Quaternion.identity, transform);
    }

    void CreateBricks()
    {

        for (int x = 0; x < gridHalfWidth; ++x)
        {
            for (int y = 0; y < gridHalfHeight; ++y)
                CreateBrick((float)x, (float)y);
        }     
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateBricks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
