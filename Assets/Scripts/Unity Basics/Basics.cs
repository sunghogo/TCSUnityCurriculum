using UnityEngine;

public class Basics : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    Color white;
    Color red;
    Color green;
    Color blue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        white = Color.white;
        red = Color.red;
        green = Color.green;
        blue = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            spriteRenderer.color = red;
        }
        else if (Input.GetKey(KeyCode.G))
        {
            spriteRenderer.color = green;

        }
        else if (Input.GetKey(KeyCode.B))
        {
            spriteRenderer.color = blue;

        }
        else if (Input.GetKey(KeyCode.W))
        {
            spriteRenderer.color = white;
        }
    }
}
