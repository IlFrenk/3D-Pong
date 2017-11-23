using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauser : MonoBehaviour {

	public Transform canvas;
	public AudioSource a1;
	public AudioSource a2;

	bool a1Playing = true;
	bool a2Playing = false;

	float a1Volume = 1f;
	float a2Volume = 0f;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}
	}

	public void Pause(){
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			Cursor.visible = true;
			//fadeIn (); //an attempt to fade in/out the 2 AudioSources. But a1.volume doesn't change the volume, maybe i should try with a CoRoutine.
			//fadeOut ();
//			a1Playing = false;
//			a2Playing = true;
//			a1.Stop (); //an alternative to fadeIN/OUT
//			a2.Play ();
		} else {
			canvas.gameObject.SetActive (false);
			Time.timeScale = 1;
			Cursor.visible = false;
			//fadeIn ();
			//fadeOut ();
//			a2Playing = false;
//			a1Playing = true;
//			a2.Stop ();
//			a1.Play ();
		}
	}

	void fadeIn(){
		if (a1Playing) {
			a2Volume += 0.1f * Time.deltaTime;
			a2.volume = a2Volume;
		} else if (a2Playing) {
			a1Volume += 0.1f * Time.deltaTime;
			a1.volume = a1Volume;
		}
	}



	void fadeOut(){
		if (a1Playing) {
			while (a1.volume > 0) {
				a1.volume -= 0.1f * Time.deltaTime;
				a1.volume = a1Volume;
			}
		} else if (a2Playing) {
			while (a2.volume > 0) {
				a2Volume -= 0.1f * Time.deltaTime;
				a2.volume = a2Volume;
			}
		}
	}



	public void ExitGame (){
		Application.Quit ();
	}
}
