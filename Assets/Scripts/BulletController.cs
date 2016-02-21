﻿using UnityEngine;
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
        startTime = Time.time;
    }

    private void FixedUpdate()
    {
        var movement = transform.up * speed * Time.fixedDeltaTime;
        rigidbody.MovePosition(transform.position + movement);

        // TODO(jaween): Destroy when out of bounds
        if (Time.time - startTime > 1.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.tag == "Ship")
        {
            var healthController =
                collision.gameObject.GetComponent<HealthController>();
            healthController.SubtractHealth(damage);
        }
        Destroy(gameObject);
    }
}