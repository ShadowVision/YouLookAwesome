using UnityEngine;
using System.Collections;

public class DebugController : MonoBehaviour {
	public KeyCode toggleKey = KeyCode.D;
	public KeyCode reloadKey = KeyCode.F5;
	public KeyCode quitKey = KeyCode.Escape;
	public KeyCode nextSceneKey = KeyCode.Period;
	public KeyCode prevtSceneKey = KeyCode.Comma;
	public GameObject[] debugMeshes;
	public bool debugging{
		get{
			return !hidden;
		}
	}
	private bool hidden = true;

	// Use this for initialization
	void Awake () {
		Application.targetFrameRate = 60;
	}
	void Start(){

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(toggleKey)){
			toggleDebug();
		}
		if(Input.GetKeyUp(reloadKey)){
			Libonati.reloadLevel();
		}
		if(Input.GetKeyUp(quitKey)){
			Application.Quit();
		}

		 if(Input.GetKey(nextSceneKey)){
			Libonati.loadNextLevel();
		}else if(Input.GetKey(prevtSceneKey)){
			Libonati.loadPrevLevel();
		}
	}

	private void toggleDebug(){
		if(hidden){
			showDebug();
		}else{
			hideDebug();
		}
	}
	public void showDebug(){
		hidden = false;
		foreach(GameObject obj in debugMeshes){
			Libonati.showAllMesh(obj);
		}
	}
	public void hideDebug(){
		hidden = true;
		foreach(GameObject obj in debugMeshes){
			Libonati.hideAllMesh(obj);
		}
	}
}
