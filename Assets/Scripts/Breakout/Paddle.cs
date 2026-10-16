using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 5f;
    void HandleInput()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
}
