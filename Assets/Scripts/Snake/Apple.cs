using UnityEngine;

public class Apple : MonoBehaviour
{
    void TeleportRandomPosition()
    {
        float randomX = Random.Range(-12.5f, 12.5f);
        float randomY = Random.Range(-9.5f, 9.5f);
        transform.position = new Vector3(randomX, randomY, transform.position.z);
    }

    void Start()
    {
        TeleportRandomPosition();
    }
}
