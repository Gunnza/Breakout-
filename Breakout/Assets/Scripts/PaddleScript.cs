using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {
	
	//Speed player can move paddle
	public float PaddleSpeed = 10f;
	
	//gameobject variables 
	public GameObject ballPrefab;
	GameObject attachedBall = null;
	
	//Lives Variables
	int lives = 4;
	GUIText guiLives;
	
	//Score variables
	int score = 0;
	public GUISkin scoreboardSkin;

	// Use this for initialization
	void Start () {
		//Keeping paddle throughout all the levels with dont destroy
		DontDestroyOnLoad(gameObject);
		
		//Keeping lives integer throughout all the levels
		DontDestroyOnLoad(guiLives);
		
		//accessing the gui text component
		guiLives = GameObject.Find("guiLives").GetComponent<GUIText>();
		
		//on start call the spawn ball function
		Spawnball();
	}
	
	//add points to the player with this function 
	public void AddPoint(int v ) {
		score += v;
	}
	
	public void Spawnball() {
		
		//place ball gameobject on paddle
		attachedBall = (GameObject) Instantiate ( ballPrefab, transform.position + new Vector3 (0, 0.80f, 0), Quaternion.identity);
		
		//reduce the number of lives for the player
		lives--;
		
		//update the number of lives on the GUI
		guiLives.text = "Lives: " + lives;
	}
	
	void OnGUI() {
		
		//using custom skin for GUI
		GUI.skin = scoreboardSkin;
		
		//Drawing GUI with the score
		GUI.Label (new Rect(0,10,100,100), "Score: " + score);
	}
	
	// Update is called once per frame
	void Update () {
		
		//User input for left and right movement
		transform.Translate (  PaddleSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
		
		//limiting the x position so that the paddle cant go out of the screen
		if (transform.position.x > 7.4f)
		{
			transform.position = new Vector3( 7.4f, transform.position.y, transform.position.z);
		}
		if (transform.position.x < -7.4f)
		{
			transform.position = new Vector3( -7.4f, transform.position.y, transform.position.z);
		}
	}
	
	void FixedUpdate() {
		
		if (attachedBall)
		{
			Rigidbody ballRigidbody = attachedBall.rigidbody;
			ballRigidbody.position = transform.position + new Vector3 (0, .80f, 0);
			
			//button to launch the ball			
			if (Input.GetButtonDown ("LaunchBall" ) )
			{
				attachedBall.rigidbody.isKinematic = false;
				ballRigidbody.AddForce(300f * Input.GetAxis("Horizontal"), 300f, 0);
				attachedBall = null;
			}
		}
	}
	
	
	void OnCollisionEnter (Collision col) 
	{
		//add force to the ball from the point it contacts the paddle
		foreach (ContactPoint contact in col.contacts)
		{
			if ( contact.thisCollider == collider )
			{
				//this is the paddles contact point
				float english = contact.point.x - transform.position.x;
				
				//adding the force to the ball 
				contact.otherCollider.rigidbody.AddForce ( 300f * english, 0 , 0);
			}
		}
     }
}
