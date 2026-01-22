using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 direction = Vector3.zero;
    
    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
                direction = Vector3.left;
                Move();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
                direction = Vector3.right;
                Move();
        }
    }

    void Move()
    {
        transform.Translate(direction * speed * Time.fixedDeltaTime);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessInput();
    }
}
