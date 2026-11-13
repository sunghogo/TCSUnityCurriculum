using UnityEngine;

public class Rocket : MonoBehaviour
{
    public RR_Score scoreReference; 
    public RR_GameOver gameOverReference;
    public RR_Restart restartButtonReference;

    public float rotationSpeed = 100f;
    public float movementSpeed = 50f;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameOverReference.Show();
        restartButtonReference.Show();
        Time.timeScale = 0f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        scoreReference.IncrementScore();
        Destroy(collision.gameObject);
    }

    void Start()
    {
        Time.timeScale = 1f;
    }

    void FixedUpdate()
    {
        HandleInput();
        MirrorPosition();
    }
}
