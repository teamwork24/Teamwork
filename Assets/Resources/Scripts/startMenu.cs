using UnityEngine;
using System.Collections;

public class startMenu : MonoBehaviour {
	
	Rect title = new Rect (Screen.width/2,(Screen.height/2)-150,200,50);
	public int titleFontSize;
	Rect start = new Rect (Screen.width/2,(Screen.height/2)-100,200,40);
	Rect extras = new Rect (Screen.width/2,(Screen.height/2)-50,200,40);
	Rect highScore = new Rect (Screen.width/2,(Screen.height/2),200,40);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () {
		GUIStyle menuTitle = new GUIStyle();
		menuTitle.fontSize = titleFontSize;
		//GUI.Box (cargo, redPlane.cargoLoad.ToString () + ("tons of cargo"));
		GUI.Box (title, ("Color+"), menuTitle);
		if (GUI.Button(start,("Start"))){
			Application.LoadLevel("classicGame");
		}
		GUI.Button(extras,("Extras"));
		GUI.Button(highScore,("High Score"));
	}
}
