using UnityEngine;
using System.Collections;

public class AliveObject : MonoBehaviour {
	public float maxHealth = 1;
	private float currentHealth = 0;
	public float health{
		get{
			return currentHealth;
		}
	}
	protected void Awake(){
		currentHealth = maxHealth;
	}
	public GameObject OnDamageEffectTemplate;
	public GameObject OnDeathEffectTemplate;
	//return true if dead;
	public bool takeDamage(float damageAmount, Character owner){
		currentHealth -= damageAmount;
		OnDamage ();
		if(currentHealth <= 0){
			currentHealth = 0;
			OnDeath();
			return true;
		}
		return false;
	}
	protected virtual void OnDamage(){
		if(OnDamageEffectTemplate != null){
			Instantiate(OnDamageEffectTemplate, transform.position, transform.rotation);
		}
	}
	protected virtual void OnDeath(){
		if(OnDeathEffectTemplate != null){
			Instantiate(OnDeathEffectTemplate, transform.position, transform.rotation);
		}
		Destroy (gameObject);
	}
}
