using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityObject : MonoBehaviour {

	public Rigidbody rb;

	public float G = 6.7f;

	void FixedUpdate(){

		gravityObject[] attractors = FindObjectsOfType<gravityObject>();
		foreach (gravityObject attractor in attractors)
		{
			if(attractor != this){
			Attract(attractor);
			}
		}

	}

	void Attract(gravityObject objToAttract){
		Rigidbody rbToAttract = objToAttract.rb;
		Vector3 direction = rb.position - rbToAttract.position;
		float distance = direction.magnitude;
		float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
		Vector3 force = direction.normalized * forceMagnitude;
		rbToAttract.AddForce(force);
	}


}
