using UnityEngine;

public class Flappy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip flapSFX;
    public AudioClip pointSFX;
    public AudioClip hitSFX;
    public ScoreText scoreText;
    public int score;
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle") && GameManager.Instance.StartState)
        {
            GameManager.Instance.EndGame();
            PlayHitSound();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Point") && GameManager.Instance.StartState)
        {
            ++score;
            scoreText.UpdateScoreText(score);
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
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
            int z = (int)transform.eulerAngles.z; // convert from float to int for direct comparisons
            if ((330 <= z && z <= 360) || (0 <= z && z <= 30) ) {
                transform.Rotate(0, 0, -1f * Time.deltaTime * rotationSpeed);
            }

            if (Input.GetMouseButton(0) && GameManager.Instance.StartState)
            {
                rb.linearVelocityY = jumpingSpeed;
                animator.SetTrigger("Flapping");
                PlayFlapSound();
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 30f);
            }
    }
}
