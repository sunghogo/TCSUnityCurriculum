using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour
{   
    public SpriteRenderer topPipeSr;
    public SpriteRenderer bottomPipeSr;

    public float fadeDuration;
    [Range(1f, 5f)] public float speed;
    public float leftXBoundary;
    public float pipesHeightOffsetRange;

    IEnumerator FadeOutThenDestroyCoroutine(SpriteRenderer sr, GameObject go, float duration)
    {
        float localFadeTimer = 0f;
        float alpha = sr.color.a;
        while (localFadeTimer < duration)
        {
            localFadeTimer += Time.unscaledDeltaTime;
            float k = Mathf.Clamp01(localFadeTimer / duration);
            Color c = sr.color; 
            sr.color = new Color(c.r, c.g, c.b, Mathf.Lerp(alpha, 0f, k));
            yield return null;
        }
        Destroy(go);
    }
    
    void Start()
    {
        leftXBoundary = 3.36f * -2f;
        speed = 1f;
        fadeDuration = 1f;
        pipesHeightOffsetRange = 0.5f;
        float offset = Random.Range(-pipesHeightOffsetRange, pipesHeightOffsetRange);
        transform.Translate(0f, offset, 0f);
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.State == GameState.Running)
        {
            Vector3 movement = Vector3.left  * Time.fixedDeltaTime * speed;
            transform.Translate(movement);
            if (transform.position.x <= leftXBoundary)
            {
                Destroy(gameObject);
            }
        } else
        {
            StartCoroutine(FadeOutThenDestroyCoroutine(topPipeSr, gameObject, fadeDuration));
            StartCoroutine(FadeOutThenDestroyCoroutine(bottomPipeSr, gameObject, fadeDuration));
            // Destroy(gameObject);
        }
    }
}
