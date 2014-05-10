using UnityEngine;
using System.Collections;

public class InputController : HasPlayer {
	public bool canInteract;
	// Use this for initialization
	override protected void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp("Quit")){
			Application.Quit();
		}
		if(Input.GetButtonUp("Restart")){
			Application.LoadLevel(Application.loadedLevelName);
		}
		if(player != null && player.motion != null){
			player.motion.applyMotion(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));
		}

		if(Input.GetButtonUp("Pause")){
			player.togglePause();
		}
	}
}
