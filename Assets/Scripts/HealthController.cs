using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour
{
    private int health = 100;

    public int Health
    {
        get { return health; }
    }

    public void SubtractHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
