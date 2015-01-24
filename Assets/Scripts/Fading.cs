using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

	public Texture FadeOutTexture;
	public float Speed = 0.8f;

	private int drawDepth = -1000;
	private float alfa = 1.0f;
	private int fadeDir = - 1;

	void OnGUI()
	{
		alfa += fadeDir * Speed * Time.deltaTime;
		alfa = Mathf.Clamp01 (alfa);
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alfa);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), FadeOutTexture);
	}

	public float Begin(int direction)
	{
		fadeDir = direction;
		return(Speed);
	}

	void OnLevelWasLoaded()
	{
		Begin (-1);
	}
}
