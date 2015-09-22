using UnityEngine;
using System.Collections;

public class InputController : HasPlayer {
	public bool canInteract;
	[HideInInspector]
	public Vector2 direction;
	[HideInInspector]
	public Vector3 normalizedDirection;
	[HideInInspector]
	public bool lockAngle = false;
	// Use this for initialization
	override protected void Start () {
		base.Start();
		direction = normalizedDirection = new Vector3 (1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp("Quit")){
			Application.Quit();
		}
		if(Input.GetButtonUp("Restart")){
			Application.LoadLevel(Application.loadedLevelName);
		}

		direction = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
		if(direction.magnitude >0 && !lockAngle){
			normalizedDirection = new Vector3 (direction.x, direction.y, 0).normalized;
		}

		if(player != null && player.motion != null){
			player.motion.applyMotion(direction);
		}

		if(Input.GetButtonUp("Pause")){
			player.togglePause();
		}

		if(Input.GetButtonDown("Fire") || Input.GetButton("Fire")){
			player.fire();
		}
		if(Input.GetButtonUp("Fire")){
			player.stopFire();
		}
	}
}
