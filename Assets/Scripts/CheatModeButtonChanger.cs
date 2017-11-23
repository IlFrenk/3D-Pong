using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatModeButtonChanger : MonoBehaviour {

	public Text cheatMode;
	public Button cheatModeB;
	Button btn;

	void Start(){
		Button btn = cheatModeB.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	
	// Update is called once per frame
	void Update () {
		if (Player1Controller.playerControllable) {
			cheatMode.text = "CHEAT MODE";
		} else {
			cheatMode.text = "NO CHEAT MODE";
		}
	}

	void TaskOnClick(){
		if (Player1Controller.playerControllable) {
			Player1Controller.EnableCheatMode ();
		} else if (BallBehaviour.ballControllable) {
			BallBehaviour.DisableCheatMode ();
		}
	}
}
