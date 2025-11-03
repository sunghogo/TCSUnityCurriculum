using UnityEngine;

public class Pipe : MonoBehaviour
{
    [Range(1f, 5f)] public float speed;
    public float leftXBoundary;

    void Start()
    {
        leftXBoundary = 3.36f * -2f;
        speed = 1f;
    }

    void FixedUpdate()
    {
        Vector3 movement = Vector3.left  * Time.fixedDeltaTime * speed;
        transform.Translate(movement);
        if (transform.position.x <= leftXBoundary)
        {
            
        }
    }
}
