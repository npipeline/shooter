using UnityEngine;
using System.Collections;

public abstract class ShipController : MonoBehaviour
{
    // Ships are composed of various controllers
    protected MovementController movementController;
    protected HealthController healthController;
    
    private void Start()
    {
        movementController = GetComponent<MovementController>();
        healthController = GetComponent<HealthController>();

        Initialize();
    }

    // Setup function for derived classes
    protected abstract void Initialize();

    protected void Fire()
    {
        var weapons = GetComponentsInChildren<WeaponController>();
        foreach (var weapon in weapons)
        {
            weapon.Fire();
        }
    }
}