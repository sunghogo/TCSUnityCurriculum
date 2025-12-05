using System.Collections;
using UnityEngine;

public enum GameState
{
    Start,
    Running,
    End    
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState State;
    public ScoreText scoreText;
    public GameOverText gameOverText;
    public StartText startText;
    public Flappy flappy;
    public int score;
    public float transitionDelay;

    IEnumerator StartGameCoroutine(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        StartGame();
    }

    public void EndGame()
    {
        State = GameState.End;
        scoreText.HideText();
        gameOverText.ShowText();
        StartCoroutine(StartGameCoroutine(transitionDelay));
    }

    public void StartGame()
    {
        gameOverText.HideText();
        startText.ShowText();
    }

    public void IncrementScore()
    {
        ++score;
        scoreText.UpdateScoreText(score);
    }

    void InitializeInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    void Start()
    {
        InitializeInstance();
        State = GameState.Running;
        score = 0;
        transitionDelay = 2f;
    }

    void Update()
    {
        
    }
}
