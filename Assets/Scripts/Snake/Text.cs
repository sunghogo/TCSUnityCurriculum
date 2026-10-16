using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    public void ChangeText (string startingText, int score)
    {
        tmp.SetText($"{startingText}: {score}");
    }

    public void HideText()
    {
        tmp.enabled = false;
    }

    public void ShowText()
    {
        tmp.enabled = true;
    }
}
