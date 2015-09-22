using UnityEngine;
using System.Collections;

public class Mesh_Fade : MonoBehaviour {
	private Color color = new Color(0,0,0,0);
	private bool updating = false;
	
	public Renderer mesh; 
	private float _targetAlpha = 0;
	
	public float lerpMod = .1f;
	public float targetAlpha{
		set{
			_targetAlpha = value;
			updating = true;
		}
		get{
			return _targetAlpha;
		}
	}
	
	void Start(){
		color = mesh.material.color;
		setTransparency (1);
	}
	void Update(){
		if(updating){
			if(Mathf.Abs(targetAlpha - color.a) > .01f){
				setTransparency(Mathf.Lerp(color.a,targetAlpha, Time.deltaTime * lerpMod));
			}else{
				setTransparency(targetAlpha);
				updating = false;
			}
		}
	}
	
	private void setTransparency(float a){
		color.a = a;
		mesh.material.color = color;
	}
	
}
