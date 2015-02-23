using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameState : MonoBehaviour {
	//TODO:
	//Dzivibas speletaja
	//Limenu parvaldiba

	public GameState()
	{
		guid = Guid.NewGuid();
		Debug.Log (guid);
	}
	public Guid guid;
	public int PlayerHealth;
	public GameObject Player;
	public Texture HealthPicture;

	public List<GameObject> items;

	private GameObject playerObject;

	List<Texture> backgrounds = new List<Texture>();
	List<GameObject> generators = new List<GameObject>();

	// Use this for initialization
	void Start () {
		items = new List<GameObject> ();
		items.Add(GameObject.Find("PlayerRocket"));
		//Seting up state
		//this.PlayerHealth = PlayerHealth;
		backgrounds.Add (Resources.Load<Texture> ("bacground_1"));
		backgrounds.Add (Resources.Load<Texture> ("bacground_2"));


		generators.Add (GameObject.Find ("RandomGenerator"));
		generators.Add (GameObject.Find ("RandomShipGenerator"));
		generators.Add (GameObject.Find ("Junk1Generator"));
		generators.Add (GameObject.Find ("Junk2Generator"));

		PrepareLevel (false);
	}
	
	// Update is called once per frame
	void Update () {
		#if (UNITY_WP8 && !UNITY_EDITOR) // only run this if the target platform is WP8 and the game is not running in the Unity editor
		if (Input.GetKey(KeyCode.Escape))
		{
			OnBackButtonPressed();
		}
		#endif
	}

	void OnBackButtonPressed()
	{
		Application.LoadLevel ("Main 1");
	}

	void OnGUI()
	{
		for(int i =0; i< this.PlayerHealth; i++)
		GUI.DrawTexture (new Rect (10 + i*29, 10, 20, 27), HealthPicture);
		TimeSpan span = TimeSpan.FromSeconds (Time.timeSinceLevelLoad);
		GUIStyle style = new GUIStyle ();
		style.fontSize = 21;
		style.normal.textColor = Color.white;

		GUI.Label (new Rect (Screen.width/2 - 50, 10, 100, 30), string.Format("{0:00}:{1:00}:{2:00}", span.Hours,span.Minutes, span.Seconds),style);
	}

	public void PlayerHit()
	{

		this.PlayerHealth = this.PlayerHealth - 1;
		if(this.PlayerHealth <= 0)
		{
			Destroy(playerObject);
		 	StartCoroutine(RestartGame());

		}
	}

	public void PortalHit()
	{
		StartCoroutine(LightsOff());
		}

	private IEnumerator RestartGame()
	{
		float length = gameObject.GetComponent<Fading> ().Begin (1);
		yield return new WaitForSeconds (length);
		Application.LoadLevel ("Main 1");
	}

	private void PrepareLevel(bool navigate = true)
	{	
//		if (navigate) {
//			Debug.Log (navigate);
//		 	StartCoroutine(LightsOff());
//
//
//				}

		//var rnd = new System.Random ();
		//background
		GameObject bkg = GameObject.Find ("Quad");
		int backgid = Convert.ToInt32(UnityEngine.Random.Range (0.0f, backgrounds.Count-1.0f));

		bkg.renderer.material.mainTexture = backgrounds [backgid];

		//generators
		DisableGenerators ();
		int gencount = Convert.ToInt32(UnityEngine.Random.Range (1.0f, 3.0f));

		
		for (int i = 0; i< gencount; i++) {
			EnableGenerator(generators[Convert.ToInt32(UnityEngine.Random.Range (0.0f, 3.0f))]);
		}



		return;
		
	}

	IEnumerator LightsOff()
	{

		float length = gameObject.GetComponent<Fading> ().Begin (1);
		yield return new WaitForSeconds (length);
		Clean ();
		 length = gameObject.GetComponent<Fading> ().Begin (-1);
		yield return new WaitForSeconds (length);
	}
	public void Clean()
	{
		foreach (var item in items)
						Destroy (item);
		items = new List<GameObject> ();
		playerObject = UnityEngine.Object.Instantiate(Player) as GameObject;
		items.Add(playerObject);
		PrepareLevel (true);
		
	}

	IEnumerator LightsOn()
	{
		float length = gameObject.GetComponent<Fading> ().Begin (-1);
		yield return new WaitForSeconds (length);
	}

	void EnableGenerator(GameObject r)
	{
		r.SetActive (true);
		var gen = r.GetComponent<RandomGenerator> ();
		if (gen == null)
						Debug.LogError ("Ǵeneratoram nav randomizétája");
		gen.minDelta = UnityEngine.Random.Range (0.4f, 0.9f);
		gen.maxDelta = UnityEngine.Random.Range (1.0f, 1.5f);
	}

	private void DisableGenerators()
	{
		foreach (var item in generators) {
			item.SetActive(false);
		}
	}

	private GameState m_Instance;
	public GameState Instance { get { return m_Instance; } }
	
	void Awake()
	{
		m_Instance = this;
	}
	
	void OnDestroy()
	{
		m_Instance = null;
	}
}
