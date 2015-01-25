using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {
	 
	public float speed;

	public float fireRate;
	public GameObject shot;
	public Transform shotSpawn;
	private float nextFire;

	float lasthit = 0.0f;
	protected void OnCollisionEnter2D(Collision2D other)
	{
		var obj = GameObject.Find ("GameStateManager").GetComponent<GameState> ().Instance;
				if (other.gameObject.tag.Equals ("Portal")) {

						obj.PortalHit();
				} else {

						if (Time.fixedTime - lasthit > 0.5f) {
								obj.PlayerHit ();
								lasthit = Time.fixedTime;
						}
				
				}
		}


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

		//movement += GetTouchOffset ();
		
		rigidbody2D.velocity = movement * speed;


		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			//Get movement of the finger since the last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			// Move object across the X and Y plane
			transform.Translate (touchDeltaPosition.x * 0.05f, touchDeltaPosition.y * 0.05f, 0);
		}

		
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


	
	int fingerID=-1;
	Vector2 position;
	
	public Vector2 GetTouchOffset()
	{
		if (fingerID == -1 && Input.touchCount > 1)
			return new Vector2(0.0f,0.0f);
		else if (Input.touchCount == 0) 
		{
			fingerID=-1;
		}
		else if (fingerID==-1)
		{
			fingerID = Input.GetTouch (0).fingerId;
			position=Input.GetTouch(0).position;
		}
		else
		{
			Vector2 new_position=Vector2.zero;
			bool valid=false;
			foreach(Touch t in Input.touches)
			{
				if(t.fingerId==fingerID)
				{
					valid=true;
					new_position=t.position;
					break;
				}
			}
			
			if(valid==false)
			{
				fingerID=-1;
				return new Vector2(0.0f,0.0f);
			}
			
			new_position-=position;
			new_position=new_position/Camera.main.pixelHeight/0.2f;
			return new Vector2(
				Mathf.Clamp(new_position.x,-1.0f,1.0f),
				Mathf.Clamp(new_position.y,-1.0f,1.0f)
				);
		}
		return new Vector2(0.0f,0.0f);
	}
}
