using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 5f;
    Vector2 direction = Vector2.zero;
    public Rigidbody2D rigidbody; // Only necessary if using rigidbody to propel ball

    void HandleInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
    }

    void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.linearVelocityX = 0f; // Only necessary if using rigidbody to propel ball
        HandleInput();
        Move();
    }
}
