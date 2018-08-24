/* This class represents the Satellite object itself. A new satellite is created in the Satellite Manager script. This script is primarily responsible for detecting collisions as well as 
applying thrust to the satellite when it is created. */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {

public Rigidbody RB;
public Vector3 thrusterForce;

public float thrusterPower;

	//We use a function called theStart here. Essentially this is the initialization of our Satellite, however we can't use the regular Start function since we are instantiating the object else where,
	// and we need the values passed from there.
	public void theStart(Vector3 launchVector){

		//Thruster power will be set in Unity. The launch vector was created in our Satellite Manager class by clicking and dragging our mouse.
		thrusterForce = launchVector * thrusterPower;
		RB = gameObject.GetComponent<Rigidbody>();
		//We utilize Unity's rigidbody component in order to handle the velocity of our satellite. 
		RB.velocity = thrusterForce;
	}

//The OnTriggerEnter function will occur when ever the object's collider passes through another. We use this to detect collisions. If the collision happens to be Earth, we don't want to destroy Earth.

void OnTriggerEnter(Collider other){

	Debug.Log("Collision Detected with: " + other.transform.name);
	if(other.transform.name != "Earth"){
		Destroy(other.gameObject);
	}else{
		Destroy(this.gameObject);
	}
}

}
