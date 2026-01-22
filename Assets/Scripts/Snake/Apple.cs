using UnityEngine;

public class Apple : MonoBehaviour
{
    public Snake snake;

    void TeleportRandomPosition()
    {
        float randomX = ((int) Random.Range(-12.999f, 12.999f)) + 0.5f;
        float randomY = ((int) Random.Range(-9.999f, 9.999f)) + 0.5f;
        transform.position = new Vector3(randomX, randomY, transform.position.z);
    }

    void Start()
    {
        TeleportRandomPosition();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Snake"))
        {
            TeleportRandomPosition();
            snake.TriggerGrowth();
        }
    }
}
