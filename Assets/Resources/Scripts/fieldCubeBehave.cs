using UnityEngine;
using System.Collections;

public class fieldCubeBehave : MonoBehaviour {
	public int cubeX, cubeY;
	//the movable ints are supposed to limit the movement of the ActiveCube class, and clicking.
	public Color cubeColor = Color.white;
	public bool color = false;
	public GameObject[,] cubeField;
	public ActiveCube activeCube;
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		print ("my position is: " + cubeX + "," + cubeY);
			if (color == true) {
			activeCube.activeX = cubeX;
			activeCube.activeY = cubeY;
			activeCube.desiredX = cubeX;
			activeCube.desiredY = cubeY;
			activeCube.activeColor = cubeColor;
			activeCube.active = true;
			
			}
			else if (color == false && activeCube.active == true) {
			activeCube.desiredX = cubeX;
			activeCube.desiredY = cubeY;
			}
		}
	}
