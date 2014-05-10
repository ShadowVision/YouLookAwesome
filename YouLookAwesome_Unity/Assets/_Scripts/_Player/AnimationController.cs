using UnityEngine;
using System.Collections;
using ShadowVision;
public class AnimationController : HasPlayer {
	private SpriteRenderer mainSprite;
	
	public Sprite UpSprite;
	public Sprite UpAngleSprite;
	public Sprite DownSprite;
	public Sprite DownAngleSprite;
	public Sprite SideSprite;

	// Use this for initialization
	override protected void Start () {
		base.Start();
		mainSprite = player.GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setDirection(GameHelpers.Direction dir){
		Sprite newSprite = mainSprite.sprite;
		switch(dir){
		case GameHelpers.Direction.UP :
			newSprite = UpSprite;
			break;
		case GameHelpers.Direction.DOWN : 
			newSprite = DownSprite;
			break;
		case GameHelpers.Direction.LEFT :
		case GameHelpers.Direction.RIGHT :
			newSprite = SideSprite;
			break;
		case GameHelpers.Direction.UP_LEFT :
		case GameHelpers.Direction.UP_RIGHT :
			newSprite = UpAngleSprite;
			break;
		case GameHelpers.Direction.DOWN_LEFT :
		case GameHelpers.Direction.DOWN_RIGHT :
			newSprite = DownAngleSprite;
			break;
		}
		mainSprite.sprite = newSprite;
	}
}
