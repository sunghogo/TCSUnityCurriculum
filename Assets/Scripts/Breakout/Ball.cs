using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 direction = Vector3.zero;

    void Move()
    {
        transform.Translate(direction * speed * Time.fixedDeltaTime);
    }

    void SetRandomDirection()
    {
        float randomX = Mathf.Cos(Random.Range(30f * Mathf.Deg2Rad, 120f * Mathf.Deg2Rad));
        float randomY = Random.Range(0.5f, 1f);
        direction = new Vector2(randomX, randomY).normalized;
    }

    Vector2 Reflect(Vector2 v, Vector2 n)
    {
        Vector2 reflection = v - 2f * Vector2.Dot(v, n) * n;
        reflection.Normalize();
        return reflection;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;
        direction = Reflect(direction, normal);
    }

    void Start()
    {
        SetRandomDirection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
}
