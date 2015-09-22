using UnityEngine;
using System.Collections;
using ShadowVision;

public class MotionController : HasPlayer {
	private Vector3 _vel = new Vector3(0,0,0);
	public Vector3 vel{
		get{
			return _vel;
		}
		set{
			_vel = value;
			updateDirection();
		}
	}
	
	public bool motionLocked = true;
	public bool motionIn3D = true;
	public float speed = 1f;

	// Use this for initialization
	override protected void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		if(!motionLocked){
			Vector3 newPosition = transform.position;
			newPosition.x += vel.x* Time.deltaTime;
			newPosition.y += vel.y* Time.deltaTime;
			if(motionIn3D){
				newPosition.z += vel.z* Time.deltaTime;
			}
			transform.position = newPosition;
		}
	}
	private void updateDirection(){
		GameHelpers.Direction newDirection = GameHelpers.getDirectionFromVelocity(_vel);
		player.faceDirection(newDirection);

	}

	public void applyMotion(Vector2 newInputDirection){
		vel = newInputDirection * speed;
	}
}
