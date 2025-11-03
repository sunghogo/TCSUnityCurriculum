using UnityEngine;

public class Foreground : MonoBehaviour
{
    [Range(1f, 5f)] public float speed;
    public float leftXBoundary;

    void Start()
    {
        leftXBoundary = GetComponent<SpriteRenderer>().localBounds.size.x * -2f;
        speed = 1f;
    }

    void FixedUpdate()
    {
        Vector3 movement = Vector3.left  * Time.fixedDeltaTime * speed;
        transform.Translate(movement);
        if (transform.position.x <= leftXBoundary)
        {
            Vector3 newPosition = new Vector3(-leftXBoundary, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
