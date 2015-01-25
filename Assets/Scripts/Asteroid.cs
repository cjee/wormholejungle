using UnityEngine;
using System.Collections;

public class Asteroid : AbstractEnemy {

	public GameObject part1;
	public GameObject part2;
	public GameObject part3;

	void Start()
	{
		base.Start ();
		rigidbody2D.angularVelocity = Random.Range (-150, 150);
	}


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
			var item1 = Instantiate(part1,rigidbody2D.position.ToVector3()+(new Vector3(-1,1)),new Quaternion());
			var item2 = Instantiate(part2,rigidbody2D.position.ToVector3()+(new Vector3(1,1)),new Quaternion());
			var item3 = Instantiate(part3,rigidbody2D.position.ToVector3()+(new Vector3(0,-1)),new Quaternion());


			var obj = GameObject.Find("GameStateManager");
			if (obj != null) {
				var stuff = obj.GetComponent<GameState> ();
				
				
				//target.rigidbody2D.velocity =  * (new Vector2 (-1.0f, 0.0f))*velocity;
				stuff.Instance.items.Add (item1 as GameObject);
				stuff.Instance.items.Add (item2 as GameObject);
				stuff.Instance.items.Add (item3 as GameObject);
			}
		}

	}
}
