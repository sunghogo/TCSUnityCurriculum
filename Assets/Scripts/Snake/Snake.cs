using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 direction = Vector3.up;
    public float timer = 0f;
    public float framesPerSecond = 20f;
    float secondsPerFrame;
    public List<SnakeSegment> snakeSegments = new List<SnakeSegment>();

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (direction != Vector3.down) {
                direction = Vector3.up;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (direction != Vector3.up) {
                direction = Vector3.down;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (direction != Vector3.right) {
                direction = Vector3.left;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (direction != Vector3.left) {
                direction = Vector3.right;
            }
        }
    }

    void PropagateDirectionAndMove()
    {
        Vector3 prevDirection = direction;
        Vector3 tempDirection = direction;
        foreach (SnakeSegment snakeSegment in snakeSegments) {
            tempDirection = snakeSegment.direction;
            snakeSegment.direction = prevDirection;
            prevDirection = tempDirection;
            snakeSegment.Move(speed);
        }
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
            timer = 0f;
            PropagateDirectionAndMove();
        }
        timer += Time.fixedDeltaTime;
    }
}
