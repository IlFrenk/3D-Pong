using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	//public RotationAxes axes = RotationAxes.MouseXAndY;


	public GameObject ball;
	public Vector3 offset;


	public float mouseSensitivity = 400.0f;
	public float clampAngle = 80.0f; //the camera will not exceed this rotation angle

	private float rotY = 0.0f; 
	private float rotX = 0.0f;


	void Start(){
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
	}

	/* CAMERA MOVEMENT.
	 * the camera should rotate around the ball gameObject, instead with this code
	 * the camera rotates without changing her position in reference to the ball gameObject */

	void Update ()
	{
		if (BallBehaviour.ballControllable) {
			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = -Input.GetAxis ("Mouse Y");

			rotY += mouseX * mouseSensitivity * Time.deltaTime;
			rotX += mouseY * mouseSensitivity * Time.deltaTime;

			rotX = Mathf.Clamp (rotX, -clampAngle, clampAngle);

			Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0.0f);
			transform.rotation = localRotation;
		} 
		else if (Player1Controller.playerControllable) {
			transform.position = new Vector3 (0.0f, 15f, -13f); //restores the camera position
			transform.rotation = new Quaternion (84f, 0f, 0f, 180f); //restores the camera rotation
		}
	}


	void LateUpdate () {
		if (BallBehaviour.ballControllable) {
			transform.position = ball.transform.position + offset;

		}
	}
}
