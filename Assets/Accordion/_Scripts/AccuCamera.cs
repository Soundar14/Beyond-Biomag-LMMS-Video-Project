using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class AccuCamera : MonoBehaviour  {


//	#region IInitializePotentialDragHandler implementation
//
//	public void OnInitializePotentialDrag (PointerEventData eventData)
//	{
//		UniversalClass.UIPanelEnabled = true;
//		Debug.Log (UniversalClass.UIPanelEnabled);
//	}

//	#endregion

	public Transform TargetLookAt;
	public Transform primaryTarget;
	public float distance,rotX,rotY,smooth;
	public bool testbool;
	public GameObject ScanPointDD,Blocker;
	public Vector3 TargetRot;

	public List<Transform> Points,RedPoints;


	public GameObject ActivePart,ActivePoints;

	//public DetailsTab Details;
	public check scriptD,scriptN,scriptL;

	public float limit = 2;

	GameObject tempPivot; 
	// Use this for initialization
	public void Start () {
		testbool = false;
		transform.parent.parent = null;
		TargetRot = Vector3.zero;
		if (ActivePart) {
			ActivePart.GetComponent<Collider> ().enabled = true;
		}

		PanPosition = Vector3.zero;

		ActivePoints = null;
		if(isPointsEnabled)
			OnShowPoints ();
		
		foreach (Transform pt in RedPoints)
			pt.gameObject.SetActive(false);
		    tempPivot = new GameObject ();
	}
	
	// Update is called once per frame
	Vector3 PanPosition;
	Vector2 tempPosition;


	void Update () {
		
//		if (ScanPointDD.activeInHierarchy == true)
//		{
//			Blocker.GetComponent<BoxCollider> ().enabled = true;
//		}

		if (transform.parent.parent != TargetLookAt)
			transform.parent.parent = TargetLookAt;
		transform.parent.localPosition = Vector3.Lerp (transform.parent.localPosition, Vector3.zero, smooth * Time.deltaTime);

		transform.parent.localRotation = Quaternion.Lerp (transform.parent.localRotation, Quaternion.identity, smooth * Time.deltaTime);

		if(Mathf.Abs(transform.localPosition.z-distance)>limit)
			transform.localPosition = Vector3.Lerp (transform.localPosition, new Vector3(0,0 ,distance), smooth  * Time.deltaTime);

		if(PanPosition.x!=0||PanPosition.y!=0)
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, new Vector3(PanPosition.x,PanPosition.y ,transform.localPosition.z), smooth * Time.deltaTime);

		if (Input.touchCount > 1) {
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				TargetRot =TargetLookAt.rotation.eulerAngles;
				tempPosition = MouseHelper.mousePosition;
			}


			if (Mathf.Abs (tempPosition.x - MouseHelper.mousePosition.x) > 5 || Mathf.Abs (tempPosition.y - MouseHelper.mousePosition.y) > 5) {

				PanPosition.x += MouseHelper.mouseDelta.x * Time.deltaTime * 0.007f;
				PanPosition.y -= MouseHelper.mouseDelta.y * Time.deltaTime * 0.007f;
			}

			return;
		}

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			TargetRot =TargetLookAt.rotation.eulerAngles;

		}

		//!EventSystem.current.IsPointerOverGameObject());

		if (Input.GetKey (KeyCode.Mouse0)&&(Mathf.Abs(MouseHelper.mouseDelta.y)>5||Mathf.Abs(MouseHelper.mouseDelta.x)>5)) {

			if (Mathf.Abs (MouseHelper.mouseDelta.y) > Mathf.Abs (MouseHelper.mouseDelta.x) &&  UniversalClass.IsDictionaryEnabled == false && UniversalClass.UIPanelEnabled == false) {
				TargetRot.x += MouseHelper.mouseDelta.y * Time.deltaTime * -5; //3
			} else
				if(UniversalClass.IsDictionaryEnabled == false && UniversalClass.UIPanelEnabled == false)
				TargetRot.y+= Time.deltaTime* MouseHelper.mouseDelta.x * 12; //8
			
		}
			
		TargetRot.x = ClampAngle(TargetRot.x, -60, 60);


		TargetLookAt.rotation = Quaternion.Lerp(TargetLookAt.rotation, Quaternion.Euler(TargetRot.x, TargetRot.y, TargetRot.z), Time.deltaTime*5);
	}


	float ClampAngle (float angle, float min, float max) {
		if (angle > 180)
			angle -= 360; 


		return Mathf.Clamp (angle, min, max);
	}



	float ClampAngle2 (float angle, float min, float max) {



				if (angle < 360)
					angle += 360;
				if (angle > 360)
					angle -= 360;
		return Mathf.Clamp (angle, min, max);
	} 



	public void GetFocusTargetPoint(Transform target)
	{	
		PanPosition = Vector3.zero;
		distance = 60f;
		TargetLookAt = target;
		TargetRot = TargetLookAt.rotation.eulerAngles;
	}

	public bool isPointsEnabled;
	public void OnShowPoints()
	{
		if (ActivePoints) {
			foreach (Transform pt in ActivePoints.GetComponent<PointsGroup>().SubPressurePoints)
				pt.gameObject.SetActive (true);
		} 
		else {
			foreach (Transform pt in Points)
				pt.gameObject.SetActive (true);
		}

		isPointsEnabled = true;
		
	}
	

	public void GetCameraOut(){

		tempPivot.transform.position = transform.parent.position;
		tempPivot.transform.rotation = transform.parent.rotation;

		TargetLookAt = tempPivot.transform;
		transform.parent.parent = TargetLookAt;
	}


}
