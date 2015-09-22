using UnityEngine;
using System.Collections;

public class DirectionalObject : MonoBehaviour {
	private float angle = 0;

	public float modX = 0;
	public float modY = 0;
	public float modZ = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	public void setDirection(Vector3 normalizedDirection){
		angle = -Vector3.Angle (Vector3.up, normalizedDirection);
		if(normalizedDirection.x < 0){
			angle=360-angle;
		}
		transform.localEulerAngles = new Vector3 (modX*angle, modY*angle, modZ*angle);
	}
	public float getDirection(){
		return angle;
	}
}
