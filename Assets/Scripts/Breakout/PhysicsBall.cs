using UnityEngine;

public class PhysicsBall : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float movementSpeed = 50f;
    Vector2 direction = Vector2.up;

    void SetRandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(0.5f, 1f);
        direction = new Vector2(randomX, randomY).normalized;
    }

    void Move()
    {
        // Use the appropriate transform.right/up/down/left given the original sprite's orientation
        rigidbody.AddForce(direction * movementSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reflect ball off of surfacen ormals
        Vector2 normal = collision.GetContact(0).normal;
        direction = Vector2.Reflect(direction, normal);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
