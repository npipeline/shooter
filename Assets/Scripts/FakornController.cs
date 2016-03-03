using UnityEngine;
using System.Collections;

public class FakornController : ShipController
{
    public float fireDelay;
	public float verticalAlternatationDelay;

    private float angle = 0;
	private float verticalAlternator = -1f;
	private float nextFireTime;
	private float nextAlternationTime;

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
		float vertical = verticalAlternator;
		if (Time.time > nextAlternationTime)
		{
			nextAlternationTime = GenerateVerticalAlterationTime();
			verticalAlternator = verticalAlternator * -1;
		}
//        angle += Time.fixedDeltaTime;

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
	private float GenerateVerticalAlterationTime()
	{
		float min = Time.time + verticalAlternatationDelay;
		float max = min + verticalAlternatationDelay;
		return Random.Range(min, max);
	}

    private float GenerateNextFireTime()
    {
        float min = Time.time + fireDelay;
        float max = min + fireDelay;
        return Random.Range(min, max);
    }
}