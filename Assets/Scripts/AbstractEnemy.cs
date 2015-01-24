using UnityEngine;
using System.Collections;

public abstract class AbstractEnemy : MonoBehaviour {
	
	public float velocity;
	public int health;

	void Start()
	{
		rigidbody2D.velocity = velocity * (new Vector2 (-1.0f, 0.0f));
	}

	
	public void OnCollisionEnter2D(Collision2D other)
	{
		health--;
		if (health == 0) 
		{
			Destroy(gameObject);
		}
	}
}
