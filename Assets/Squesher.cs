using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squesher : MonoBehaviour {
	float squishTime = 3.0f;
	float holdTime = 2.0f;
	float yUp = 5.25f;
	float yDown = -3.1f;
	float yBuffer = 0.05f;

	float yTarget = 5.25f;

	float yFallSpeed = 40.0f;
	float yRiseSpeed = 2.0f;

	public bool groundHit = false;

	public bool ready = false;

	bool fall = false;

	Rigidbody2D rb;

	GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		rb = this.GetComponent<Rigidbody2D> ();
		StartCoroutine (squishTimer());
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y > yTarget + yBuffer) {
			rb.AddForce (new Vector2 (0, -yFallSpeed));
			fall = true;
		} else if(transform.position.y < yTarget) {
			rb.velocity = new Vector2 (0, yRiseSpeed);
			//Debug.Log("Reset");


		} else {
			
			rb.velocity = new Vector2 (0, 0);
		}
		if (this.transform.position.x < -7.5f) {
			this.transform.position = new Vector2 (7.5f, this.transform.position.y);
		}
			
	}

	IEnumerator squishTimer () {
		yTarget = yDown;
		yield return new WaitForSeconds (holdTime);
		yTarget = yUp;
		yield return new WaitForSeconds(squishTime);
		StartCoroutine (squishTimer());
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.name.Equals("SqueshStop")) {
			gameController.groundHit ();
			fall = false;
		}
		if (coll.gameObject.tag.Equals ("Player")) {
			if(fall) {
				coll.gameObject.GetComponent<Character> ().squesh ();
			}
		}

	}
}
