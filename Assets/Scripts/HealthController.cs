using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour
{
    private CameraController cameraController;
    public ShrapnelController[] shrapnelPrefabs;

    private Rigidbody2D rigidbody;
    private int health = 100;

    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void DestroyWithShake()
    {
        const float intensity = 0.3f;
        const float duration = 0.3f;
        cameraController.Shake(intensity, duration);
        Destroy(gameObject);
    }

    private void InstantiateShrapnel()
    {
        foreach (var shrapnel in shrapnelPrefabs)
        {
            // Random position
            const float maxOffset = 0.2f;
            float offsetX = 
                Random.Range(-maxOffset, maxOffset);
            float offsetY =
                Random.Range(-maxOffset, maxOffset);
            Vector2 offset = new Vector2(offsetX, offsetY);
            Vector2 position = (Vector2) transform.position + offset;
            
            // Random rotation
            float angle = Random.Range(0.0f, 360.0f);
            Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, angle);

            Instantiate(shrapnel, position, rotation);
        }
    }

    public int Health
    {
        get { return health; }
    }

    public void SubtractHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            InstantiateShrapnel();
            DestroyWithShake();
        }
    }
}
