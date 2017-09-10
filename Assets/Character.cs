using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	bool walk = false;
	Animator anim;
	GameController gameController;

	bool squeshed = false;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(squeshed) {
			return;
		}
		gameController.setSqueshAllow (1);
		if(walk) {
			anim.SetBool ("Walk", true);
		} else {
			anim.SetBool ("Walk", false);
		}
		if(Input.GetKey("space")) {
			walk = true;
		} else {
			walk = false;
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
		}
	}
}
