using UnityEngine;

public class SnakeSegment : MonoBehaviour
{
    public Vector3 movement = Vector3.up;


    public void Move()
    {
        transform.Translate(movement);
    }
}
