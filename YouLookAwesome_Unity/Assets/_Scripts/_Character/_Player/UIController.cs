using UnityEngine;
using System.Collections;

public class UIController : HasPlayer {
	public Camera inventoryCamera;
	public Menu pauseMenuTempalte;
	public DirectionalObject directionalArrow;

	private Menu pauseMenu;

	// Use this for initialization
	new void Start () {
		base.Start ();
		pauseMenu = (Menu)Instantiate(pauseMenuTempalte);
		pauseMenu.transform.parent = transform;
		pauseMenu.transform.localPosition = Vector3.zero;

		pauseMenu.hideAllScreens();
	}
	
	// Update is called once per frame
	void Update () {
		directionalArrow.setDirection (player.input.normalizedDirection);
	}
	public void showInventory(){
		inventoryCamera.enabled = true;
		pauseMenu.showScreen("InventoryScreen");
	}
	public void hideInventory(){
		inventoryCamera.enabled = false;
		pauseMenu.hideScreen("InventoryScreen");
	}
}
