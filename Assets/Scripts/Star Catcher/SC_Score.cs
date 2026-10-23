using UnityEngine;
using TMPro;

public class SC_Score : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public int score = 0;

    public void IncrementScore()
    {
        ++score;
        tmp.SetText($"Score: {score}");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
