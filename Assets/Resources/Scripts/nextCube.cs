using UnityEngine;
using System.Collections;

public class nextCube : MonoBehaviour{
	Color returnColor;
	public int nextColumn, nextRow, nextColorInt;
		
	public Color NextCubeColor (){
		switch (nextColorInt) {
		case 1:
			returnColor = Color.blue;
			break;
		case 2:
			returnColor = Color.green;
			break;
		case 3:
			returnColor = Color.yellow;
			break;
		case 4:
			returnColor = Color.cyan;
			break;
		case 5:
			returnColor = Color.red;
			break;
		default:
			returnColor = Color.grey;
			break;
		case 6:
			returnColor = Color.red;
			break;
		case 7:
			returnColor = Color.cyan;
			break;
		}
		return returnColor;
	}
}

