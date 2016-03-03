using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public bool keepWithinBounds;
    public float screenWidth;
    public float screenHeight;

    private new Rigidbody2D rigidbody;
    private float horizontalSum = 0;
    private float verticalSum = 0;

	private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
	}

    private void FixedUpdate()
    {
        MoveInternal();
    }

    private void MoveInternal()
    {
        var movement =
            Vector2.right * horizontalSum * horizontalSpeed +
            Vector2.up * verticalSum * verticalSpeed;

        horizontalSum = 0;
        verticalSum = 0;
        
        Vector2 newPosition = rigidbody.position + 
            movement * Time.fixedDeltaTime;
        
        if (keepWithinBounds)
        {
            float xBound = screenWidth / 2.0f;
            float yBound = screenHeight / 2.0f;
            newPosition.x = Mathf.Clamp(newPosition.x, -xBound, xBound);
            newPosition.y = Mathf.Clamp(newPosition.y, -yBound, yBound);
        }

        rigidbody.MovePosition(newPosition);
    }

    public void Move(float horizontalAxis, float verticalAxis)
    {
        // Holds onto all the inputs until FixedUpdate()
        horizontalSum += horizontalAxis;
        verticalSum += verticalAxis;
    }
}
