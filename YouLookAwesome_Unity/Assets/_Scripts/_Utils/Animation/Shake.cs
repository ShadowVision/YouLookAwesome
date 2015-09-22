using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour
{
	public Transform targetTransform;
	
	// How long the object should shake for.
	public float duration = 0f;
	public float decreaseFactor = 1.0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float rateInSeconds = 1;
	public float lerpMod = 1;
	
	
	private Vector3 targetPos;
	private Vector3 originalPos;
	private bool positionUpdated = false;
	
	void Awake()
	{
		if (targetTransform == null)
		{
			targetTransform = transform;
		}
	}
	
	void OnEnable()
	{
		originalPos = targetTransform.localPosition;
		InvokeRepeating ("updatePos",rateInSeconds, rateInSeconds);
	}
	void OnDisable(){
		CancelInvoke ("updatePos");
		positionUpdated = false;
		targetTransform.localPosition = originalPos;
	}
	
	private void updatePos(){
		targetPos = originalPos + Random.insideUnitSphere * shakeAmount;
		positionUpdated = true;
	}
	void FixedUpdate()
	{
		if (positionUpdated) {
			if (duration != 0) {
				targetTransform.localPosition = Vector3.Lerp (targetTransform.localPosition, targetPos, Time.fixedDeltaTime * lerpMod);

				if (duration > 0) {
					duration -= Time.fixedDeltaTime * decreaseFactor;
					if (duration < 0) {
						duration = 0f;
					}
				}
			} else {
				targetTransform.localPosition = originalPos;
			}
		}	
	}
}