using UnityEngine;
using System.Collections;

public class AsteroidPart3 : GlobalAsteriod {

	void Start () {
		rigidbody2D.velocity = speed * (new Vector2 (-0.99f, -0.02f));
	}
}
