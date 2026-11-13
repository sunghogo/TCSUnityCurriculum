using UnityEngine;
using TMPro;

public class RR_GameOver : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    
    public void Hide()
    {
        tmp.enabled = false;
    }
    
    public void Show()
    {
        tmp.enabled = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hide();
    }
}
