// Shows the tutorials video on Play
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScanPointPlayer : MonoBehaviour {

	public AccuCamera PointManager;
	public GameObject ScanpointDropdown,ScanButtonPrefab,Content,rollingMenu,ScanpointDropdownG,ScanguideplayerRestriction,TempGameObject;
	public List<GameObject> ScanPointsObjects,ScanPointsObjectsUnSort;
	public int ButtonIndex,j,i,f;
	public bool PlayScan,PauseStatus;
	public FocusBodyParts focusbodyparts;
	public gendertog ToDisableSp;
	public Sprite PlayIcon, StopIcon;
	public Button ScanGuideButton;
	public  gendertog genderbool;
	public Sprite Play,Pause;
	public GameObject PlayPauseButton;
	public UI_Manager uimanager;
	public positionreset PositionReset;

	//  public GameObject ScanguideCollider;

	// Use this for initialization

	void Start () {

		ScanguideplayerRestriction.SetActive (false);
		PlayScan = false;
		PauseStatus = false;
		ScanButtonPrefab = Resources.Load ("Prefabs/ScanButton") as GameObject;
		PointManager = GameObject.Find ("Main Camera").GetComponent<AccuCamera> ();
		ScanpointDropdown = EventManager.instance.ScanpointDropdown;	
		ToDisableSp = LoadScanPoints.instance.point;


		//FindScanPointPivot ();   // Call this function on login button
	}


	public void ClearScanPointList(){
		ScanPointsObjects.Clear ();
		//ScanPointsObjectsUnSort.Clear ();
		ButtonIndex =j=i=f= 0;

	}



	// Making the list of the of Pivot
	public void FindScanPointPivot(){

		if (genderbool.tog == true) {
			foreach (GameObject spPoint in GameObject.FindGameObjectsWithTag("ScanPointsMale")) {
				if (spPoint.GetComponent<MeshRenderer> () != null) {
					ScanPointsObjects.Add (spPoint);
					ButtonIndex++;
				}
			}
		}

		if (genderbool.tog == false) {
			foreach (GameObject spPoint in GameObject.FindGameObjectsWithTag("ScanPointsFemale")) {
				if (spPoint.GetComponent<MeshRenderer> () != null) {
					ScanPointsObjects.Add (spPoint);
					ButtonIndex++;
				}
			}
		}
	}



	public void ResetThePlayPosition(){
		//FindScanPointPivot ();
		PositionReset.reserposition();
		ClearScanPointList();
		FindScanPointPivot ();
		PlayScan = !PlayScan;
		j = 0;
	}





	// To be called after given seconds
	public void PlayScanPlayer()
	{
		if (j <= ScanPointsObjects.Count) {
						j++;
					} 
	//	j++;

		if(j >= ScanPointsObjects.Count){
			uimanager.EnableDictionary ();
			PlayScan = false;
			Debug.Log ("Over");
			//StopAllCoroutines ();
			CancelInvoke();
			focusbodyparts.ResetButtonPressed (focusbodyparts.Body);
			ToDisableSp.cpointEnablingD();
			ScanguideplayerRestriction.SetActive(false);
			ScanGuideButton.image.sprite = PlayIcon;
		 //   j = 0;
			ScanpointDropdownG.SetActive (false);
			ScanpointDropdown.SetActive (false);
		}

		//yield return new WaitForSeconds (t);
		TempGameObject.GetComponent<MeshRenderer> ().enabled = false;
		FocusPointplayer2 ();
	}


	// Called once need to be focus on ScanPoints
	public void FocusScanPoints(GameObject Pivot){
		{


			PointManager.limit = 150;
			PointManager.distance = 90;
			PointManager.GetFocusTargetPoint(Pivot.transform);
			//ScanpointDropdown.SetActive (true);
			//ScanpointDropdownG.SetActive (true);
			//			GameObject dropdown = ScanpointDropdownG.transform.GetChild (0).gameObject;
			//			dropdown.transform.GetChild (0).gameObject.GetComponent<Text> ().text = Pivot.name;

			//			GameObject dropdown2 = ScanpointDropdown.transform.GetChild (0).gameObject;
			//			dropdown2.transform.GetChild (0).gameObject.GetComponent<Text> ().text = Pivot.name;
		}
	}


	public void FocusPointplayer2(){
		//		for (int i = 1; i < ScanpointDropdown.transform.childCount; i++) {
		//
		//			Destroy (ScanpointDropdown.transform.GetChild (i).gameObject);
		//		}
		if (PlayScan == true) {
			
			ToDisableSp.cpointEnablingD();  // to diable all the SP before play

			ScanguideplayerRestriction.SetActive(true);
			ScanpointDropdownG.SetActive (true);
			ScanGuideButton.image.sprite = StopIcon;

			foreach (GameObject playObject in ScanPointsObjects) {
				if (playObject.GetComponent<ScanPointID> ().ScnPointID == j) {
					playObject.GetComponent<OnMouseClickClass> ().CallForFocus ();
					playObject.GetComponent<MeshRenderer> ().enabled = true;
					TempGameObject = playObject;
					break;
				}
			}


		/*	for ( i= j; i < ScanPointsObjects.Count; i++) {

			//	Debug.Log (ScanPointsObjects [i].name + " " + ScanPointsObjects [i].GetComponent<ScanPointID> ().ScnPointID);
				if (ScanPointsObjects [i].GetComponent<ScanPointID> ().ScnPointID == j) {
					ScanPointsObjects [i].GetComponent<OnMouseClickClass> ().CallForFocus ();
					ScanPointsObjects [i].GetComponent<MeshRenderer> ().enabled = true;
					break;
				} 
			} */

			Invoke ("PlayScanPlayer", 3f); 
		//	StartCoroutine (PlayScanPlayer (1));
		}
		else if (PlayScan == false) {
			// ScanguideCollider.SetActive (false);
			ScanguideplayerRestriction.SetActive(false);
			ScanGuideButton.image.sprite = PlayIcon;

			CancelInvoke();
			j = 0;
			ScanpointDropdownG.SetActive (false);
			ScanpointDropdown.SetActive (false);
//			rollingMenu.SetActive (false);
			focusbodyparts.ResetButtonPressed (focusbodyparts.Body);
			ToDisableSp.cpointEnablingD();
			Time.timeScale = 1;
			PlayPauseButton.GetComponent<Image> ().sprite = Pause;
		}
	}


	public void GuidePausePlay(){
		PauseStatus = !PauseStatus;
		if (PauseStatus) {
			PlayPauseButton.GetComponent<Image> ().sprite = Play;
			Time.timeScale = 0;

		}
		if (!PauseStatus) {
			
			PlayPauseButton.GetComponent<Image> ().sprite = Pause;
			Time.timeScale = 1;
		}
	}
}

