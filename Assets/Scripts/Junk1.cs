using UnityEngine;
using System.Collections;

public class Junk1 : AbstractEnemy {

	public float RotationSpeed;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = velocity * (new Vector2 (-1.0f, 0.0f));
		rigidbody2D.angularVelocity = RotationSpeed;

	}

}
