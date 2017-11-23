using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Controller : MonoBehaviour {

	public float speed;
	public static bool playerControllable = true;

	public static Text chmStatus;


	void Start(){
		chmStatus = GameObject.Find ("CheatModeStatus").GetComponent<Text> (); // makes a reference to the text "CheatModeStatus"
		chmStatus.text = "";
		Cursor.visible = false;
	}

	void FixedUpdate()
	{
		if (playerControllable) { //too many CPU cycles wasted! :(
			float moveVertical = Input.GetAxis ("Vertical");

			transform.position += new Vector3 (0.0f, 0.0f, moveVertical * speed * Time.deltaTime); //moves the player only on the Z-axis
			if (Input.GetMouseButtonDown (0)) {
				//pressed left mouse button
				EnableCheatMode ();
			}
		}
	}

	public static void EnableCheatMode(){
		//CHEAT MODE ENABLED!
		playerControllable = false;
		BallBehaviour.ballControllable = true;
		BallBehaviour.coll.material.dynamicFriction = 0.9f; //change ball's
		BallBehaviour.coll.material.staticFriction = 0.9f; //physic
		BallBehaviour.coll.material.bounciness = 0.2f; //material
		chmStatus.text = "CHEAT MODE: ON";
	}
}