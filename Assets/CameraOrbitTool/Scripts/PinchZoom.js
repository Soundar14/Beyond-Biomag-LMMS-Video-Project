/*
Take note that the effect of zooming in and out using this code is using the field of view and not changing the position of the camera itself.
Your camera's projection has to be set to PERSPECTIVE from the unity inspector for the zoom function to work.
*/

#pragma strict

private var minPinchSpeed:float = 6.0F;
private var minDistance:float = 6.0F;
private var touchDelta:float;
private var previousDistance:Vector2;
private var currentDistance:Vector2;
private var speedTouch0:float;
private var speedTouch1:float;
// var obj : GameObject;
// obj.GetComponent(FocusBodyParts).ResetButtonPressed();
//
// change the zooming speed.
// when using mouse, the greater this variable, the lesser you have to scroll to zoom in or out.
// on touch devices, this will affect the sensitivity of pinching action.
// in principle, the larger the device, the greater this variable should be.
var speed:int = 2;
var smooth :float;
// variables to adjust the maximun and minimum camera distance.
// the higher the number means the camera is set farther from the object.
// the lower the number means the camera is set nearer to the object.
var maxOut:int = 60;
var maxIn:int = 60;

//var controlScript : FocusBodyParts;
// variable to show or hide the GUI scrollbar.
var showGUI: boolean = false;
var TargetLookAt :Transform;
var cs:GameObject;

        cs = GameObject.Find("AppEventSystem");
      

function Start () {


}
function Update () {
	cs = GameObject.Find("AppEventSystem");
	var script = cs.GetComponent("FocusBodyParts");
	// this part of the script is for touch enabled devices (mobile phone / tablet).
	if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved && !EventSystems.EventSystem.current.IsPointerOverGameObject()) 
	{

		currentDistance = Input.GetTouch(0).position - Input.GetTouch(1).position;
		previousDistance = ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition));
		touchDelta = currentDistance.magnitude - previousDistance.magnitude;
		speedTouch0 = Input.GetTouch(0).deltaPosition.magnitude / Input.GetTouch(0).deltaTime;
		speedTouch1 = Input.GetTouch(1).deltaPosition.magnitude / Input.GetTouch(1).deltaTime;
		
		if ((touchDelta + minDistance <= 5) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
		{
			this.GetComponent.<Camera>().fieldOfView = Mathf.Clamp(this.GetComponent.<Camera>().fieldOfView + (1 * speed),maxIn,maxOut);
		}

		if ((touchDelta + minDistance > 5) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
		{
			this.GetComponent.<Camera>().fieldOfView = Mathf.Clamp(this.GetComponent.<Camera>().fieldOfView - (1 * speed),maxIn,maxOut);
		}

		if(maxOut >= 60 && transform.parent.parent != TargetLookAt)

			
		{
	//	script.testing();
		Debug.Log("Zoom Limit");
		transform.parent.parent = TargetLookAt;
	//	script.testing();
		}
	}

	
	// this part of the script is for non-touch enabled devices (mac/windows/web).
	// the zoom effect is achieved by using mouse scroll wheel.
	if( Input.GetAxis("Mouse ScrollWheel") < 0) {
		if(maxOut >= 60 && transform.parent.parent != TargetLookAt)

			
		{
//		Debug.Log("Zoom Limit");
//		transform.parent.parent = TargetLookAt;
//		CameraControl.TargetLookAt = target.GetChild (0);
//		CameraControl.limit = -100;
//		CameraControl.distance = -600;
//		CameraControl.TargetRot = Vector3.zero;
//		Camera.main.fieldOfView = fov;
		//transform.parent.localPosition = Vector3.Lerp (transform.parent.localPosition, Vector3.zero, smooth * Time.deltaTime);

		//transform.parent.localRotation = Quaternion.Lerp (transform.parent.localRotation, Quaternion.identity, smooth * Time.deltaTime);
		}
		this.GetComponent.<Camera>().fieldOfView = Mathf.Clamp(this.GetComponent.<Camera>().fieldOfView + (1 * speed),maxIn,maxOut);
		
	} else if( Input.GetAxis("Mouse ScrollWheel") > 0){
		this.GetComponent.<Camera>().fieldOfView = Mathf.Clamp(this.GetComponent.<Camera>().fieldOfView - (1 * speed),maxIn,maxOut);
		
	}
}


