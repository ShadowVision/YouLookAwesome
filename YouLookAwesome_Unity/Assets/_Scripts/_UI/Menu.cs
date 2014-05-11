using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Menu : MonoBehaviour {
	public Screen[] initialScreens;

	protected Dictionary<string,Screen> screenDictionary;

	// Use this for initialization
	void Awake () {
		initializeScreens();
	}
	private void initializeScreens(){
		screenDictionary = new Dictionary<string, Screen>();
		foreach(Screen screen in initialScreens){
			addScreen(screen);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void addScreen(Screen screen){
		screenDictionary[screen.name] = screen;
	}
	public void hideAllScreens(){
		foreach(KeyValuePair<string, Screen> entry in screenDictionary){
			entry.Value.hide();
		}
	}
	public void showScreen(string screenName, bool hideOtherScreen = true){
		hideAllScreens();
		screenDictionary[screenName].show();
	}
	public void hideScreen(string screenName){
		screenDictionary[screenName].hide();
	}
}
