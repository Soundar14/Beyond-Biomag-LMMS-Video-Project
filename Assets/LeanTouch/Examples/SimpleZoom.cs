using UnityEngine;

// This script will zoom the main camera based on finger gestures
public class SimpleZoom : MonoBehaviour
{
	public FocusBodyParts focusbodyparts;
	// The minimum field of view value we want to zoom to
	public float MinFov = 10.0f;
	
	// The maximum field of view value we want to zoom to
	public float MaxFov = 100.0f;
	
	protected virtual void LateUpdate()
	{
		// Does the main camera exist?
		if (Camera.main != null && Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved &&  UniversalClass.IsDictionaryEnabled == false && UniversalClass.UIPanelEnabled == false)
		{
			// Make sure the pinch scale is valid
			if (Lean.LeanTouch.PinchScale > 0.0f)
			{
				//Debug.Log ("zooming");
				// Scale the FOV based on the pinch scale
				Camera.main.fieldOfView /= Lean.LeanTouch.PinchScale;
				
				// Make sure the new FOV is within our min/max
				Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, MinFov, MaxFov);
			}

//			if (Camera.main.fieldOfView > 69) {
//				Debug.Log ("zoom out limit reached");
//				focusbodyparts.ResetButtonPressed (focusbodyparts.Body);
//			}
		}
	}
}