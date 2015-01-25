using UnityEngine;
using System.Collections;

public class Junk2 : AbstractEnemy {

	public float RotationSpeed;

	// Use this for initialization
	protected void Start () {
		base.Start ();
		rigidbody2D.angularVelocity  = Random.Range (50, 150);

	}
	
	protected void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag.Equals(gameObject.tag)==false)
			base.OnCollisionEnter2D (other);
	}

}
