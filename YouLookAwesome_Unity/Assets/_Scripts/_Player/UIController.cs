using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {
	public Camera inventoryCamera;
	public Menu pauseMenuTempalte;
	private Menu pauseMenu;

	// Use this for initialization
	void Start () {
		pauseMenu = (Menu)Instantiate(pauseMenuTempalte);
		pauseMenu.transform.parent = transform;
		pauseMenu.transform.localPosition = Vector3.zero;

		pauseMenu.hideAllScreens();
	}
	
	// Update is called once per frame
	void Update () {
	
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
