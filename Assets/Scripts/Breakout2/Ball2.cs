using UnityEngine;

public class Ball2 : MonoBehaviour
{
    Vector2 direction = Vector2.zero;
    public float speed = 5f;
    Vector3 startingPosition = Vector3.zero;

    void SetRandomDirection()
    {
        float randomX = Random.Range(-0.5f, 0.5f);
        float randomY = Random.Range(0.5f, 1f);
        direction = new Vector2(randomX, randomY).normalized;    
    }

    void ResetPosition()
    {
        transform.position = startingPosition;
    }

    void Move()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    Vector2 Reflect(Vector2 v, Vector2 n)
    {
        Vector2 reflection = v - 2f * Vector2.Dot(v, n) * n;
        reflection.Normalize();
        return reflection;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 surfaceNormal = collision.GetContact(0).normal;
        Vector2 reflection = Reflect(direction, surfaceNormal);
        direction = reflection;
    }

    void OnTriggerEnter2D(Collider2D other) {
        SetRandomDirection();
        ResetPosition();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetRandomDirection();
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
