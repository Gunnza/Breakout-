using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	//Destroy the ball and respawn a new ball on the paddle 
	public void Die() {
		
		//destroy ball gameobject 
		Destroy (gameObject);
		
		//Find the player paddle object
		GameObject paddleObject = GameObject.Find("Paddle");
		
		//Get the script Component from the paddle gameobject
		PaddleScript paddleScript = paddleObject.GetComponent<PaddleScript>();
		
		//Call the paddlescript respawn function
		paddleScript.Spawnball();
	}
}
