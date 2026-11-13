using UnityEngine;
using TMPro;

public class RR_Start : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public int timeToShow= 3;

    public void Hide()
    {
        tmp.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToShow)
        {
            Hide();
        }
    }
}
