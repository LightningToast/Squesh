using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	bool walk = false;
	Animator anim;
	GameController gameController;
	ControlInput gameInput;

	float standMax = 3.0f;
	float standCount;

	bool squeshed = false;

	SunControl sun;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		sun = GameObject.Find ("Sun").GetComponent<SunControl> ();
		gameInput = GameObject.Find ("TouchInput").GetComponent<ControlInput> ();
		standCount = standMax;
	}
	
	// Update is called once per frame
	void Update () {
		if(squeshed) {
			return;
		}
		gameController.setSqueshAllow (1);
		if(walk) {
			standCount = standMax;
			sun.happy ();
			anim.SetBool ("Walk", true);
		} else {
			anim.SetBool ("Walk", false);
		}
		if(gameInput.getTouched()) {
			walk = true;
		} else {
			walk = false;
		}

		if (!gameInput.getStart ()) {
			standCount -= Time.deltaTime;
			if (standCount < standMax / 2) {
				sun.angry ();
			}
			if (standCount < 0) {
				sun.fall ();
			}
		}
	}
	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.name.Equals ("Squesher")) {
			gameController.setSqueshAllow (0);
		}
	}
	public void squesh() {
		if (!squeshed) {
			this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			this.transform.localScale = new Vector2 (this.transform.localScale.x, this.transform.localScale.y / 4);
			squeshed = true;
			anim.SetBool ("Walk", false);
			gameController.setSqueshAllow (0);
			if(GameObject.Find ("Squesher").GetComponent<Squesher>().getScore() > PlayerPrefs.GetInt("HighScore")) {
				PlayerPrefs.SetInt ("HighScore", GameObject.Find ("Squesher").GetComponent<Squesher> ().getScore ());
			}
			gameController.setGameOver (true);
			GameObject.Find ("HighScore").GetComponent<TextMesh> ().text = "High Score: " + PlayerPrefs.GetInt("HighScore");
		}
	}
}
