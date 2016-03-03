using UnityEngine;
using System.Collections;

public class ShrapnelController : MonoBehaviour
{
    // TODO(jaween): Destroy when out of bounds
    public float maxInitialMovement;
     
    private void Start()
    {
        float x = Random.Range(-maxInitialMovement, maxInitialMovement);
        float y = Random.Range(-maxInitialMovement, maxInitialMovement);
        Vector2 velocity = new Vector2(x, y);
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
