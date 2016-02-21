using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour
{
    private CameraController cameraController;
    private int health = 100;

    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    private void DestroyWithShake()
    {
        cameraController.Shake();
        Destroy(gameObject);
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
            DestroyWithShake();
        }
    }
}
