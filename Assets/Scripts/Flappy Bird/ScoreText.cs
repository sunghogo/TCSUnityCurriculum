using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    
    public void UpdateScore(int score)
    {
        tmp.SetText($"{score}");
    }

    public void Hide()
    {
        tmp.enabled = false;
    }

    public void Show()
    {
        tmp.enabled = true;
    }
}
