using UnityEngine;
using System.Collections;

public abstract class AbstractEnemy : MonoBehaviour {
	
	public float velocityMin;
	public float velocityMax;
	public int health;
	public GameObject explosion;

	protected void Start()
	{
		rigidbody2D.velocity = Random.Range(velocityMin,velocityMax) * (new Vector2 (-1.0f, 0.0f));
	}

	
	protected void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Portal")
			return;
		
		health--;
		if (health <= 0) 
		{
			if(explosion!=null)
			{
				Instantiate(explosion,transform.position,new Quaternion());
			}
			Destroy(gameObject);
		}
	}
}
