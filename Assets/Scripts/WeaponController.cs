using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireDelay;

    private float lastFireTime;

    private void Start()
    {
        lastFireTime = Time.time;
    }
    
    public void Fire()
    {
        // Fires on a delay
        float lastFireTimeDelta = Time.time - lastFireTime;
        if (lastFireTimeDelta > fireDelay)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            lastFireTime = Time.time;
        }
    }
}
