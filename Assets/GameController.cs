using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public delegate void ChangeEvent ();
	public static event ChangeEvent groundPound;

	int walking;
	int squeshAllow;
	ControlInput gameInput;

	public bool gameOver = false;
	// Use this for initialization
	void Start () {
		gameInput = GameObject.Find ("TouchInput").GetComponent<ControlInput> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameInput.getTouched()) {
			walking = 1 * squeshAllow;
		} else {
			walking = 0;
		}
	}
	public void groundHit () {
		groundPound ();
	}
	public int getWalking () {
		return walking;
	}
	public void setSqueshAllow (int val) {
		squeshAllow = val;
	}
	public void setGameOver (bool val) {
		gameOver = val;
	}
	public bool getGameOver () {
		return gameOver;
	}
}
