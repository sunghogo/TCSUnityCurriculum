using UnityEngine;
using System.Collections;

public class StartText : MonoBehaviour
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

    void Start()
    {
        HideText();
        fadeDuration = 1f;
    }

    public void HideText()
    {
        sr.enabled = false;
    }

    public void ShowText()
    {
        sr.enabled = true;
        Color c = sr.color;
        sr.color = new Color(c.r, c.g, c.b, 0f);
        StartCoroutine(FadeInCoroutine(sr, fadeDuration));
    }
}
