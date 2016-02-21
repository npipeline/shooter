using UnityEngine;
using System.Collections;

public class ExampleBotShipController : ShipController
{
    public float fireDelay;

    private Vector2 startPosition;
    private float angle = 0;
    private float lastFireTime;

    protected override void Initialize()
    {
        startPosition = transform.position;
        lastFireTime = Time.time;
    }

    private void FixedUpdate()
    {
        Movement();
        Firing();
    }

    // Example spinning ship
    private void Movement()
    {
        const float radius = 2;

        float horizontal = Mathf.Sin(angle) * radius;
        float vertical = Mathf.Cos(angle) * radius;
        angle += Time.fixedDeltaTime;

        movementController.Move(horizontal, vertical);
    }

    // Example firing
    private void Firing()
    {
        var lastFireTimeDelta = Time.time - lastFireTime;
        if (lastFireTimeDelta > fireDelay)
        {
            Fire();
            lastFireTime = Time.time;
        }
    }
}