using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldReact : MonoBehaviour {
	GameController gameController;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		rb = this.GetComponent<Rigidbody2D> ();
		GameController.groundPound += bounce;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void bounce () {
		Debug.Log ("Bounce");
		rb.AddForce (new Vector2 (0, 150.0f));
	}
	public void deactivate() {
		GameController.groundPound -= bounce;
		Destroy (this.gameObject);
	}
}
