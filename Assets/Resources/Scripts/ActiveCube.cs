using UnityEngine;
using System.Collections;
//this class is used so that there is only ever one active cube.
public class ActiveCube{
public int activeX, activeY, desiredX, desiredY, previousX, previousY;
public Color activeColor, targetColor;
public bool active = false;
}
