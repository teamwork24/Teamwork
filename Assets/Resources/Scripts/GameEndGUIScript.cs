using UnityEngine;
using System.Collections;

public class GameEndGUIScript : MonoBehaviour {
	
	
	
	// Use this for initialization
	void Start () {
	
		

	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		int Score = 6;
		int HighScore = 5;
		// scores need to be from previous scene, use DontDestroyOnLoad
		if (HighScore > Score){
		
		GUI.Box (new Rect (100,100,300,50), "HighScore");
		GUI.Box (new Rect (100,150,300,50), "Score");
		}
		
		else {
		
		GUI.Box (new Rect (100,100,300,50), "Score");
		GUI.Box (new Rect (100,150,300,50), "HighScore");	
			
		}
		//boolean value from DontDestroyOnLoad passes on to bool "Win";
		//check for bool "Win" from previous scene
		// bool declaration here simply for functionality
		bool Win = true; 
		
		
		if (GUI.Button (new Rect (100,200,300,50), "Try Again")) {
			Application.LoadLevel("classicGame");
		}
		if (GUI.Button (new Rect (100,250,300,50), "Menu")) {
			Application.LoadLevel("startMenu");
		}
		
		
		
		if (Win == true){
			
		GUI.Box (new Rect (100,50,300,50), "Win");

		

		}
		else { 
				
		GUI.Box (new Rect (75,50,300,50), "Lose");
		
		}
		
		
		
	
	
 	}
}
