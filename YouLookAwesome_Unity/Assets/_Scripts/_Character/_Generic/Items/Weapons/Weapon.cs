using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public Bullet bulletTemplate;
	public BulletData bulletData;
	private Bullet lastBullet;
	private bool canFire = true;
	private Character _owner;
	public Character owner{
		get{
			return _owner;
		}
		set{
			_owner = value;
			bulletData.owner = _owner;
		}
	}
	public void setDir(Vector3 direction, Vector3 velocity){
		bulletData.direction = direction;
		bulletData.addedSpeed = velocity;
	}
	public void fire(){
		if(canFire){
			canFire = false;
			Invoke("resetFire", bulletData.shotCooldown);
			lastBullet = (Bullet)Instantiate (bulletTemplate, transform.position, Quaternion.identity);
			lastBullet.setData (bulletData);
		}
	}
	private void resetFire(){
		CancelInvoke ("resetFire");
		canFire = true;
	}
}
