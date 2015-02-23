using UnityEngine;
using System.Collections;

public class Animations {


	public static IEnumerator shrinkAndDestroy(GameObject o, GameObject portal)
	{
		o.collider2D.enabled = false;

		Vector3 deltaMove = portal.transform.position - o.transform.position;
		Vector3 absMove = new Vector3 (Mathf.Abs (deltaMove.x), Mathf.Abs (deltaMove.y));
		Vector3 moveReminder = absMove;
		Vector3 direction = new Vector3 ((deltaMove.x < 0 ? -1.0f : 1.0f), (deltaMove.y < 0 ? -1.0f : 1.0f));

		float moveRate = Mathf.Max (absMove.x,absMove.y,10)/0.2f;

		while(o!=null && Vector2.Distance(o.transform.position,portal.transform.position)>0.2f )
		{
			o.rigidbody2D.velocity = portal.rigidbody2D.velocity;
			o.transform.position=Vector2.MoveTowards(o.transform.position,portal.transform.position,moveRate*Time.deltaTime);
			o.transform.localPosition -= Vector3.forward;
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
