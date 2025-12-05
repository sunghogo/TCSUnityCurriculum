using System.Collections;
using UnityEngine;

public class Flappy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sr;
    public AudioSource audioSource;
    public AudioClip flapSFX;
    public AudioClip pointSFX;
    public AudioClip hitSFX;
    public float fadeTimer;
    public float fadeDuration;
    [Range(1f, 10f)] public float jumpingSpeed;
    [Range(1f, 180f)] public float rotationSpeed;

    void PlayFlapSound()
    {
        audioSource.PlayOneShot(flapSFX);
    }

    void PlayPointSound()
    {
        audioSource.PlayOneShot(pointSFX);
    }

    void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSFX);
    }

    // void FadeOut(float fadeStrength = 1f)
    // {
    //     Color c = sr.color; 
    //     sr.color = new Color(c.r, c.g, c.b, c.a - fadeStrength);
    // }

    IEnumerator FadeOutCoroutine(SpriteRenderer sr, float duration)
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
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle") && GameManager.Instance.State == GameState.Running)
        {
            GameManager.Instance.EndGame();
            PlayHitSound();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Point") && GameManager.Instance.State == GameState.Running)
        {
            GameManager.Instance.IncrementScore();
            PlayPointSound();
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpingSpeed = 5f;
        rotationSpeed = 30f;
        audioSource.volume = 0.5f;
        fadeTimer = 0f;
        fadeDuration = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        int z = (int)transform.eulerAngles.z; // convert from float to int for direct comparisons
        if ((330 <= z && z <= 360) || (0 <= z && z <= 30) ) {
            transform.Rotate(0, 0, -1f * Time.deltaTime * rotationSpeed);
        }
        
        if (GameManager.Instance.State == GameState.Running)
        {
            if (Input.GetMouseButton(0))
            {
                rb.linearVelocityY = jumpingSpeed;
                animator.SetTrigger("Flapping");
                PlayFlapSound();
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 30f);
            }
        } else
        {
            // sr.enabled = false;
            StartCoroutine(FadeOutCoroutine(sr, fadeDuration));
        }

        // if (!GameManager.Instance.StartState && fadeTimer < fadeDuration)
        // {
        //     fadeTimer += Time.deltaTime;
        //     float fadeStrength = Time.deltaTime / fadeDuration;
        //     FadeOut(fadeStrength);
        // } else
        // {
        //     fadeTimer = 0f;
        // }
    }
}
