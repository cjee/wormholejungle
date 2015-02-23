using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public float velocity;

	void Start () {
		rigidbody2D.velocity = (new Vector2 (-1.0f, 0.0f)) * velocity;

	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		/*
		if (collider.gameObject.rigidbody2D == null)
						return;*/
		StartCoroutine(Animations.shrinkAndDestroy(collider.gameObject,gameObject));
		
	}

}
