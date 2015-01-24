using UnityEngine;
using System.Collections;

public class Animations {


	public static IEnumerator shrinkAndDestroy(GameObject o, Vector3 coordinates)
	{
		o.collider2D.enabled = false;

		Vector3 deltaMove = coordinates - o.transform.position;
		Vector3 absMove = new Vector3 (Mathf.Abs (deltaMove.x), Mathf.Abs (deltaMove.y));
		Vector3 moveReminder = absMove;
		Vector3 direction = new Vector3 ((deltaMove.x < 0 ? -1.0f : 1.0f), (deltaMove.y < 0 ? -1.0f : 1.0f));

		float moveRate = Mathf.Max (absMove.x,absMove.y)/0.2f;

		while(o!=null && moveReminder.x>0.0f && moveReminder.y>0.0f )
		{

			Vector3 move = absMove*moveRate*Time.deltaTime;
			Vector3 clamp_move = new Vector3(
				Mathf.Clamp(move.x,0.0f,moveReminder.x),
				Mathf.Clamp(move.y,0.0f,moveReminder.y)
			);

			o.transform.position+=new Vector3(clamp_move.x*direction.x,clamp_move.y*direction.y);
			moveReminder-=clamp_move;
			yield return new WaitForSeconds(0.03f);
		}

		float shrinkRate=0.0f;
		if (o != null)
			shrinkRate = Mathf.Min (o.transform.localScale.x,o.transform.localScale.y)/0.2f;

		while(o!=null && o.transform.localScale.x>0 && o.transform.localScale.y>0 )
		{
			o.transform.localScale -=((new Vector3(1.0f,1.0f,0.0f))*shrinkRate*Time.deltaTime);
			yield return new WaitForSeconds(0.03f);
		}

		MonoBehaviour.Destroy (o);

	}
}
