using UnityEngine;
using System.Collections;

public class RandomGenerator : MonoBehaviour {

	public float minDelta;
	public float maxDelta;
	public GameObject target;
	public int seed;

	float time;

	void Start()
	{
		time = Time.time + Random.Range (minDelta, maxDelta);
//		if(seed==0)
//			seed=(int)Time.time;
//		Random.seed = seed;
	}

	
	void FixedUpdate()
	{


		if (Time.time < time)
						return;

		time = Time.time + Random.Range (minDelta, maxDelta);

		Vector3 bottomLeftWorldCoordinates = Camera.main.ViewportToWorldPoint(Vector3.zero);
		Vector3 topRightWorldCoordinates = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));

		Vector3 pos=new Vector3(
       	 	topRightWorldCoordinates.x+1,
			Random.Range (bottomLeftWorldCoordinates.y, topRightWorldCoordinates.y)
		);
	
		//target.rigidbody2D.velocity =  * (new Vector2 (-1.0f, 0.0f))*velocity;
		Instantiate(target,pos,new Quaternion());

	}
}
