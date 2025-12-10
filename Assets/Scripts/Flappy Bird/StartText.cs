using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class StartText : MonoBehaviour, IPointerClickHandler
{
    public SpriteRenderer sr;
    public float fadeDuration;

    IEnumerator FadeInCoroutine(SpriteRenderer sr, float duration)
    {
        float localFadeTimer = 0f;
        while (localFadeTimer < duration)
        {
            localFadeTimer += Time.unscaledDeltaTime;
            float k = Mathf.Clamp01(localFadeTimer / duration);
            Color c = sr.color; 
            sr.color = new Color(c.r, c.g, c.b, Mathf.Lerp(0f, 1f, k));
            yield return null;
        }
    }

    // Requires Main Camera object to have a Physics 2D Raycaster component
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (GameManager.Instance.State == GameState.Start && pointerEventData.button == PointerEventData.InputButton.Left)
        {
            GameManager.Instance.RunGame();
        }
    }

    void Start()
    {
        Hide();
        fadeDuration = 1f;
    }

    public void Hide()
    {
        sr.enabled = false;
    }

    public void Show()
    {
        sr.enabled = true;
        Color c = sr.color;
        sr.color = new Color(c.r, c.g, c.b, 0f);
        StartCoroutine(FadeInCoroutine(sr, fadeDuration));
    }
}
