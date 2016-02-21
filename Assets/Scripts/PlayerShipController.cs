using UnityEngine;
using System.Collections;
using System;

public class PlayerShipController : ShipController
{
    protected override void Initialize()
    {
        // Nothing to do
    }

    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");
        bool fire = Input.GetButton("Fire1");

        movementController.Move(horizontalAxis, verticalAxis);

        if (fire)
        {
            Fire();
        }
    }
}
