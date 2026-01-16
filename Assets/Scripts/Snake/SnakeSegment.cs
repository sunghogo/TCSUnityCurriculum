using UnityEngine;

public class SnakeSegment : MonoBehaviour
{
    public Vector3 direction = Vector3.up;

    public void Move(float speed)
    {
        transform.Translate(direction * speed);
    }
}
