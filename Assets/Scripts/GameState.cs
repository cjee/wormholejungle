using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	//TODO:
	//Dzivibas speletaja
	//Limenu parvaldiba

	public int PlayerHealth;
	public GameObject Player;
	public Texture HealthPicture;


	// Use this for initialization
	void Start () {
		//Seting up state
		this.PlayerHealth = PlayerHealth;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI()
	{
		for(int i =0; i< this.PlayerHealth; i++)
		GUI.DrawTexture (new Rect (10 + i*29, 10, 20, 27), HealthPicture);
	}

	public void PlayerHit()
	{

		this.PlayerHealth = this.PlayerHealth - 1;
		if(this.PlayerHealth <= 0)
		{
			Destroy(Player);
		 	StartCoroutine(RestartGame());

		}
	}

	private IEnumerator RestartGame()
	{
		float length = gameObject.GetComponent<Fading> ().Begin (1);
		Debug.Log (length);
		yield return new WaitForSeconds (length);
		Application.LoadLevel ("Main 1");
	}



	private static GameState m_Instance;
	public static GameState Instance { get { return m_Instance; } }
	
	void Awake()
	{
		m_Instance = this;
	}
	
	void OnDestroy()
	{
		m_Instance = null;
	}
}
