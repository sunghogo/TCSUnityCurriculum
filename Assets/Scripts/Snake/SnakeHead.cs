using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public Text gameOverTextReference;
    public Text scoreTextReference;
    public RestartButton restartButton;


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Method with direct references
        // gameOverTextReference.ShowText();
        // scoreTextReference.HideText();
        // Time.timeScale = 0f;
        // Destroy(transform.parent.gameObject);
        // restartButton.ShowButton();

        // Method with Centralized Game State Manager
        SnakeGameManager.Instance.EndGame();
    }
}
