using UnityEngine;
using System.Collections;

public class EnemyControl : AbstractEnemy {

	
	public float fireRate;
	public GameObject shot;
	public Transform shotSpawn;
	private float nextFire;

	void FixedUpdate()
	{
		Shoot ();
	}

	void Shoot()
	{
		if (Time.time > nextFire) 
		{
			nextFire=Time.time+fireRate;
			var shot_object=Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			var obj = GameObject.Find("GameStateManager");
			if (obj != null) {
				var stuff = obj.GetComponent<GameState> ();
				stuff.Instance.items.Add (shot_object as GameObject);
			}
		}
	}
}
