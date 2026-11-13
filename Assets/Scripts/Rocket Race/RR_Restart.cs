using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RR_Restart : MonoBehaviour
{
    public Image buttonImage;
    public TextMeshProUGUI buttonText;

    public void Hide()
    {
        buttonImage.enabled = false;
        buttonText.enabled = false;
    }

    public void Show()
    {
        buttonImage.enabled = true;
        buttonText.enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
