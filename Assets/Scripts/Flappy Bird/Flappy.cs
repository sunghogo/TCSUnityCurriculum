using Unity.Collections;
using UnityEngine;

public class Flappy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip flapSFX;

    void PlayFlap()
    {
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(flapSFX);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int z = (int)transform.eulerAngles.z; // convert from float to int for direct comparisons
        if ((330 <= z && z <= 360) || (0 <= z && z <= 30) ) {
            transform.Rotate(0, 0, -30f * Time.deltaTime);
        }

        if (Input.GetMouseButton(0))
        {
            rb.linearVelocityY = 5f;
            animator.SetTrigger("Flapping");
            PlayFlap();
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 30f);
        }
    }
}
