using UnityEngine;
using System.Collections;

public class HasPlayer : MonoBehaviour {
	protected PlayerController player;
	// Use this for initialization
	protected virtual void Start () {
		player = gameObject.GetComponent<PlayerController>();
	}
}
