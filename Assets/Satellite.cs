using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {

public Rigidbody RB;
public Vector3 thrusterForce;

public float thrusterPower;

	public void theStart(Vector3 launchVector){
		thrusterForce = launchVector * thrusterPower;
		RB = gameObject.GetComponent<Rigidbody>();
		RB.velocity = thrusterForce;
	}

void OnTriggerEnter(Collider other){

	Debug.Log("Collision Detected with: " + other.transform.name);
	if(other.transform.name != "Earth"){
		Destroy(other.gameObject);
	}else{
		Destroy(this.gameObject);
	}
}

}
