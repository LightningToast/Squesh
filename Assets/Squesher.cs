using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squesher : MonoBehaviour {
	float squishTime = 1.5f;
	float holdTime = 1.0f;
	float yUp = 5.25f;
	float yDown = -3.1f;
	float yBuffer = 0.05f;

	float yTarget = 5.25f;

	float yFallSpeed = 80.0f;
	float yRiseSpeed = 4.0f;

	public bool groundHit = false;

	public bool ready = false;
	bool reset = false;

	bool fall = false;

	int score = 0;

	Rigidbody2D rb;

	GameController gameController;
	TextMesh scoreText;
	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		rb = this.GetComponent<Rigidbody2D> ();
		scoreText = GameObject.Find ("Score").GetComponent<TextMesh> ();
		StartCoroutine (squishTimer());
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y > yTarget + yBuffer) {
			rb.AddForce (new Vector2 (0, -yFallSpeed));
			fall = true;
		} else if(transform.position.y < yTarget) {
			rb.velocity = new Vector2 (0, yRiseSpeed);
			fall = false;
			//Debug.Log("Reset");


		} else {
			fall = false;
			rb.velocity = new Vector2 (0, 0);
		}
		if (this.transform.position.x < -5.5f) {
			
			this.transform.position = new Vector2 (7.5f + Random.Range (-2.5f, -0.5f), this.transform.position.y);
			reset = false;
		}
		if ((this.transform.position.x < -4.75f) && (!reset)) {
			score++;
			scoreText.text = "" + score;
			reset = true;
		}
			
	}
	public int getScore() {
		return score;
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
