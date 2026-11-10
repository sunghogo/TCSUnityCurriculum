using UnityEngine;

public class Paddle2 : MonoBehaviour
{
    Vector2 direction = Vector2.zero;
    public float speed = 5f;

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        } else
        {
            direction = Vector2.zero;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        transform.Translate(direction * Time.deltaTime * speed);
    }
}
