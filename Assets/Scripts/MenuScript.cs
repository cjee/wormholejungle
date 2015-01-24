using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void StartGame()
	{
		StartCoroutine (GoToPlay ());
	}

	IEnumerator GoToPlay()
	{
		var length = GameObject.Find ("Canvas").GetComponent<Fading> ().Begin (1);
		yield return new WaitForSeconds(length);
		Application.LoadLevel ("Main");
		
	}

}
