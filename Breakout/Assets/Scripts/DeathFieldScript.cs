using UnityEngine;
using System.Collections;

public class DeathFieldScript : MonoBehaviour {

	//If the ball misses the paddle the ball needs to be destroyed
	void OnTriggerEnter(Collider other) {
		
		//Getting the script component from the ball when it collides
		BallScript ballScript = other.GetComponent <BallScript>();
		
		// call the die function
		if (ballScript) 
		{
			ballScript.Die();
		}	
	}
}
