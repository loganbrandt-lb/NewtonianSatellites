/* This will be the base class for any object that will be affected by gravity. In real life this would be every single object in the world, no matter how small. It's important to note that this
class utilizes Unity's Rigidbody system to handle the mass of the objects as well as to handle how forces are added to an object. We will be utilizing Newton's Law of Universal Gravitation: F = (G x M1 x M2) / r^2
where F is the force of gravity, G is the gravitational constant, M1 is the mass of the first object, M2 is the mass of the second object, and r is the distance between the two masses.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityObject : MonoBehaviour {

	public Rigidbody rb;


 // G will represent the gravitational constant. We are increasing the gravitational constant to avoid working with very small numbers. We only need to make sure that our masses remain proportional so that
 // the simulation remains realistic.
	public float G = 6.7f; 

// Fixed Update is called at the end of each frame. If you're not familiar with Unity, that means that the operations inside this function will happen almost constantly.
	void FixedUpdate(){
		//We first find all of the objects in the scene that will be effected by gravity and add them to an array.
		gravityObject[] attractors = FindObjectsOfType<gravityObject>();
		//We loop through the array, and start attracting all objects in the array that aren't this object. It's important to note that Newtons Law of Universal Gravitation states that all objects
		// attract one another, and the level of attraction is based on the mass of the object. So, even the small satellites we will be producing "attract" the earth, even though it seems to the eye
		// that the earth is only attracting them.
		foreach (gravityObject attractor in attractors)
		{
			if(attractor != this){
			//We will pass every object in the array (which means every object affected by gravity) to our attract function.	
			Attract(attractor);
			}
		}

	}


// The attract function is where we will compute all of the mathematics behind Newton's Law of Universal Gravitation
	void Attract(gravityObject objToAttract){
		//We get the rigidbody component from the object that was passed. Remember this contains all of the information about an objects mass.
		Rigidbody rbToAttract = objToAttract.rb;

		//We then determine the direction by subtracting the two rigidbody's positions. A position is represented by a Vector 3 in Unity. If you're unfamiliar with Unity, this is the X, Y, and Z axis of 3-Dimensional space
		Vector3 direction = rb.position - rbToAttract.position;
		//We can get the distance from our direction vector by reading it's magnitude and putting that into a variable. In Unity a Vector 3, will have a magnitude which is the same as a distance.
		float distance = direction.magnitude;
		//We then do Newton's equation: F = G * (M1 * M2) / R^2
		float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
		//We then have to normalize the direction we took earlier, which remember was a Vector 3. By normalizing it, we set it's magnitude(or distance) to 1. We multiply that normalized Vector 3 by our 
		//forceMagnitude and add that force to the object that we are attracting. 
		Vector3 force = direction.normalized * forceMagnitude;
		rbToAttract.AddForce(force);
	}


}
