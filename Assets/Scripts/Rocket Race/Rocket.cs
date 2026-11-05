using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float movementSpeed = 29f;
    public Rigidbody2D rigidbody;

    float maxX = 13.333f;
    float minX = -13.333f;
    float maxY = 10.0f;
    float minY = -10.0F;

    void Move()
    {
        // Use the appropriate transform.right/up/down/left given the original sprite's orientation
        rigidbody.AddForce(transform.right * movementSpeed);
    }

    void HandleInput()
    {
        Vector3 rotationVector = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotationVector = Vector3.forward;
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotationVector = Vector3.back;
        }
        transform.Rotate(rotationVector * rotationSpeed * Time.fixedDeltaTime);


        if (Input.GetKey(KeyCode.Space))
        {
            Move();
        }
    }

    void MirrorPosition()
    {
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y >= maxY || transform.position.y <= minY)
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    void FixedUpdate()
    {
        HandleInput();
        MirrorPosition();
    }
}
