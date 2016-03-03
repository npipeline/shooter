using UnityEngine;
using System.Collections;
using System;

public class MovementController : MonoBehaviour
{
	#region Events
	public delegate void MovedEventHandler(object sender, EventArgs e);

	public event MovedEventHandler Moved;
	#endregion

	public float horizontalSpeed;
	public float verticalSpeed;
	public bool keepWithinBounds;
	public float screenWidth;
	public float screenHeight;
	private MoveType NextMoveType;
	private new Rigidbody2D rigidbody;
	private float horizontalSum = 0;
	private float verticalSum = 0;
	private Vector2 newPosition;

	private void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
		NextMoveType = MoveType.None;
	}

	private void FixedUpdate ()
	{
		MoveInternal ();
	}

	private void MoveInternal ()
	{
		if (NextMoveType != MoveType.None) 
		{
			switch (NextMoveType) 
			{
				case MoveType.Move:			
					var movement =
	           		    Vector2.right * horizontalSum * horizontalSpeed +
						Vector2.up * verticalSum * verticalSpeed;

					horizontalSum = 0;
					verticalSum = 0;
	        
					newPosition = rigidbody.position + 
						movement * Time.fixedDeltaTime;

				
				
					if (keepWithinBounds) {
						float xBound = screenWidth / 2.0f;
						float yBound = screenHeight / 2.0f;
						newPosition.x = Mathf.Clamp (newPosition.x, -xBound, xBound);
						newPosition.y = Mathf.Clamp (newPosition.y, -yBound, yBound);
					}
					
					rigidbody.MovePosition (newPosition);
					break;

				case MoveType.MoveTo:
					if (keepWithinBounds) {
						float xBound = screenWidth / 2.0f;
						float yBound = screenHeight / 2.0f;
						newPosition.x = Mathf.Clamp (newPosition.x, -xBound, xBound);
						newPosition.y = Mathf.Clamp (newPosition.y, -yBound, yBound);
					}
					rigidbody.position = newPosition;
//					Vector2.MoveTowards(rigidbody.position, newPosition, 0.0f);
					break;

				default: 
					break;
			}
			ThrowMovedEvent();
			NextMoveType = MoveType.None;
		}
		
	}

	private void ThrowMovedEvent()
	{
		if(Moved != null)
			Moved(this, new EventArgs());
	}

	public void Move (float horizontalAxis, float verticalAxis)
	{
		// Holds onto all the inputs until FixedUpdate()
		horizontalSum += horizontalAxis;
		verticalSum += verticalAxis;
		NextMoveType = MoveType.Move;

	}

	public void MoveTo (Vector2 Position)
	{
		newPosition = Position;
		NextMoveType = MoveType.MoveTo;
	}
}

public enum MoveType
{
	None,
	Move,
	MoveTo
}
