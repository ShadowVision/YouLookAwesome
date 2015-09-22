using UnityEngine;
using System.Collections;

public class Character : AliveObject {
	public Weapon weaponTemplate;
	protected Weapon weapon;

	new protected void Awake () {
		base.Awake ();
		weapon = (Weapon)Instantiate (weaponTemplate, transform.position,Quaternion.identity);
		weapon.owner = (Character)this;
		weapon.transform.parent = transform;
	}
}
