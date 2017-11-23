using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderRuler : MonoBehaviour {

	public GameObject ballExplosion;
	public AudioSource audioS;
	public Text scoreText;
	static int playerScore;
	static int opponentScore;


	void Start()
	{
		playerScore = 0;
		opponentScore = 0;
		SetScoreText ();
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Ball"){
			Instantiate (ballExplosion, col.transform.position, col.transform.rotation);
			audioS.Play ();
			if (gameObject.tag == "PlayerWall")
				opponentScore++;
			if (gameObject.tag == "OpponentWall")
				playerScore++;
			SetScoreText ();
			//Destroy the expliosion clones!!
			col.gameObject.transform.position = new Vector3 (0f, 0.75f, 0f); //puts the ball back on track
		}
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + playerScore.ToString () + " - " + opponentScore.ToString ();
	}
}