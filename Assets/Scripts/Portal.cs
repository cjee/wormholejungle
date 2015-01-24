using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	float velocity;

	void Start () {
		rigidbody2D.velocity = (new Vector2 (-1.0f, 0.0f)) * velocity;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		collider.gameObject.transform.position = gameObject.transform.position;
		Animations.shrinkAndDestroy (collider.gameObject);
		//StartCoroutine(Animations.shrinkAndDestroy(collider.gameObject));
	}

}
