using System.Runtime.CompilerServices;
using UnityEngine;

public class Star : MonoBehaviour
{
    // Set AudioSource reference (in the inspector)
    public AudioSource audioSource;

    // Set SpriteRenderer reference (in the inspector)
    public SpriteRenderer spriteRenderer;
    public SC_Score sc_score;

    void OnMouseDown()
    {
            // Randomly move star/circle inside the play grid (measure the grid units through the Scene Window)
            int randomX = Random.Range(-6, 6);
            int randomY = Random.Range(-4, 4);
            transform.position = new Vector3(randomX, randomY, transform.position.z);

            // Play AudioClip loaded into AudioSource (through the inspector)
            audioSource.Play();

            // Randomly resize the star/circle
            float randomSize = Random.Range(0.25f, 1f);
            transform.localScale = new Vector3(randomSize, randomSize, randomSize);

            // Randomly set the color of star/cirlce
            float randomR = Random.Range(0f, 1f);
            float randomG = Random.Range(0f, 1f);
            float randomB = Random.Range(0f, 1f);
            Color randomColor = new Color(randomR, randomG, randomB);
            spriteRenderer.color = randomColor;

            // Increment and change score in TMP object
            sc_score.IncrementScore();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomR = Random.Range(0f, 1f);
        float randomG = Random.Range(0f, 1f);
        float randomB = Random.Range(0f, 1f);
        Color randomColor = new Color(randomR, randomG, randomB);
        spriteRenderer.color = randomColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
