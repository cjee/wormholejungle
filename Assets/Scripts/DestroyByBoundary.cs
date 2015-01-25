using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyByBoundary : MonoBehaviour {

	public bool Destryall = false;

	void Start()
	{
		Resize ();
	}

	void Resize()
	{
		
		float worldScreenHeight = Camera.main.orthographicSize * 2;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		BoxCollider2D col = (BoxCollider2D)collider2D;
		col.size= new Vector2(
			worldScreenWidth+4,
			worldScreenHeight+4);

	}

	void OnTriggerExit2D(Collider2D col)
	{
		Destroy(col.gameObject);

	}


}
