using UnityEngine;
using System.Collections;

public class Animations {


	public static void shrinkAndDestroy(GameObject o)
	{
		/*
		Debug.Log(1);
		float shrinkRate = 1.9f;
		float shrinkTo = (new Vector3 (0.1f, 0.1f, 0.1f)).sqrMagnitude;
		//o.rigidbody2D.velocity = Vector2.zero;
		
		Debug.Log(o);
		while(o!=null && o.transform.localScale.sqrMagnitude>shrinkTo )
		{
			o.transform.localScale *= shrinkRate*Time.deltaTime;
			//Debug.Log(o.transform.localScale);
			yield return new WaitForSeconds(10);
		}*/

		MonoBehaviour.Destroy (o);

	}
}
