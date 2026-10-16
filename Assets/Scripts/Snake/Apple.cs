using UnityEngine;

public class Apple : MonoBehaviour
{
    public void Respawn()
    {
        float offset = 0.5f;
        float randomX = Random.Range(-12, 12) + offset;
        float randomY = Random.Range(-9, 9) + offset;
        transform.position = new Vector3(randomX, randomY, transform.position.z);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Respawn();
    }

    void OnEnable()
    {
        Respawn();
    }

    void OnTriggerEnter2D(Collider2D other) {
        // Method to specify collision object and call public functions
        // GameObject snakeObject = other.gameObject;
        // GetComponentInParent<Snake>(snakeObject).EatApple();

        // Method using centralized GameStateManager
        SnakeGameManager.Instance.snakeReference.EatApple();
        SnakeGameManager.Instance.IncrementScore();
        Respawn();
    }
    
}
