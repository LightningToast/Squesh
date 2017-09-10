using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squesher : MonoBehaviour {
	float squishTime = 10.0f;
	float holdTime = 2.0f;
	float yUp = 5.25f;
	float yDown = -3.1f;

	float yTarget = 5.25f;

	float yFallSpeed = 10.0f;
	float yRiseSpeed = 2.0f;

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		StartCoroutine (squishTimer());
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y > yTarget) {
			rb.AddForce (new Vector2 (0, -yFallSpeed));
		} else if(transform.position.y < yTarget) {
			rb.velocity = new Vector2 (0, yRiseSpeed);
		} else {
			rb.velocity = new Vector2 (0, 0);
		}
	}

	IEnumerator squishTimer () {
		yTarget = yDown;
		yield return new WaitForSeconds (holdTime);
		yTarget = yUp;
		yield return new WaitForSeconds(squishTime);
		StartCoroutine (squishTimer());
	}
}
