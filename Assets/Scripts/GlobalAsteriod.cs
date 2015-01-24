using UnityEngine;
using System.Collections;

public class GlobalAsteriod : MonoBehaviour {

	
	public int health;
	public float speed;

	public void OnCollisionEnter2D(Collision2D other)
	{
		health--;
		if (health <= 0) 
		{
			Destroy(gameObject);
		}
	}
}
