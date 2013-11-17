﻿using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {
	//setting up the grid
	public GameObject displayCube;
	public GameObject cube;
	public GameObject[,] cubeField;
	public int cubeFieldX = 5;
	public int cubeFieldY = 8;
	
	//pertaining to the timer
	float theTime;
	public int timeRemaining;
	public float countdown;
	float countdownInterval = 1f;
	float turnInterval = 2f;
	float nextTurn;
	
	//pertaining to turns
	bool nextCubeDropped = true;
	
	//pertaining to color cubes
	public ColorCube colorCube;
	
	//pertaining to the GUI
	Rect timerBox = new Rect (0,0,100,25);
	Rect timer = new Rect (0,50,100,25);
	Rect interval =  new Rect (0,100,100,25);
	Rect turnBox = new Rect (Screen.width-150, 0, 150, 25);
	Rect nextTurnBox = new Rect (Screen.width-100, 50, 100, 25);
	Rect colorCubeBox = new Rect(0,Screen.height-25,100,25);
	Rect colorCubeBox2 = new Rect(0,Screen.height-75,300,25);
	// Use this for initialization
	void Start () {
		theTime = 0;
		nextTurn = theTime + turnInterval;
		countdown = countdownInterval + theTime;
		
		cubeField = new GameObject [cubeFieldX, cubeFieldY];
		for (int x = 0; x < cubeFieldX; x++) {
			for (int y = 0; y < cubeFieldY; y++) {
		
				cubeField[x,y] = (GameObject) Instantiate(cube, new Vector3 (x * 2, y * 2, 0), Quaternion.identity);
				cubeField[x,y].GetComponent<fieldCubeBehave>().cubeX = x;
				cubeField[x,y].GetComponent<fieldCubeBehave>().cubeY = y;
				cubeField[x,y].GetComponent<fieldCubeBehave>().cubeField = cubeField;
			}
		}

			
		Instantiate(displayCube, new Vector3(9,17,0), Quaternion.identity);
		displayCube.GetComponent<nextCube>().nextColorInt = 2;
		
		colorCube = new ColorCube();
		colorCube.colorX = 0;
		colorCube.colorY = 0;
		
	}
	void GameTimer () {
		theTime += Time.deltaTime ;
		if (timeRemaining == 0) {
			Application.LoadLevel("startMenu");
		}
		
		else if (timeRemaining != 0 && theTime >= countdown) {
			timeRemaining--;
			countdown += countdownInterval;
			
		}
		
	}
	void Turn () {
		if(theTime >= nextTurn){
			nextTurn += turnInterval;
			nextCubeDropped = false;
			displayCube.GetComponent<nextCube>().nextColorInt = Random.Range(1,5);
			print ("random is: " + displayCube.GetComponent<nextCube>().nextColorInt);
			displayCube.renderer.material.color = displayCube.GetComponent<nextCube>().NextCubeColor();
		}
		
	}
	void KeyBoardControl () {
		if (Input.GetKeyDown(KeyCode.Keypad1) && nextCubeDropped == false){
			nextCubeDropped = true;
			colorCube.colorX = 0;
			colorCube.colorY = Random.Range(1,8);
			colorCube.cubeColor = displayCube.GetComponent<nextCube>().NextCubeColor();
			
		}
		if (Input.GetKeyDown(KeyCode.Keypad2) && nextCubeDropped == false){
			nextCubeDropped = true;
			colorCube.colorX = 1;
			colorCube.colorY = Random.Range(1,8);
			colorCube.cubeColor = displayCube.GetComponent<nextCube>().NextCubeColor();
			
		}
		if (Input.GetKeyDown(KeyCode.Keypad3) && nextCubeDropped == false){
			nextCubeDropped = true;
			colorCube.colorX = 2;
			colorCube.colorY = Random.Range(1,8);
			colorCube.cubeColor = displayCube.GetComponent<nextCube>().NextCubeColor();
			
		}
		if (Input.GetKeyDown(KeyCode.Keypad4) && nextCubeDropped == false){
			nextCubeDropped = true;
			colorCube.colorX = 3;
			colorCube.colorY = Random.Range(1,8);
			colorCube.cubeColor = displayCube.GetComponent<nextCube>().NextCubeColor();
			
		}
		if (Input.GetKeyDown(KeyCode.Keypad5) && nextCubeDropped == false){
			nextCubeDropped = true;
			colorCube.colorX = 4;
			colorCube.colorY = Random.Range(1,8);
			colorCube.cubeColor = displayCube.GetComponent<nextCube>().NextCubeColor();
			
		}
		
	}
		void CubeAppearence () {
		
			if (cubeField[colorCube.colorX, colorCube.colorY] && cubeField[colorCube.colorX, colorCube.colorY].GetComponent<fieldCubeBehave>().color == false) {
			cubeField[colorCube.colorX, colorCube.colorY].GetComponent<fieldCubeBehave>().color = true;
			cubeField[colorCube.colorX, colorCube.colorY].GetComponent<fieldCubeBehave>().cubeColor = colorCube.cubeColor;
			
			}
			foreach (GameObject cube in cubeField) {
				cube.renderer.material.color = cube.GetComponent<fieldCubeBehave>().cubeColor;
			}
		}
	
	// Update is called once per frame
	void Update () {
		GameTimer();
		Turn ();
		KeyBoardControl();
		CubeAppearence();
	}
		void OnGUI () {
		GUI.Box(timerBox, ("Remaining: ") + timeRemaining.ToString());
		GUI.Box(timer,("time: ") + theTime.ToString());
		GUI.Box(interval, ("interval: ") + countdown.ToString());
		GUI.Box(turnBox, ("turnInterval: ") + turnInterval.ToString());
		GUI.Box(nextTurnBox, ("turn: ") + nextTurn.ToString());
		GUI.Box (colorCubeBox, ("POS: ") + colorCube.colorX.ToString() + (", ") + colorCube.colorY.ToString());
		GUI.Box (colorCubeBox2, ("color: ") + colorCube.cubeColor.ToString());
	}
}