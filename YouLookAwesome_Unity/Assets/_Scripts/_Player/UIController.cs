using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {
	public Camera inventoryCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void showInventory(){
		inventoryCamera.enabled = true;
	}
	public void hideInventory(){
		inventoryCamera.enabled = false;
	}
}
