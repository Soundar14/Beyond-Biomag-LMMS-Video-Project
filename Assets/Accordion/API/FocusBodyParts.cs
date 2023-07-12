//Script is used for the focus feature.On click of body part in body slider camera will focus that part.

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FocusBodyParts : MonoBehaviour {

	public Button HeadButton;
	public Button BodyButton;
	public Button LHandButton;
	public Button RHandButton;
	public Button LLegButton;
	public Button RLegButton;
	public Button ResetButton;


	public positionreset modelpositionscript;
	public Button FHeadButton;
	public Button FBodyButton;
	public Button FLHandButton;
	public Button FRHandButton;
	public Button FLLegButton;
	public Button FRLegButton;


	public float limit = 1.0f;
	public float distance = 100f;

	public Transform Head;
	public Transform Body;
	public Transform LHand;
	public Transform RHand;
	public Transform LLeg;
	public Transform RLeg;
	public int fov = 60;

	public Button GenderTog;
	public GameObject dropdown;
	//public GameObject AccordionDropdownParent;
	public static UniversalClass uniClass;


	public	AccuCamera CameraControl;

	// Use this for initialization
	void Start () 
	{


		HeadButton.onClick.AddListener (()=> { ChangeTarget(Head); });
		BodyButton.onClick.AddListener (()=> { ChangeTarget(Body); });
		LHandButton.onClick.AddListener (()=> { ChangeTarget(LHand); });
		RHandButton.onClick.AddListener (()=> { ChangeTarget(RHand); });
		LLegButton.onClick.AddListener (()=> { ChangeTarget(LLeg); });
		RLegButton.onClick.AddListener (()=> { ChangeTarget(RLeg); });

		ResetButton.onClick.AddListener (()=> { ResetButtonPressed(Body); });
		GenderTog.onClick.AddListener (()=> { ResetButtonPressed(Body); });


		FHeadButton.onClick.AddListener (()=> { ChangeTarget(Head); });
		FBodyButton.onClick.AddListener (()=> { ChangeTarget(Body); });
		FLHandButton.onClick.AddListener (()=> { ChangeTarget(LHand); });
		FRHandButton.onClick.AddListener (()=> { ChangeTarget(RHand); });
		FLLegButton.onClick.AddListener (()=> { ChangeTarget(LLeg); });
		FRLegButton.onClick.AddListener (()=> { ChangeTarget(RLeg); });


		HeadButton.onClick.AddListener (()=> { Headfocus(); });
		FHeadButton.onClick.AddListener (()=> { Headfocus(); });
		//	ResetButtonPressed(Body);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Headfocus(){
		Camera.main.fieldOfView = 40;
		CameraControl.distance = -300;
	}

	public void ChangeTarget(Transform target)
	{
		//		UniversalClass.PreviousButton = UniversalClass.CurrentButton;
		//		UniversalClass.CurrentButton = this.gameObject;
		//
		//		UniversalClass.CurrentButton.GetComponent<Image> ().color = Color.green;
		//		if (UniversalClass.PreviousButton != null) {
		//			UniversalClass.PreviousButton.GetComponent<Image> ().color = Color.white;
		//		}
		//gendertog.
		gendertog.genderToggleObject.cpointDisablingReset();
		//gendertog.genderToggleObject.cpointEnablingD();
		CameraControl.TargetLookAt = target.GetChild(0);
		CameraControl.limit = limit;
		CameraControl.distance = distance;
		CameraControl.TargetRot = Vector3.zero;
		dropdown.SetActive (false);
		//	AccordionDropdownParent.SetActive (false);
	}

	public void ResetButtonPressed(Transform target)
	{
		// if (!CameraControl.gameObject.activeSelf)
		//CameraControl.gameObject.SetActive (true);
		CameraControl.TargetLookAt = target.GetChild (0);
		CameraControl.limit = -100;
		CameraControl.distance = -600;
		CameraControl.TargetRot = Vector3.zero;
		Camera.main.fieldOfView = fov;
		//	AnimatorAssembly.AnimatorController.BottomMenuOFF ();
		//CameraControl.gameObject.transform.localPosition = new Vector3( 0, 0, -600);
		//modelpositionscript.YesButtonPointsReset();

	} 
	public void testing(){
	
		Debug.Log ("testing");
	}
}
