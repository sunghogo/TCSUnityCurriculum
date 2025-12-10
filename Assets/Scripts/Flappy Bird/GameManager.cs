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
        scoreText.Hide();
        gameOverText.ShowText();
        StartCoroutine(StartGameCoroutine(transitionDelay));
    }

    public void StartGame()
    {
        State = GameState.Start;
        gameOverText.HideText();
        startText.Show();
        score = 0;
        scoreText.UpdateScore(score);
    }

    public void RunGame()
    {
        State = GameState.Running;
        startText.Hide();
        flappy.Reset();
        scoreText.Show();
    }

    public void IncrementScore()
    {
        ++score;
        scoreText.UpdateScore(score);
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
