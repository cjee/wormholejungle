using UnityEngine;
using System.Collections;

public class Asteroid : AbstractEnemy {

	public GameObject part1;
	public GameObject part2;
	public GameObject part3;


	protected void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Portal")
						return;
		base.OnCollisionEnter2D (other);

		if (other.gameObject.tag.Equals("LargeAsteriod") && health>0) 
		{
			health=0;
		}
		
		if (health == 0) 
		{
			health=-1;
			Destroy(gameObject);
			Instantiate(part1,rigidbody2D.position.ToVector3()+(new Vector3(-1,1)),new Quaternion());
			Instantiate(part2,rigidbody2D.position.ToVector3()+(new Vector3(1,1)),new Quaternion());
			Instantiate(part3,rigidbody2D.position.ToVector3()+(new Vector3(0,-1)),new Quaternion());
		}

	}
}
