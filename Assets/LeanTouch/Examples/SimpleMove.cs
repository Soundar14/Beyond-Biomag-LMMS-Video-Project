using UnityEngine;

// This script will move the GameObject based on finger gestures
public class SimpleMove : MonoBehaviour
{


	protected virtual void LateUpdate()
	{
		//This will move the current transform based on a finger drag gesture
		if( Input.touchCount == 3 && Input.GetTouch(0).phase == TouchPhase.Moved && UniversalClass.IsDictionaryEnabled == false && UniversalClass.UIPanelEnabled == false)

			Lean.LeanTouch.MoveObject(transform, Lean.LeanTouch.DragDelta);
		

	}
}
