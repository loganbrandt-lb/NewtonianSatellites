using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteManager : MonoBehaviour {

	Vector3 start;
	Vector3 end;

	Vector3 launchVector;

	public Satellite SatPrefab;

	Satellite Sat;

	void Update(){
		if(Input.GetMouseButtonDown(0)){
			start = Input.mousePosition;
			Debug.Log("Start Position: " + start);
		}

		if(Input.GetMouseButtonUp(0)){
			end = Input.mousePosition;
			launchVector = (start - end) / 100;
			Debug.Log("Calculated Launch Vector: " + launchVector);
			AddSatellite(launchVector);
		}
	}

	void AddSatellite(Vector3 LaunchVector){

	Sat = Instantiate(SatPrefab, new Vector3(-9.8f,2,-25), Quaternion.Euler(0,0,0)) as Satellite;
	Sat.theStart(launchVector);

	//Use that vector 3 to add force to a new Satellite
	//Instantiate that Satellite


	}
}
