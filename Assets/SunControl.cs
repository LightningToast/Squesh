using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunControl : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void angry () {
		anim.SetBool ("Angry", true);
	}
	public void happy () {
		anim.SetBool ("Angry", false);
	}
	public void fall () {
		this.GetComponent<Rigidbody2D> ().gravityScale = 2;
	}
	void OnCollisionEnter2D(Collision2D coll) {
		coll.gameObject.GetComponent<Character> ().squesh ();
	}

}
