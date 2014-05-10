using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
	[HideInInspector]
	public bool paused = false;
	
	public PlayerController player;

	// Use this for initialization
	void Start () {
		player.game = (GameLogic)this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void pause(){
		paused = true;
	}
	public void unpause(){
		paused = false;
	}
}
