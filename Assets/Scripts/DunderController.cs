using UnityEngine;
using System.Collections;

public class DunderController : ShipController
{
	public float moveDelay;
	private Rigidbody2D PlayerBody;
	private new Rigidbody2D rigidbody;
	bool CanMove = true;

	protected override void Initialize ()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
		PlayerShipController Player = FindObjectOfType<PlayerShipController> ();
		PlayerBody = Player.gameObject.GetComponent<Rigidbody2D> ();
		movementController.Moved += ctlr_Moved;
	}

	void ctlr_Moved (object sender, System.EventArgs e)
	{
		Fire();
		StartCoroutine(SetCanMove());
	}

	private void FixedUpdate ()
	{
		Movement ();
	}

	private void Movement ()
	{
		if (CanMove) 
		{
			Vector2 newPosition = new Vector2 (PlayerBody.transform.position.x, rigidbody.transform.position.y);		
			movementController.MoveTo (newPosition);
			CanMove = false;
		}
	}

	private IEnumerator SetCanMove()
	{
		yield return new WaitForSeconds(moveDelay);
		CanMove = true;
	}

}
