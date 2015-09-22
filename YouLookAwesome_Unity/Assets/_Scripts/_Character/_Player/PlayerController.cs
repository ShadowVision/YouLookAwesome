using UnityEngine;
using System.Collections;
using ShadowVision;

public class PlayerController : Character {
	private GameHelpers.Direction currentDirection = GameHelpers.Direction.DOWN;
	
	[HideInInspector]
	public AnimationController anim;
	[HideInInspector]
	public GameLogic game;
	[HideInInspector]
	public InputController input;
	[HideInInspector]
	public MotionController motion;
	[HideInInspector]
	public UIController ui;
	[HideInInspector]
	public Camera cam;


	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<AnimationController>();
		input = gameObject.GetComponent<InputController>();
		motion = gameObject.GetComponent<MotionController>();
		ui = gameObject.GetComponent<UIController>();
		cam = gameObject.GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		weapon.setDir (input.normalizedDirection, motion.vel);
	}

	public void faceDirection(GameHelpers.Direction dir){
		if(dir != currentDirection){
			currentDirection = dir;
			anim.setDirection(currentDirection);
		}
	}
	public void togglePause(){
		if(!game.paused){
			game.pause();
			pause ();
		}else{
			game.unpause();
			unpause ();
		}
	}
	public void pause(){
		motion.motionLocked = true;
		input.canInteract = false;
		cam.enabled = false;
		ui.showInventory();
	}
	public void unpause(){
		motion.motionLocked = false;
		input.canInteract = true;
		cam.enabled = true;
		ui.hideInventory();
	}
	public void fire(){
		input.lockAngle = true;
		weapon.fire ();
	}
	public void stopFire(){
		input.lockAngle = false;
	}
}