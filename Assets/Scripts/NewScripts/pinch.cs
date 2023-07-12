using UnityEngine;
using System.Collections;

public class pinch : MonoBehaviour {
	public 	int maxOut = 60;
	public 	int maxIn = 60;
	public 	float minPinchSpeed = 6.0f;
	public 	float minDistance = 6.0F;
	public 	float touchDelta;
	public 	Vector2 previousDistance;
	public 	Vector2 currentDistance;
	public 	float speedTouch0;
	public 	float speedTouch1;
	public 	int speed = 2;

	// Use this for initialization
	void Start () {

		

				
		
				// change the zooming speed.
				// when using mouse, the greater this variable, the lesser you have to scroll to zoom in or out.
				// on touch devices, this will affect the sensitivity of pinching action.
				// in principle, the larger the device, the greater this variable should be.
			
		
				// variables to adjust the maximun and minimum camera distance.
				// the higher the number means the camera is set farther from the object.
				// the lower the number means the camera is set nearer to the object.
				
		}
		
		// variable to show or hide the GUI scrollbar.

		//var targetScript: ScriptName;
	void Update () {
			
			// this part of the script is for touch enabled devices (mobile phone / tablet).
			if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved) 
			{
				currentDistance = Input.GetTouch(0).position - Input.GetTouch(1).position;
				previousDistance = ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition));
				touchDelta = currentDistance.magnitude - previousDistance.magnitude;
				speedTouch0 = Input.GetTouch(0).deltaPosition.magnitude / Input.GetTouch(0).deltaTime;
				speedTouch1 = Input.GetTouch(1).deltaPosition.magnitude / Input.GetTouch(1).deltaTime;
				
				if ((touchDelta + minDistance <= 5) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
				{
					this.GetComponent<Camera>().fieldOfView = Mathf.Clamp(this.GetComponent<Camera>().fieldOfView + (1 * speed),maxIn,maxOut);
				}
				
				if ((touchDelta + minDistance > 5) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
				{
					this.GetComponent<Camera>().fieldOfView = Mathf.Clamp(this.GetComponent<Camera>().fieldOfView - (1 * speed),maxIn,maxOut);
				}
			}
			
			// this part of the script is for non-touch enabled devices (mac/windows/web).
			// the zoom effect is achieved by using mouse scroll wheel.
			if( Input.GetAxis("Mouse ScrollWheel") < 0) {
				this.GetComponent<Camera>().fieldOfView = Mathf.Clamp(this.GetComponent<Camera>().fieldOfView + (1 * speed),maxIn,maxOut);
				
			} else if( Input.GetAxis("Mouse ScrollWheel") > 0){
				this.GetComponent<Camera>().fieldOfView = Mathf.Clamp(this.GetComponent<Camera>().fieldOfView - (1 * speed),maxIn,maxOut);
				
			}
		}
}
		
		
