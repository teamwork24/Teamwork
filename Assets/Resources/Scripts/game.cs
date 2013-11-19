using UnityEngine;
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
	public ActiveCube activeCube; 
	
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
		
		activeCube = new ActiveCube();
		activeCube.activeX = 6;
		activeCube.activeY = 9;
		
		cubeField = new GameObject [cubeFieldX, cubeFieldY];
		for (int x = 0; x < cubeFieldX; x++) {
			for (int y = 0; y < cubeFieldY; y++) {
		// Instantiates the cubefield, no problems here
				
				cubeField[x,y] = (GameObject) Instantiate(cube, new Vector3 (x * 2, y * 2, 0), Quaternion.identity);
				cubeField[x,y].GetComponent<fieldCubeBehave>().cubeX = x;
				cubeField[x,y].GetComponent<fieldCubeBehave>().cubeY = y;
				cubeField[x,y].GetComponent<fieldCubeBehave>().cubeField = cubeField;
				cubeField[x,y].GetComponent<fieldCubeBehave>().activeCube = activeCube;
			}
		}

			
		Instantiate(displayCube, new Vector3(9,17,0), Quaternion.identity);
		displayCube.GetComponent<nextCube>().nextColorInt = 2;
		
		// the ColorCube class and ActiveCube class start off the grid to prevent coloring.
		// Note: harmless error with array out of range;
		colorCube = new ColorCube();
		colorCube.colorX = 6;
		colorCube.colorY = 10;
		
	}
	//for counting down
	void GameTimer () {
		theTime += Time.deltaTime ;
		if (timeRemaining == 0) {
			Application.LoadLevel("endGame");
		}
		
		else if (timeRemaining != 0 && theTime >= countdown) {
			timeRemaining--;
			countdown += countdownInterval;
			
		}
		
	}
	void Turn () {
		// turn timer, resetting variables and colors
		
		if(theTime >= nextTurn){
			nextTurn += turnInterval;
			nextCubeDropped = false;
			displayCube.GetComponent<nextCube>().nextColorInt = Random.Range(1,7);
			print ("random is: " + displayCube.GetComponent<nextCube>().nextColorInt);
			displayCube.renderer.material.color = displayCube.GetComponent<nextCube>().NextCubeColor();
		}
		
	}
	void KeyBoardControl () {
		// assigns colors from NextCube to cubeField using keyboard controls Alpha 1-5
		
		if (Input.GetKeyDown(KeyCode.Alpha1) && nextCubeDropped == false){
			nextCubeDropped = true;
			colorCube.colorX = 0;
			colorCube.colorY = Random.Range(1,8);
			cubeField[colorCube.colorX, colorCube.colorY].GetComponent<fieldCubeBehave>().color = true;
			cubeField[colorCube.colorX, colorCube.colorY].GetComponent<fieldCubeBehave>().cubeColor = displayCube.GetComponent<nextCube>().NextCubeColor();
			
		}
		if (Input.GetKeyDown(KeyCode.Alpha2) && nextCubeDropped == false){
			nextCubeDropped = true;
			colorCube.colorX = 1;
			colorCube.colorY = Random.Range(1,8);
			cubeField[colorCube.colorX, colorCube.colorY].GetComponent<fieldCubeBehave>().color = true;
			cubeField[colorCube.colorX, colorCube.colorY].GetComponent<fieldCubeBehave>().cubeColor = displayCube.GetComponent<nextCube>().NextCubeColor();
			
		}
		if (Input.GetKeyDown(KeyCode.Alpha3) && nextCubeDropped == false){
			nextCubeDropped = true;
			colorCube.colorX = 2;
			colorCube.colorY = Random.Range(1,8);
			cubeField[colorCube.colorX, colorCube.colorY].GetComponent<fieldCubeBehave>().color = true;
			cubeField[colorCube.colorX, colorCube.colorY].GetComponent<fieldCubeBehave>().cubeColor = displayCube.GetComponent<nextCube>().NextCubeColor();
			
		}
		if (Input.GetKeyDown(KeyCode.Alpha4) && nextCubeDropped == false){
			nextCubeDropped = true;
			colorCube.colorX = 3;
			colorCube.colorY = Random.Range(1,8);
			cubeField[colorCube.colorX, colorCube.colorY].GetComponent<fieldCubeBehave>().color = true;
			cubeField[colorCube.colorX, colorCube.colorY].GetComponent<fieldCubeBehave>().cubeColor = displayCube.GetComponent<nextCube>().NextCubeColor();
			
		}
		if (Input.GetKeyDown(KeyCode.Alpha5) && nextCubeDropped == false){
			nextCubeDropped = true;
			colorCube.colorX = 4;
			colorCube.colorY = Random.Range(1,8);
			cubeField[colorCube.colorX, colorCube.colorY].GetComponent<fieldCubeBehave>().color = true;
			cubeField[colorCube.colorX, colorCube.colorY].GetComponent<fieldCubeBehave>().cubeColor = displayCube.GetComponent<nextCube>().NextCubeColor();
			
		}
		
	}
		void ColorCubeMovement () {
		// cube that you clicked on is white with a active colored cube in previousX, previousY;
		
		if (activeCube.activeX != activeCube.desiredX || activeCube.activeY != activeCube.desiredY &&
		cubeField[activeCube.desiredX, activeCube.desiredY].GetComponent<fieldCubeBehave>().color == false){
			
			cubeField[activeCube.activeX, activeCube.activeY].GetComponent<fieldCubeBehave>().color = false;
			activeCube.previousX = activeCube.activeX;
			activeCube.previousY = activeCube.activeY;
	
			// limits the movement of the activeCube to within one cube length;
			if (activeCube.desiredX == activeCube.activeX+1) {
				activeCube.activeX++;
				
			}
			
			else if (activeCube.desiredX == activeCube.activeX-1) {
				activeCube.activeX--;
			}
			
			
		    if (activeCube.desiredY == activeCube.activeY+1){
				activeCube.activeY++;
			}
			
			else if (activeCube.desiredY == activeCube.activeY-1) {
				activeCube.activeY--;
			}
		}
		else if (activeCube.activeX == activeCube.desiredX && activeCube.activeY == activeCube.desiredY && cubeField[activeCube.desiredX, activeCube.desiredY].GetComponent<fieldCubeBehave>().color == true) {
			activeCube.activeColor = activeCube.nextColor;
			
		}
	}
	
	
	//this is supposed to take care of the cube's appearence
		void CubeAppearence () {
			foreach (GameObject cube in cubeField) {
				if (cube.GetComponent<fieldCubeBehave>().color == false) {
				cube.GetComponent<fieldCubeBehave>().cubeColor = Color.white;
				//potentially the problem for white cubes appearing after clicking between two colored cubes
				// color bool returning false on previousX,previousY && colored cube?
			} 
				cube.renderer.material.color = cube.GetComponent<fieldCubeBehave>().cubeColor;
				cube.transform.localScale = new Vector3 (1,1,1);
			}
			
			//this is supposed to set the color for the cube in the same place as active cube.
			if (cubeField[activeCube.activeX,activeCube.activeY] && activeCube.active == true) {
			cubeField[activeCube.activeX,activeCube.activeY].transform.localScale = new Vector3(2,2,2);
			cubeField[activeCube.activeX,activeCube.activeY].renderer.material.color = activeCube.activeColor;
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameTimer();
		Turn ();
		KeyBoardControl();
		CubeAppearence();
		ColorCubeMovement();
	}
		void OnGUI () {
		GUI.Box(timerBox, ("Remaining: ") + timeRemaining.ToString());
		GUI.Box(timer,("time: ") + theTime.ToString());
		GUI.Box(interval, ("interval: ") + countdown.ToString());
		GUI.Box(turnBox, ("turnInterval: ") + turnInterval.ToString());
		GUI.Box(nextTurnBox, ("turn: ") + (nextTurn/2).ToString());
		GUI.Box (colorCubeBox, ("POS: ") + colorCube.colorX.ToString() + (", ") + colorCube.colorY.ToString());
		GUI.Box (colorCubeBox2, ("color: ") + activeCube.nextColor.ToString());
	}
}
