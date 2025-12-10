using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 direction = Vector3.up;
    public float timer = 0f;
    public float framesPerSecond = 20f;
    float secondsPerFrame;
    public List<SnakeSegment> snakeSegments;

    void Start()
    {
        secondsPerFrame = 1 / framesPerSecond;
        snakeSegments = new List<SnakeSegment>();
    }

    void FixedUpdate()
    {
        if (timer >= secondsPerFrame)
        {
            transform.Translate(direction * speed);
            timer = 0f;
        }
        timer += Time.fixedDeltaTime;
    }
}
