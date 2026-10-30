using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float movementSpeed = 29f;
    public Rigidbody2D rigidbody;

    private float maxX = 13.333f;
    private float minX = -13.333f;

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
        transform.Rotate(rotationVector * rotationSpeed * Time.deltaTime);


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
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        HandleInput();
        MirrorPosition();
    }
}
