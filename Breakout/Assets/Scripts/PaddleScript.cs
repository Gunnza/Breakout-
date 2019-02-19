using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {
	
	
	public float PaddleSpeed = 10f;
	public GameObject ballPrefab;
	GameObject attachedBall = null;
	
	int lives = 4;
	GUIText guiLives;
	
	int score = 0;
	public GUISkin scoreboardSkin;

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(guiLives);
		guiLives = GameObject.Find("guiLives").GetComponent<GUIText>();
		Spawnball();
	}
	
	public void AddPoint(int v ) {
		score += v;
	}
	
	public void Spawnball() 
	{		
		attachedBall = (GameObject) Instantiate ( ballPrefab, transform.position + new Vector3 (0, 0.80f, 0), Quaternion.identity);
		
		lives--;
			
		guiLives.text = "Lives: " + lives;
	}
	
	void OnGUI() {
		GUI.skin = scoreboardSkin;
		GUI.Label (new Rect(0,10,100,100), "Score: " + score);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Left and Right
		transform.Translate (  PaddleSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
		
		if (transform.position.x > 7.4f)
		{
			transform.position = new Vector3( 7.4f, transform.position.y, transform.position.z);
		}
		if (transform.position.x < -7.4f)
		{
			transform.position = new Vector3( -7.4f, transform.position.y, transform.position.z);
		}
	}
	
	void FixedUpdate()
	{
		
		
	
		if (attachedBall)
		{
			Rigidbody ballRigidbody = attachedBall.rigidbody;
			ballRigidbody.position = transform.position + new Vector3 (0, .80f, 0);
			
						
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
		
		foreach (ContactPoint contact in col.contacts)
		{
			if ( contact.thisCollider == collider )
			{
				//this is the paddles contact point
				float english = contact.point.x - transform.position.x;
				
				contact.otherCollider.rigidbody.AddForce ( 300f * english, 0 , 0);
			}
		}
     }
}