using UnityEngine;
using System.Collections;

public class fieldCubeBehave : MonoBehaviour {
	public int cubeX, cubeY;
	public Color cubeColor = Color.white;
	public bool color = false;
	public GameObject[,] cubeField;
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		print ("my position is: " + cubeX + "," + cubeY);
		if (color == true && Camera.main.GetComponent<game>().activeCube.activeX != cubeX || Camera.main.GetComponent<game>().activeCube.activeY != cubeY) {
			Camera.main.GetComponent<game>().activeCube.activeX = cubeX;
			Camera.main.GetComponent<game>().activeCube.activeY = cubeY;
			Camera.main.GetComponent<game>().activeCube.activeColor = cubeField[Camera.main.GetComponent<game>().activeCube.activeX, Camera.main.GetComponent<game>().activeCube.activeY].GetComponent<fieldCubeBehave>().cubeColor;
			
			
			}
		if (color == false && Camera.main.GetComponent<game>().activeCube.active == true){
			Camera.main.GetComponent<game>().activeCube.desiredX = cubeX;
			Camera.main.GetComponent<game>().activeCube.desiredY = cubeY;
			}
		}
	}
