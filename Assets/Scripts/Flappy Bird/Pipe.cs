using UnityEngine;

public class Pipe : MonoBehaviour
{
    [Range(1f, 5f)] public float speed;
    public float leftXBoundary;
    public float pipesHeightOffsetRange;

    void Start()
    {
        leftXBoundary = 3.36f * -2f;
        speed = 1f;
        pipesHeightOffsetRange = 0.5f;
        float offset = Random.Range(-pipesHeightOffsetRange, pipesHeightOffsetRange);
        transform.Translate(0f, offset, 0f);
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.StartState)
        {
            Vector3 movement = Vector3.left  * Time.fixedDeltaTime * speed;
            transform.Translate(movement);
            if (transform.position.x <= leftXBoundary)
            {
                Destroy(gameObject);
            }
        }
    }
}
