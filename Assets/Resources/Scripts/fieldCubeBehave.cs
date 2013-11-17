using UnityEngine;
using System.Collections;

public class fieldCubeBehave : MonoBehaviour {
	public int cubeX, cubeY;
	public Color cubeColor = Color.white;
	public bool active = false;
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
		
		if (active == true && color == true){
			active = false;
			transform.localScale = new Vector3(1,1,1);
		}
		else if (active == false && color == true) {
			active = true;
			transform.localScale = new Vector3(2,2,2);
		}
		
		if (cubeColor == Color.white){
		}
	}         
}
