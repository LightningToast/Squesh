using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawn : MonoBehaviour {
	public float flowerSpawnAmount;
	public float flowerSpawnRate;
	float flowerSpawnVal;
	public GameObject flower;

	public float cloudSpawnAmount;
	public float cloudSpawnRate;
	float cloudSpawnVal;
	public GameObject cloud;

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
		cloudSpawnVal += (cloudSpawnRate + Random.Range (0, cloudSpawnRate)) * gameController.getWalking();
		if(cloudSpawnVal >= cloudSpawnAmount) {
			cloudSpawn ();
		}
	}
	void flowerSpawn () {
		GameObject obj = (GameObject)GameObject.Instantiate (flower, this.transform.position, this.transform.rotation);
		flowerSpawnVal = 0;
	}
	void cloudSpawn () {
		Vector2 pos = this.transform.position;
		pos.y = Random.Range (0, 6.5f);
		GameObject obj = (GameObject)GameObject.Instantiate (cloud, pos, this.transform.rotation);
		cloudSpawnVal = 0;
	}
}
