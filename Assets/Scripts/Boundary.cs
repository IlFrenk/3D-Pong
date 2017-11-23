using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

	public GameObject ballExplosion;
	public AudioSource audioS;

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Ball") {
			Instantiate (ballExplosion, other.transform.position, other.transform.rotation);
			audioS.Play();
			other.gameObject.transform.position = new Vector3 (0f, 0.75f, 0f); //puts the ball back on track
		}
	}
}
