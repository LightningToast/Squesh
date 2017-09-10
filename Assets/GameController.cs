using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public delegate void ChangeEvent ();
	public static event ChangeEvent groundPound;

	int walking;
	int squeshAllow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("space")) {
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
}
