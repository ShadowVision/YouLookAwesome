using UnityEngine;
using System.Collections;

public class Screen : MonoBehaviour {
	private SpriteRenderer[] spriteClearList;
	private TextMesh[] textClearList;
	void Awake(){
		spriteClearList = gameObject.GetComponentsInChildren<SpriteRenderer>();
		textClearList = gameObject.GetComponentsInChildren<TextMesh>();
	}
	virtual public void show(){
		foreach(SpriteRenderer s in spriteClearList){
			s.enabled = true;
		}
		foreach(TextMesh t in textClearList){
			t.renderer.enabled = true;
		}
	}
	virtual public void hide(){
		foreach(SpriteRenderer s in spriteClearList){
			s.enabled = false;
		}
		foreach(TextMesh t in textClearList){
			t.renderer.enabled = false;
		}
	}
}
