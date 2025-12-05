using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    
    public void UpdateScoreText(int score)
    {
        tmp.SetText($"{score}");
    }

    public void HideText()
    {
        tmp.enabled = false;
    }
}
