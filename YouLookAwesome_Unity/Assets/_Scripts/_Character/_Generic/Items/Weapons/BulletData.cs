using UnityEngine;
using System.Collections;

[System.Serializable]
public class BulletData{
	public float damage = 1;
	public float size = .1f;
	public float speed = 1;
	[HideInInspector]
	public Vector3 addedSpeed = Vector3.zero;
	public float shotCooldown = 1;
	public float lifetime = 4f;
	public Color color = Color.white;

	[HideInInspector]
	public Character owner; 
	[HideInInspector]
	public Vector3 direction;
}
