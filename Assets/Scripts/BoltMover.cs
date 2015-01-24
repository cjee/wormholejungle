using UnityEngine;
using System.Collections;

public class BoltMover : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = speed * (new Vector2 (1.0f, 0.0f));
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Destroy (gameObject);
	}
}
