using UnityEngine;
using System.Collections;

public class AsteroidPart2 : AbstractEnemy {


	void Start () {
		rigidbody2D.velocity = velocityMax * (new Vector2 (0.7f, 0.7f));
	}
}
