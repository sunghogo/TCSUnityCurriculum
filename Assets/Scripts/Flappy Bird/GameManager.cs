using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool StartState { get; private set; }
    
    public void EndGame()
    {
        StartState = false;
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
        StartState = true;
    }
}
