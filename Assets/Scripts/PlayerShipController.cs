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
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        bool fire = Input.GetButton("Fire1");

        movementController.Move(horizontalAxis, verticalAxis);

        if (fire)
        {
            Fire();
        }
    }
}
