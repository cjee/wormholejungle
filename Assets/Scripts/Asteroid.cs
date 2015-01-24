using UnityEngine;
using System.Collections;

public class Asteroid : GlobalAsteriod {


	void Start()
	{
		rigidbody2D.velocity = speed * (new Vector2 (-1.0f, 0.0f));
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		base.OnCollisionEnter2D (other);

		if (health <= 0) 
		{

		}
	}
}
