using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {
	
	void Start()
	{
		Resize ();
	}

	void Resize()
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		
		float worldScreenHeight = Camera.main.orthographicSize * 2;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		BoxCollider2D col = (BoxCollider2D)collider2D;
		col.size= new Vector2(
			worldScreenWidth,
			worldScreenHeight);

	}

	void OnTriggerExit2D(Collider2D col)
	{
		Destroy(col.gameObject);

	}
}
