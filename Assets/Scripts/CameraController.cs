using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private Vector3 startPosition;
    private bool shake = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (shake)
        {
            StartCoroutine(ShakeCoroutine());
            shake = false;
        }
    }

    private IEnumerator ShakeCoroutine()
    {
        const float maxX = 0.05f;
        const float maxY = 0.05f;

        float startTime = Time.time;
        float duration = 0.1f;
        float interpolant = 0.0f;
        while (interpolant <= 1.0f)
        {
            float x = Random.Range(-maxX, maxX);
            float y = Random.Range(-maxY, maxY);
            Vector3 movement = new Vector2(x, y);
            transform.position = startPosition + movement;
            float timeDelta = Time.time - startTime;
            interpolant = timeDelta / duration;
            yield return new WaitForSeconds(0.03f);
        }
        transform.position = startPosition;
    }

    public void Shake()
    {
        shake = true;
        StartCoroutine(ShakeCoroutine());

    }
}
