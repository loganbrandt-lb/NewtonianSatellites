/*This class is our management system for our satellies and is responsible for taking our mouse input and converting it to a launch vector that our satellites utilize. */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteManager : MonoBehaviour {
	//We declare two variables which will be where our mouse click starts and where it ends.
	Vector3 start;
	Vector3 end;

	Vector3 launchVector;

	public Satellite SatPrefab;

	Satellite Sat;
	//Update is called every frame. If you are unfamiliar with Unity this essentially means this function will be happening constantly.
	void Update(){
		//We are checking that a mouse click has started and logging its position when it started in the start variable. 
		if(Input.GetMouseButtonDown(0)){
			start = Input.mousePosition;
			Debug.Log("Start Position: " + start);
		}
		//Similarly we then check when the mouse click ends and log its position in the end varible. We then calculate the diffence between the start and the end in order to determine the 
		//launch vector which determines how much thrust the new satellite will have. We then call the add satellite function.
		if(Input.GetMouseButtonUp(0)){
			end = Input.mousePosition;
			launchVector = (start - end) / 100;
			Debug.Log("Calculated Launch Vector: " + launchVector);
			AddSatellite(launchVector);
		}
	}
	//The add satellite function simply instantiates the satellite at the center of the screen and then calls its initialization function that we created in order to pass our launch information.
	void AddSatellite(Vector3 LaunchVector){

	Sat = Instantiate(SatPrefab, new Vector3(-9.8f,2,-25), Quaternion.Euler(0,0,0)) as Satellite;
	Sat.theStart(launchVector);

	}
}
