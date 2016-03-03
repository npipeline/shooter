using UnityEngine;
using System.Collections;

public class FakornController : ShipController
{
    public float fireDelay;

    private float angle = 0;
    private float nextFireTime;

    protected override void Initialize()
    {
        nextFireTime = GenerateNextFireTime();
    }

    private void FixedUpdate()
    {
        Movement();
        Firing();
    }

    private void Movement()
    {
        float horizontal = Mathf.Cos(angle);
        float vertical = 0.0f;
        angle += Time.fixedDeltaTime;

        movementController.Move(horizontal, vertical);
    }

    private void Firing()
    {
        if (Time.time > nextFireTime)
        {
            Fire();
            nextFireTime = GenerateNextFireTime();
        }
    }

    private float GenerateNextFireTime()
    {
        float min = Time.time + fireDelay;
        float max = min + fireDelay;
        return Random.Range(min, max);
    }
}