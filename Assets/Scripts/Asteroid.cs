using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	public int health;

	void OnCollision2D(Collider2D col)
	{
		health--;
		if (health <= 0) 
		{
			Destroy(gameObject);
		}
	}

}
