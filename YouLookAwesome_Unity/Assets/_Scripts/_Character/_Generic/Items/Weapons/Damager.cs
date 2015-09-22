using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Damager : AliveObject {
	public float damageAmount;
	[HideInInspector]
	public Character owner;

	void OnTriggerEnter2D(Collider2D other){
		AliveObject o = other.gameObject.GetComponent<AliveObject> ();
		if(o != null){
			o.takeDamage(damageAmount,owner);
			takeDamage(1,null);
		}
	}
}
