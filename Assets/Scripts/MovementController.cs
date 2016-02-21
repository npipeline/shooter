using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public bool keepWithinBounds;
    public float screenWidth;
    public float screenHeight;

    private new Rigidbody rigidbody;

	private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
	}

    public void Move(float horizontalAxis, float verticalAxis)
    {
        var movement =
        Vector3.right * horizontalAxis * horizontalSpeed +
        Vector3.up * verticalAxis * verticalSpeed;

        Vector3 newPosition = transform.position + 
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
}
