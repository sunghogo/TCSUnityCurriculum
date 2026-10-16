using UnityEngine;

public class SnakePart : MonoBehaviour
{
    public Vector2 direction = Vector2.up;

    public void Move()
    {
        transform.Translate(direction);
    }
}
