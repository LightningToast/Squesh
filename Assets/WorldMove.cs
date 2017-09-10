using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour {
	GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 curPos = this.transform.position;
		this.transform.position = new Vector2 (curPos.x - 0.04f * gameController.getWalking (), curPos.y);

		if(transform.position.y < -10.0f) {
			this.GetComponent<WorldReact> ().deactivate ();
		}
		//Debug.Log (rb.velocity);
	}


}
