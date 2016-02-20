using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;

    private new Rigidbody rigidbody;

	private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
	}

    public void Move(float horizontalAxis, float verticalAxis)
    {
        // TODO(jaween): Keep the player's ship within the bounds

        var movement =
        Vector3.right * horizontalAxis * horizontalSpeed +
        Vector3.up * verticalAxis * verticalSpeed;

        rigidbody.MovePosition(transform.position + 
            movement * Time.fixedDeltaTime);
    }
}
