using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {
	
	static int numBricks = 0;
	public int pointValue = 1;
	public int hitPoints = 1;

	GUIText guivictory;

	// Use this for initialization
	void Start () {
	numBricks++;
	}
		
	// Update is called once per frame
	void Update () {
	guivictory = GameObject.Find("guivictory").GetComponent<GUIText>();
	guivictory.enabled = false; 
	}
	
	void OnCollisionEnter( Collision col) {
		hitPoints--;
		
		if (hitPoints <= 0 ) 
		{
			Die();
		}
	}
		
	void Die() {
		
		Destroy (gameObject);
		GameObject.Find("Paddle").GetComponent<PaddleScript>().AddPoint(pointValue);
		numBricks--;
		Debug.Log (numBricks);
		if (numBricks <= 0) {
				//Load a new level
			Time.timeScale = 0;
			guivictory.enabled = true;
			
			
			
		}
	}
}
