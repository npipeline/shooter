using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public float speed;
    public int damage;

    private new Rigidbody2D rigidbody;
    private float startTime;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.up * speed;
        startTime = Time.time;
    }   

    private void FixedUpdate()
    {
        // TODO(jaween): Destroy when out of bounds
        if (Time.time - startTime > 1.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.rigidbody.tag) 
        {
            case "Ship":
                var healthController =
                    collision.gameObject.GetComponent<HealthController>();
                healthController.SubtractHealth(damage);
                StartCoroutine(DestroyAfterDelay());
                break;
            case "Bullet":
                Destroy(collision.gameObject);
                Destroy(this);
                break;
            default:
                break;
        }
    }

    // Gives the bullet a fraction of a second to smash into shrapnel
    private IEnumerator DestroyAfterDelay()
    {
        // Hides the bullet
        GetComponent<SpriteRenderer>().enabled = false;

        // Destroys the bullet after a delay
        const float delay = 0.05f;
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}