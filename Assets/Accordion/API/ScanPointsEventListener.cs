using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScanPointsEventListener : MonoBehaviour 
{


	public ScanPoint SPoint;
	public BioMagneticPoint bioMagneticPoint;
	public List<CorrespondingPair> CPoints;
	public GameObject DescriptionPanel;
	public GameObject DescriptionPanelBtn;
	public GameObject ScanPointDesPref;
	public GameObject CorrespondingPairDesPref;
	public GameObject CptitleCode; 
	public GameObject DictionaryPanel;
	public GameObject Description;
	public Text history;
	public int j = 0;
	public Text[] HistoryCount;
	public GameObject HistoryParent;
	public Button ResetButton;
	//public GameObject DictionaryCollider;

	////////////////////////////////////////For dropdown//////////////start///////////////////////////////////////
//	public GameObject AccordionDropdown;
//	public GameObject ScanpointtitleUI;
//	public GameObject Spui;
//	public GameObject Cptitle;
	/////////////////////////////////////////////For dropdown//////////end////////////////////////////////////////
	public Transform IDescriptionPanelChild;






	// Use this for initialization
	void Start () 
	{
		
		//Debug.Log ("ScanPointListnerScripts");
		Description = LoadScanPoints.instance.Description;
		DescriptionPanel = LoadScanPoints.instance.DescriptionPanel;
		DescriptionPanelBtn = LoadScanPoints.instance.DescriptionPanelBtn;
		ScanPointDesPref = LoadScanPoints.instance.ScanPointDesPref;
		CorrespondingPairDesPref = LoadScanPoints.instance.CorrespondingPairDesPref;
		DictionaryPanel = LoadScanPoints.instance.DictionaryPanel;
		history = LoadScanPoints.instance.HistoryText;
		HistoryParent = LoadScanPoints.instance.HistoryParent;
		ResetButton = LoadScanPoints.instance.ResetButton;
		CptitleCode = LoadScanPoints.instance.CptitleCode;
		//DictionaryCollider = LoadScanPoints.instance.DictionaryCollider;
		//////////////////////////////////////dropdown SP///////////start/////////////////////////////////////

//		AccordionDropdown = LoadScanPoints.instance.AccordionDropdown;
//		ScanpointtitleUI = LoadScanPoints.instance.ScanpointtitleUI;
//		Spui = LoadScanPoints.instance.Spui;
//		Cptitle = LoadScanPoints.instance.Cptitle;
		//////////////////////////////////////////For dropdown////////end///////////////////////////////////////////////
		IDescriptionPanelChild = DescriptionPanel.transform.GetChild (0);
		 

		gameObject.GetComponent<Button> ().onClick.AddListener (() => { ScanPointTouchEvent(); });
	}

	


	public void ScanPointTouchEvent()
	{
		string cp = "";
		DescriptionPanel.SetActive (true);
		DescriptionPanelBtn.SetActive (true);
	//	Description.SetActive (true);
	

		PlayerPrefs.SetString ("History",SPoint.Name );

		LoadScanPoints.instance.HistoryDisplay ();



	//	history.text = PlayerPrefs.GetString ("History");

		//////////////////instantiate dropdown//////////////////////start//////////////////////////////////////////

//		GameObject spui = Instantiate (Spui);
//		GameObject scanpointtitleUI = Instantiate (ScanpointtitleUI);
//		
//		scanpointtitleUI.GetComponent<Text> ().text = SPoint.Name;
//		scanpointtitleUI .transform.SetParent(spui.transform,false);
//		spui.transform.SetParent(AccordionDropdown.transform,false);
//		


		//////////////////////////For dropdown///////////////////////end//////////////////////////////////////////		
 
		//instantiate scanpoint description
		GameObject scanPointDesPref = Instantiate(ScanPointDesPref);


		GameObject Scanpointdes =  scanPointDesPref.transform.GetChild(1).gameObject;

		//GameObject.Find (SPoint.Code).GetComponent<ScanPointID> ().ScanPointName = SPoint.Name;

		Scanpointdes.GetComponentInChildren<Text> ().text = SPoint.Name;
		Scanpointdes.transform.GetChild (1).GetComponent<Text> ().text = SPoint.Code;
		Scanpointdes.GetComponentInChildren<Button>().onClick.AddListener (() => {closedictionary() ; });
		Scanpointdes.GetComponentInChildren<Button>().onClick.AddListener (() => {gendertog.genderToggleObject.cpointDisablingReset() ; });
		//Scanpointdes.GetComponentInChildren<Button>().onClick.AddListener (() => {GeneraliseclickFunctionCheck() ; });
		string loc = "Location Undefined";
		if (SPoint.Location != null)
						loc = SPoint.Location;

		GameObject Scanpointloc =  scanPointDesPref.transform.GetChild(3).gameObject;
		Scanpointloc.GetComponentInChildren<Text> ().text = SPoint.Location;
		//assign instance of sp .getchild(0,1).text = spoint.name
		//assign instance of sp .getchild(3,4).text = spoint.location
		scanPointDesPref.transform.SetParent (IDescriptionPanelChild, false);
		//List <CorrespondingPair> cpList = new List<CorrespondingPair> ();
	

		foreach (CorrespondingPair cPoint in CPoints)
		{
				cp += cPoint.Name + ", ";

			//////////////////////////////////////for DPD CP////////////////start////////////////////////////////////////////////
//			GameObject cptitle = Instantiate(Cptitle);
//			cptitle.GetComponent<Text> ().text = cPoint.Name;
//			cptitle.transform.SetParent(spui.transform,false);
			////////////////////////////////////////for DPD CP/////////////////end///////////////////////////////////////////////////////
	

			//	Instantiate cp ui 
			GameObject correspondingPairDesPref = Instantiate(CorrespondingPairDesPref);

			//Corespndng.GetComponent<Text> ().text = cPoint.Name;
			GameObject CorrespName =  correspondingPairDesPref.transform.GetChild(0).gameObject;
			CorrespName.GetComponent<Text> ().text = cPoint.Name;
			CorrespName.GetComponentInChildren<Button>().onClick.AddListener (() => {closedictionary() ;});
			CorrespName.GetComponentInChildren<Button>().onClick.AddListener (() => {gendertog.genderToggleObject.cpointEnablingD() ;});
		//	CorrespName.GetComponentInChildren<Text> ().text = cPoint.Code;
			CorrespName.transform.GetChild (1).GetComponent<Text> ().text = cPoint.Code;
			//CorrespName.GetComponentInChildren<Button>().onClick.AddListener (() => {GameObject.Find (cPoint.Name).GetComponent<CorrespondingPointGameObject> ().OnFocus ();});

			GameObject CorrespLocation =  correspondingPairDesPref.transform.GetChild(2).gameObject;
			CorrespLocation.GetComponent<Text> ().text =cPoint.Location;

			GameObject CorrespDescription =  correspondingPairDesPref.transform.GetChild(4).gameObject;
			CorrespDescription.GetComponent<Text> ().text = cPoint.Description;

			GameObject CorrespGerms =  correspondingPairDesPref.transform.GetChild(6).gameObject;
			CorrespGerms.GetComponent<Text> ().text = cPoint.Germs;

			GameObject CorrespAuther =  correspondingPairDesPref.transform.GetChild(8).gameObject;
			CorrespAuther.GetComponent<Text> ().text = cPoint.AutherName;
			Debug.Log (cPoint.AutherName);

			correspondingPairDesPref.transform.SetParent (IDescriptionPanelChild, false);
			//CptitleCode.transform.SetParent(CorrespName,false);
			//sectionTitleUI.transform.SetParent(sectionUI.transform,false);
			//sectionUI.transform.SetParent(Accordion.transform,false);
		}

//		Debug.Log ("Scan point name : "+ SPoint.Name +" corresponding pair : "+ cp);
		//
	}


	public void closedictionary(){
	//	DictionaryPanel.SetActive (false);  
		//GeneraliseclickFunctionCheck ();
		AnimatorAssembly.AnimatorController.DisableDictionaryAnimation();
		ResetButton.interactable = true;


	}



}
