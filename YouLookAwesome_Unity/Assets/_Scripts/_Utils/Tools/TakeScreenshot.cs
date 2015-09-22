using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class TakeScreenshot : MonoBehaviour {
	private bool takeHiResShot = false;
	private const int resWidth = 1280;
	private const int resHeight = 720;
	private const int resDepth = 24;
	private Texture2D screenShot;
	public KeyCode key = KeyCode.None;
	public Camera camera;
	public bool shouldSaveCaptures = true;

	public Texture2D picture {
		get {
			return screenShot;
		}
	}
	
	public static string ScreenShotName(int width, int height) {
		return FolderName + string.Format("screen_{0}x{1}_{2}.png", 
		                     width, height, 
		                     System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
	}
	public static string FolderName{
		get{
			return string.Format("{0}/screenshots/", Application.persistentDataPath);//System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
		}
	}
	public RenderTexture rt;
	public delegate void OnPictureTaken();
	public OnPictureTaken onPictureTaken;

	// Use this for initialization
	void Awake () {
		if (!Directory.Exists (FolderName)) {
			Directory.CreateDirectory(FolderName);
		}
	}
	void LateUpdate() {
		/*takeHiResShot |= Input.GetKeyDown(key);
		if (takeHiResShot) {

		}*/
	}

	public void TakeHiResShot(bool savePicture) {
		shouldSaveCaptures = savePicture;
		takeHiResShot = true;
		StartCoroutine ("HiResShot");
	}

	private IEnumerator HiResShot(){
		try{
			takeHiResShot = false;
			screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGBAFloat, false);
			camera.enabled = true;
			camera.targetTexture = rt;
			camera.Render();
			RenderTexture.active = rt;
		}
		catch(Exception e){
			Debug.LogError("Error saving: " + e.Message);
		}
			
		yield return new WaitForEndOfFrame();

		try{
			screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
			camera.targetTexture = null;
			RenderTexture.active = null; // JC: added to avoid errors
			Destroy(rt);
			byte[] bytes = screenShot.EncodeToPNG();
			string filename = ScreenShotName(resWidth, resHeight);
			
			if(shouldSaveCaptures){
				System.IO.File.WriteAllBytes(filename, bytes);
				Debug.Log(string.Format("Took screenshot to: {0}", filename));
			}
			screenShot.Apply();
			if(onPictureTaken != null){
				onPictureTaken();
			}
		}
		catch(Exception e){
			Debug.LogError("Error saving: " + e.Message);
		}
	}

	public void stopCamera(){
		if (camera.targetTexture != null) {
			//camera.targetTexture.Release ();
			camera.targetTexture = null;
		}
		camera.enabled = false;
	}

}



