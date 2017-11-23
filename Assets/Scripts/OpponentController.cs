using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour {

	Transform ball;
	public float speed;
	Vector3 transVec;
	Vector3 ballVec;
	float containerZ; //maximum of Z-axis movement of the opponent

	// Use this for initialization
	void Start () {

		ball = GameObject.FindGameObjectWithTag ("Ball").transform;

	}

	// Update is called once per frame
	void FixedUpdate () {
		containerZ = ball.position.z;
		float step = speed * Time.deltaTime;
		if(containerZ > 4)
			containerZ = 4;
		if(containerZ < -4)
			containerZ = -4;
		transVec = new Vector3 (11.9f, 0.75f, transform.position.z);
		ballVec = new Vector3 (0f, 0f, containerZ);
		transform.position = Vector3.MoveTowards(transVec, ballVec, step);
	}
}
