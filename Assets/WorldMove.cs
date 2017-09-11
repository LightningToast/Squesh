using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour {
	GameController gameController;
	public float offset = 0.0f;
	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 curPos = this.transform.position;
		this.transform.position = new Vector2 (curPos.x - 0.06f * gameController.getWalking () + offset, curPos.y);

		if(transform.position.y < -10.0f) {
			this.GetComponent<WorldReact> ().deactivate ();
		}
		//Debug.Log (rb.velocity);
	}


}
