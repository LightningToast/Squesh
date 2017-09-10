using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawn : MonoBehaviour {
	public float flowerSpawnAmount;
	public float flowerSpawnRate;
	float flowerSpawnVal;
	public GameObject flower;

	GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		flowerSpawnVal += (flowerSpawnRate + Random.Range (0, flowerSpawnRate)) * gameController.getWalking();
		if(flowerSpawnVal >= flowerSpawnAmount) {
			flowerSpawn ();
		}
	}
	void flowerSpawn () {
		GameObject obj = (GameObject)GameObject.Instantiate (flower, this.transform.position, this.transform.rotation);
		flowerSpawnVal = 0;
	}
}
