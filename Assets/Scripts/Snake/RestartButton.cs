using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RestartButton : MonoBehaviour
{
    public Image buttonImage;
    public TextMeshProUGUI buttonText;

    public void HideButton()
    {
        buttonImage.enabled = false;
        buttonText.enabled = false;
    }

    public void ShowButton()
    {
        buttonImage.enabled = true;
        buttonText.enabled = true;
    }

    public void OnButtonClicked()
    {
        // Method to quickly restart level but no data persistance
        Time.timeScale = 1f;
        SnakeGameManager.Instance.SetHighScore();
        SceneManager.LoadScene(1);

        // Method with data persistance but more difficult to manually reset all objects
        // SnakeGameManager.Instance.PlayGame();
    }
}
