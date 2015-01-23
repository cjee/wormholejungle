using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {
	 
	public float speed;

	public float fireRate;
	public GameObject shot;
	public Transform shotSpawn;
	private float nextFire;

	void FixedUpdate()
	{
		Move ();
		Shoot ();
	}

	void Move()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector2 movement = new Vector2(moveHorizontal,moveVertical);
		
		rigidbody2D.velocity = movement * speed;
		
		Vector3 bottomLeftWorldCoordinates = Camera.main.ViewportToWorldPoint(Vector3.zero);
		Vector3 topRightWorldCoordinates = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
		
		Vector3 movementRangeMin = bottomLeftWorldCoordinates + renderer.bounds.extents;
		Vector3 movementRangeMax = topRightWorldCoordinates - renderer.bounds.extents;
		
		Vector3 newPosition = transform.position;
		newPosition.x = Mathf.Clamp(rigidbody2D.position.x, movementRangeMin.x, movementRangeMax.x);
		newPosition.y = Mathf.Clamp(rigidbody2D.position.y, movementRangeMin.y, movementRangeMax.y);
		transform.Translate(newPosition - transform.position);
	}

	void Shoot()
	{
		if (Time.time > nextFire) 
		{
			nextFire=Time.time+fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
