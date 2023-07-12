//Handles the toggle functionality of Gender. Onclick Activate Male/Female.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;




    public class gendertog : MonoBehaviour {
	
	public bool tog,PointTog,activationtog;
	public GameObject female,FemaleScanPointGroup,FemaleCorrespondingPairs;
	public GameObject male,MaleScanPointGroup,MaleCorrespondingPairs;
	public GameObject CurrentScanPoint, CurrentCorrespondingPoints;
	public Button GenderToggle;
	public GameObject maleSidepannel;
	public GameObject femaleSidepannel;
	public FocusBodyParts focusbodyparts;
    public Sprite MaleIcon, FemaleIcon;
	public positionreset resetpos;
	public static gendertog genderToggleObject;
	public ScanPointPlayer Splayer;
	public Material OriginalMAterial;

	// Use this for initialization
	void Start () {
		tog = true;
		genderToggleObject = this;
				PointTog = false;
				CurrentScanPoint = FemaleScanPointGroup;
				CurrentCorrespondingPoints = FemaleCorrespondingPairs;
				SwitchGenderPoints (PointTog);
		        SwitchGenderPointsB(PointTog);
	         	Cpenabling (PointTog);
				CurrentScanPoint = MaleScanPointGroup;
				CurrentCorrespondingPoints = MaleCorrespondingPairs;
				SwitchGenderPoints (PointTog);
		        SwitchGenderPointsB (PointTog);
	           	Cpenabling (PointTog);
	}


	// To manage all the corresponding Points
	
		public void SwitchGenderPoints(bool CurrentState){
				foreach (MeshRenderer Scan in CurrentScanPoint.GetComponentsInChildren<MeshRenderer> ()) {
						Scan.enabled = CurrentState;
			            Debug.Log("Inside Switch Gender Points");
				}
		}

	public void SwitchGenderPointsB(bool CurrentState){
		foreach (BoxCollider Scan in CurrentScanPoint.GetComponentsInChildren<BoxCollider> ()) {
			Scan.enabled = CurrentState;
		}
	}

	//To Toggel Model and their respective Points;
		public void TogglePoints(){
				PointTog = !PointTog;
				SwitchGenderPoints (PointTog);
		        SwitchGenderPointsB (PointTog);
		       
		}

	public void  modeltoggle(){
				// TO disable on Toggle Button
		if (CurrentScanPoint.GetComponentInChildren<MeshRenderer> ().enabled == true) {
			         
						PointTog = false;
						SwitchGenderPoints (false);
			            SwitchGenderPointsB (false);
			           

			           
				}
			
		    focusbodyparts.ResetButtonPressed (focusbodyparts.Body);
				tog = !tog;
				if (tog) {
			            femaleSidepannel.SetActive (false);
						female.SetActive (false);
					    male.SetActive (true);
						GenderToggle.image.sprite = MaleIcon;
						CurrentScanPoint = MaleScanPointGroup;
						CurrentCorrespondingPoints = MaleCorrespondingPairs;
			            maleSidepannel.SetActive(true);
				}
		if (tog == false) {
			femaleSidepannel.SetActive (true);
		    female.SetActive (true);
			male.SetActive (false);
			CurrentScanPoint = FemaleScanPointGroup;
			CurrentCorrespondingPoints = FemaleCorrespondingPairs;
			GenderToggle.image.sprite = FemaleIcon;  
			maleSidepannel.SetActive(false);

		}
		}

	//////////////////////////////////////////////////////for enabling  and disabling cp on clicking the dropdown/////////////////////////	

	public void Cpenabling(bool CurrentState){
		foreach (MeshRenderer Correspond in CurrentCorrespondingPoints.GetComponentsInChildren<MeshRenderer> ()) {
			Correspond.enabled = CurrentState;
		}

	
	}

	public void ToResetspColor(){
		
		if (UniversalClass.CurrentPoint != null) {
			UniversalClass.CurrentPoint.GetComponent<Renderer> ().material = OriginalMAterial;
		}

		if (UniversalClass.CurrentButton != null) {
			UniversalClass.CurrentButton.GetComponent<Image> ().color = Color.white;
		}


	}
	public void cpointEnablingD(){
		
		SwitchGenderPoints (false);
		SwitchGenderPointsB (false);

	}

	//For Enabling Disbaling SP except selected one
	public  void SP_Controller(bool state){

		SwitchGenderPoints (!state);
		SwitchGenderPointsB (!state);


	}

	public void cpointDisablingD(){
		
		Cpenabling (false);
		SwitchGenderPoints (true);
		SwitchGenderPointsB (true);
	}


	public void cpointDisablingReset(){
		Cpenabling (false);

}
	public void ModelPointsChange(){
		
		ToResetspColor ();
		
		StartCoroutine(wait ());
		resetpos.reserposition ();

}

	public void ModelTogOnSignout()
	{//to toggle default model on sign out
		if (tog == false) {
			femaleSidepannel.SetActive (false);
			female.SetActive (false);
			male.SetActive (true);
			GenderToggle.image.sprite = MaleIcon;
			// fixed by Bhuwan
			CurrentScanPoint = MaleScanPointGroup;
			CurrentCorrespondingPoints = MaleCorrespondingPairs;
			maleSidepannel.SetActive(true);
			tog = true;
		}
	}
	IEnumerator wait(){
		yield return new WaitForSeconds (0.3f);

		if (tog == true) {

			MaleScanPointGroup.SetActive (true);
			MaleCorrespondingPairs.SetActive (true);

		
			FemaleScanPointGroup.SetActive (false);
			FemaleCorrespondingPairs.SetActive (false);

		} 

		else {
			MaleScanPointGroup.SetActive (false);
			MaleCorrespondingPairs.SetActive (false);

			FemaleScanPointGroup.SetActive (true);
			FemaleCorrespondingPairs.SetActive (true);
		}
		Splayer.ClearScanPointList();
		Splayer.FindScanPointPivot ();
	}

}
