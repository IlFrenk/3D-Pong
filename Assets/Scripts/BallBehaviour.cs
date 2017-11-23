using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

	public Vector3 impulsoIniziale;
	public Rigidbody rb;
	public static bool ballControllable = false;
	public float speed;
	public AudioSource audioS;
	int jCount = 0;


	public static Collider coll;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (impulsoIniziale, ForceMode.Impulse);
		coll = GetComponent<Collider>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (ballControllable) { //too many CPU cycles wasted! :(
			//ON CHEAT MODE:
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			if(Input.GetKeyDown (KeyCode.Space)){
				rb.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse); // makes the ball jump. It's cheat mode, so you can also fly with spamming the space bar!
				jCount++;
			}

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			rb.AddForce (movement * speed);
			if (Input.GetMouseButtonDown (1)) {
				//pressed right mouse button
				DisableCheatMode ();
			}
		}
		else if (Player1Controller.playerControllable)
			transform.Rotate (impulsoIniziale * 2); //moves the ball statically
	}

	void OnCollisionEnter(Collision col){
		audioS.Play ();
		if (ballControllable) {
			if (col.gameObject.tag == "PlayerWall" || col.gameObject.tag == "OpponentWall" || col.gameObject.tag == "Boundary") {
				rb.velocity = new Vector3 (0f, 0f, 0f);
				rb.AddForce (new Vector3 (0, -6 * jCount, 0), ForceMode.Impulse);
				jCount = 0;

			}
		}
	}

	public static void DisableCheatMode (){
		//CHEAT MODE DISABLED!
		ballControllable = false;
		Player1Controller.playerControllable = true;
		coll.material.dynamicFriction = 0; //restores the
		coll.material.bounciness = 1; //physic material
		coll.material.staticFriction = 0; //of the ball
		Player1Controller.chmStatus.text = "";
	}
}
