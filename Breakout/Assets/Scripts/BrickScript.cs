using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {

	//Int variable to know how many bricks their are
	static int numBricks = 0;
	
	//Value of each point
	public int pointValue = 1;
	
	//Bricks health integer
	public int hitPoints = 1;
	
	//GUI variable 
	GUIText guivictory;

	// Every brick adds 1 to number of bricks
	void Start () {
		numBricks++;
	}
		
	void Update () {
		//Getting the text component on the gui game object 
		guivictory = GameObject.Find("guivictory").GetComponent<GUIText>();
		guivictory.enabled = false; 
	}
	
	//function that recognises when object collides 
	void OnCollisionEnter( Collision col) {
		
		//reduce health of the brick
		hitPoints--;
		
		//call die function if health is zero 
		if (hitPoints <= 0 ) 
		{
			Die();
		}
	}
		
	void Die() {
		
		//delete the gameobject from the scene
		Destroy (gameObject);
		
		//Get the players paddle's script component PaddleScript and add a point equal to the point value
		GameObject.Find("Paddle").GetComponent<PaddleScript>().AddPoint(pointValue);
		
		//reduce the number of bricks in the game
		numBricks--;
		
		//console logging the number of bricks in the scene
		Debug.Log (numBricks);
		
		//victory condition if the number of bricks is zero
		if (numBricks <= 0) {
			
			//Stop time in the game	
			Time.timeScale = 0;
			
			//enable the victory GUI object
			guivictory.enabled = true;
				
		}
	}
}
