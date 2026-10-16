using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    public GameObject snakePartReference;
    Vector2 direction = Vector2.up;
    public float framesPerSecond = 20f;
    float secondsPerFrame;
    float timer = 0f;
    public List<SnakePart> snakeParts = new List<SnakePart>();
    public bool isAppleEaten = false;
    public Vector3 spawnPosition;


    void HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) && direction != Vector2.down)
        {
            direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && direction != Vector2.up)
        {
            direction = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && direction != Vector2.right)
        {
            direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && direction != Vector2.left)
        {
            direction = Vector2.right;
        }
    }

    void MoveParts()
    {
        Vector2 tempDir = direction;
        foreach (SnakePart snakePart in snakeParts) {
            Vector2 oldDir = snakePart.direction;
            snakePart.direction = tempDir;
            snakePart.Move();
            tempDir = oldDir;
        }
    }

    // [ContextMenu("Create Snake Body")]
    void GrowSnakeBody(Vector3 position)
    {           
        GameObject newSnakeBody = Instantiate(snakePartReference, position, Quaternion.identity, transform);
        SnakePart newSnakePart = newSnakeBody.GetComponent<SnakePart>();
        snakeParts.Add(newSnakePart);
    }

    public void EatApple()
    {
        isAppleEaten = true;
    }

    void Respawn()
    {
        direction = Vector2.up;
        while(snakeParts.Count > 3)
        {
            SnakePart excessPart = snakeParts[3];
            snakeParts.RemoveAt(3);
            Destroy(excessPart.gameObject);
        }
        float y = spawnPosition.y;
        foreach (SnakePart snakePart in snakeParts)
        {
            snakePart.transform.position = new Vector3(spawnPosition.x, y, transform.position.z);
            --y; 
            snakePart.direction = Vector2.up;
        }
    }

    void Start()
    {
        secondsPerFrame = 1 / framesPerSecond;
    }

    void OnEnable()
    {
        Respawn();
    }

    void Update()
    {
        if (timer >= secondsPerFrame)
        {
            timer = 0f;
            HandleInput();
            Vector3 prevTailPos = snakeParts[snakeParts.Count - 1].transform.position;
            MoveParts();
            if (isAppleEaten)
            {
                GrowSnakeBody(prevTailPos);
                isAppleEaten = false;
            }
        }

        timer += Time.deltaTime;
    }

    // Easier method to implement frame calculation/capping through fixed timescale in Project Settings
    // void FixedUpdate()
    // {
    //     HandleInput();
    //     transform.Translate(direction);
    // }
}
