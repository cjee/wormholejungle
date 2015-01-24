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
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
