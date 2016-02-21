using UnityEngine;
using System.Collections;

public class EnemySpawnController : MonoBehaviour
{
    // TODO(jaween): Some sort of enemy wave 
    public GameObject[] enemies;

    private void Start()
    {
        TempCreateEnemies();
    }

    private void TempCreateEnemies()
    {
        Vector2 position = new Vector2(-3.0f, 3.0f);
        float gap = 2.0f;
        foreach (var enemy in enemies)
        {
            Instantiate(enemy, position, Quaternion.identity);
            position += gap * Vector2.right;
        }
    }
}