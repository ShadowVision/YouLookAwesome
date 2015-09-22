using UnityEngine;
using System.Collections;

public class SpawnMe : MonoBehaviour {
	public Transform spawnPoint;
	public GameObject spawnObject;
	public bool spawnOnStart = true;
	public KeyCode spawnKey;

	// Use this for initialization
	void Start () {
		if (spawnOnStart) {
			spawn ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(spawnKey)){
			spawn();
		}
	}
	public GameObject spawn(){
		return (GameObject)Instantiate (spawnObject, spawnPoint.position, spawnPoint.rotation);
	}
}
