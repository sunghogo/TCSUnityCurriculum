using UnityEngine;

public class PhysicsBall : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float movementSpeed = 50f;

    void Move()
    {
        // Use the appropriate transform.right/up/down/left given the original sprite's orientation
        rigidbody.AddForce(transform.up * movementSpeed);
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
        // direction = Reflect(direction, normal);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
}
