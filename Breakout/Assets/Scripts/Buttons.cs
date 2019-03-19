using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	
		//calling the GUI function
		gui ();
		
	}
	
	void gui() {
		
		//If user presses button the game will load level 1
		if (GUI.Button (new Rect (0,10,100,100), "Play Breakout!")) {
			
    			Application.LoadLevel ("Level1");
			
		}
	
	}
	
}
	

