using UnityEngine;
using System.Collections;

public class Asteroid : GlobalAsteriod {

	public GameObject part1;
	public GameObject part2;
	public GameObject part3;

	void Start()
	{
		rigidbody2D.velocity = speed * (new Vector2 (-1.0f, 0.0f));
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		base.OnCollisionEnter2D (other);
		
		if (health == 0) 
		{
			Instantiate(part1,rigidbody2D.position.ToVector3(),new Quaternion());
			Instantiate(part2,rigidbody2D.position.ToVector3(),new Quaternion());
			Instantiate(part3,rigidbody2D.position.ToVector3(),new Quaternion());
		}

	}
}
