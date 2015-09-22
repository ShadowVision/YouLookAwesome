using UnityEngine;
using System.Collections;

public class DummyUpdate : MonoBehaviour {
	public UnityStandardAssets.Utility.FPSCounter fps;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		fps.updateLog (name);
	}
}
