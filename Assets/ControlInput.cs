using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlInput : MonoBehaviour {
	bool firstTouch = true;
	public bool touched = false;

	GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Touch touch in Input.touches) {
			Vector2 touchPos2D = Camera.main.ScreenToWorldPoint (touch.position);
			if (touch.phase == TouchPhase.Began) {
				if (firstTouch) {
					firstTouch = false;
					GameObject.Find ("Title").GetComponent<TextMesh> ().text = "";
				}
				if (gameController.getGameOver()) {
					SceneManager.LoadScene ("Game");
				}
				RaycastHit2D hitInformation = Physics2D.Raycast (touchPos2D, Camera.main.transform.forward);
				if (hitInformation.collider != null) {
					GameObject touchedObject = hitInformation.transform.gameObject;
					if (touchedObject.name.Equals ("Continue")) {
						
					} else if (touchedObject.name.Equals ("Restart")) {
						
					}

				}
			}
		}
		if(Input.touchCount > 0) {
			touched = true;
		} else {
			touched = false;
		}
	}

	public bool getTouched () {
		return touched;
	}
	public bool getStart () {
		return firstTouch;
	}
}
