﻿using UnityEngine;
using UnityEngine.UI;
using System;

using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
		Application.Quit ();
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
	public Text ScoreText;

	void OnGUI()
	{
		int score = PlayerPrefs.GetInt("highscore", 0);

		Debug.Log (score);

		TimeSpan span = TimeSpan.FromSeconds (score);

		if (ScoreText != null) {
			ScoreText.text = string.Format("Best score so far: {0:00}:{1:00}:{2:00}", span.Hours,span.Minutes, span.Seconds);
		}
	}
		
}
