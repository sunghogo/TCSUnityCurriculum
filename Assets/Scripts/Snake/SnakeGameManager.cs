using UnityEngine;

public enum GameState
{
    Playing,
    Ending
}

public class SnakeGameManager : MonoBehaviour
{
    public static SnakeGameManager Instance;
    public Snake snakeReference;
    public Apple appleReference;
    public Text scoreTextReference;
    public Text highScoreTextReference;
    public Text gameOverTextReference;
    public SnakeData snakeDataReference;
    public RestartButton restartButtonReference;
    public GameState gameState = GameState.Playing;
    int score = 0;
    int highScore = 0;


    void IntializeInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    public void IncrementScore()
    {
        ++score;
        scoreTextReference.ChangeText("Score", score);
    }

    void ResetScore()
    {
        score = 0;
        scoreTextReference.ChangeText("Score", score);
    }

    public void SetHighScore()
    {
        highScore = highScore > snakeDataReference.highScore ? highScore : snakeDataReference.highScore;
        highScore = score > highScore ? score : highScore;
        snakeDataReference.highScore = highScore;
        highScoreTextReference.ChangeText("Hi-Score", highScore);
    }

    public void PlayGame()
    {
        gameState = GameState.Playing;
        snakeReference.gameObject.SetActive(true);
        appleReference.gameObject.SetActive(true);
        restartButtonReference.HideButton();
        gameOverTextReference.HideText();
        scoreTextReference.ShowText();
        ResetScore();
    }

    public void  EndGame()
    {
        gameState = GameState.Ending;
        snakeReference.gameObject.SetActive(false);
        appleReference.gameObject.SetActive(false);
        scoreTextReference.HideText();
        gameOverTextReference.ShowText();
        restartButtonReference.ShowButton();
        SetHighScore();
    }

    void Start()
    {
        IntializeInstance();
        SetHighScore();
    }

}
