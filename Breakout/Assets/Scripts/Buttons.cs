using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	
 

	// Use this for initialization
	void Start () {
	
		
	}
	
	// Update is called once per frame
	void Update () {
	
		gui ();
		}
	
	void gui() {
	
		if (GUI.Button (new Rect (0,10,100,100), "Play Breakout!")) {
    		Application.LoadLevel ("Level1");
	}
	
}
	
}
	

