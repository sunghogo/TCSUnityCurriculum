using UnityEngine;
using TMPro;

public class RR_Score : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public int score = 0;
    
    // [ContextMenu("Increment Score")]
    public void IncrementScore()
    {
        ++score;
        tmp.SetText($"Score: {score}");
    }
}
