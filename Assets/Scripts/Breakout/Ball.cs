using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 direction = Vector2.up;
    public Vector2 startingPosition;

    void Move()
    {
        transform.Translate(speed * direction * Time.deltaTime);
    }

    void SetRandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(0.5f, 1f);
        direction = new Vector2(randomX, randomY).normalized;
    }

    Vector2 Reflect(Vector2 v, Vector2 n)
    {
        Vector2 reflection = v - 2f * Vector2.Dot(v, n) * n;
        reflection.Normalize();
        return reflection;
    }

    void Reset()
    {
        transform.position = startingPosition;
        SetRandomDirection();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;
        direction = Reflect(direction, normal);
        // if (collision.gameObject.CompareTag("Paddle"))
        // {
        //     float yOffset = Random.Range(-0.2f, 0.2f);
        //     direction =  new Vector2(direction.x, Mathf.Clamp(direction.y + yOffset, 0.2f, 0.8f)).normalized;
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Reset();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPosition = transform.position;
        SetRandomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
