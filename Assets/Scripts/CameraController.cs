using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private IEnumerator ShakeCoroutine(float startIntensity, float duration)
    {
        float intensity = startIntensity;
        float startTime = Time.time;
        while (intensity > 0)
        {
            Vector3 movement = Random.insideUnitCircle * intensity;
            transform.position = startPosition + movement;

            float animationRatio = (Time.time - startTime) / duration;
            intensity = startIntensity * (1 - animationRatio);
            yield return new WaitForEndOfFrame();
        }
        transform.position = startPosition;
    }

    public void Shake(float intensity, float duration)
    {
        StartCoroutine(ShakeCoroutine(intensity, duration));
    }
}
