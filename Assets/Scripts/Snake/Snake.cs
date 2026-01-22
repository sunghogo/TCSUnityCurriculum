using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    public GameObject snakePrefab;
    public float speed = 1f;
    public Vector3 direction = Vector3.up;
    public Vector3 nextDirection = Vector3.up;
    public Vector3 oldTailPosition = Vector3.up;
    public bool isAppleEaten = false;
    public bool isSnakeGrowing = false;
    public float timer = 0f;
    public float framesPerSecond = 20f;
    float secondsPerFrame;
    public List<SnakeSegment> snakeSegments = new List<SnakeSegment>();

    public void TriggerGrowth()
    {
        isAppleEaten = true;
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (direction != Vector3.down) {
                nextDirection = Vector3.up;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (direction != Vector3.up) {
                nextDirection = Vector3.down;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (direction != Vector3.right) {
                nextDirection = Vector3.left;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (direction != Vector3.left) {
                nextDirection = Vector3.right;
            }
        }
    }

    void PropagateDirectionAndMove()
    {
        Vector3 prevDirection = direction;
        Vector3 tempDirection = direction;
        int snakeListLength = snakeSegments.Count;
        for (int i = 0; i < snakeListLength; ++i) {
            SnakeSegment snakeSegment = snakeSegments[i];
            if (i == snakeListLength - 1)
            {
                oldTailPosition = snakeSegment.gameObject.transform.position;
            }
            tempDirection = snakeSegment.direction;
            snakeSegment.direction = prevDirection;
            prevDirection = tempDirection;
            snakeSegment.Move(speed);
        }
        if (isSnakeGrowing)
        {
            GrowSnake(oldTailPosition);
            isSnakeGrowing = false;
        }
    }

    void GrowSnake(Vector3 position)
    {
        GameObject newBody = Instantiate(snakePrefab, position, Quaternion.identity, transform);
        SnakeSegment newBodySegment = newBody.GetComponent<SnakeSegment>();
        snakeSegments.Add(newBodySegment);
    }

    void Start()
    {
        secondsPerFrame = 1 / framesPerSecond;
        // SnakeSegment[] snakeSegmentsArray = GetComponentsInChildren<SnakeSegment>();
        // snakeSegments = new List<SnakeSegment>(snakeSegmentsArray);
    }

    void FixedUpdate()
    {
        ProcessInput();

        if (timer >= secondsPerFrame)
        {
            if (isAppleEaten)
            {
                isSnakeGrowing = true;
                isAppleEaten = false;
            }

            direction = nextDirection;
            timer = 0f;
            PropagateDirectionAndMove();
        }
        timer += Time.fixedDeltaTime;
    }
}
