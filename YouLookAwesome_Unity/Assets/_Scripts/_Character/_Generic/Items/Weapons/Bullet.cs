using UnityEngine;
using System.Collections;

public class Bullet : Damager {
	private Vector3 vel;
	private BulletData data;
	private SpriteRenderer mainSprite;

	// Use this for initialization
	new protected void Awake () {
		base.Awake ();
		mainSprite = gameObject.GetComponentInChildren < SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition += vel * Time.deltaTime;
		transform.position = newPosition;
	}

	public void setData(BulletData newData){
		data = newData;
		owner = newData.owner;
		damageAmount = data.damage;
		transform.localScale = new Vector3 (data.size, data.size, data.size);
		if(mainSprite != null){
			mainSprite.color = data.color;
		}
		vel = data.speed * newData.direction + data.addedSpeed;

		Invoke ("die", data.lifetime);
	}
	protected override void OnDeath ()
	{
		base.OnDeath ();
		die ();
	}
	private void die(){
		Destroy (gameObject);
	}
}
