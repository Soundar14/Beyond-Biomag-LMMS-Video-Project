using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Search : MonoBehaviour {

	public bool testing;
	public InputField searcht;



//	    public GameObject DictionaryPanel;
//	    public ScanPoint SPoint;
//	    public List<ScanPoint> Spoint;
//		public List<CorrespondingPair> CPoints;
//		public GameObject DescriptionPanel;
//		public GameObject DescriptionPanelBtn;
//		public GameObject ScanPointDesPref;
//		public GameObject CorrespondingPairDesPref;
//
//
//		public Transform IDescriptionPanelChild;
//





		// Use this for initialization
		void Start () 
		{
		//////////////////to Instantiate description panel accordin to the data entered in the search//////////////////////////////////	
//			DescriptionPanel = LoadScanPoints.instance.DescriptionPanel;
//			DescriptionPanelBtn = LoadScanPoints.instance.DescriptionPanelBtn;
//			ScanPointDesPref = LoadScanPoints.instance.ScanPointDesPref;
//			CorrespondingPairDesPref = LoadScanPoints.instance.CorrespondingPairDesPref;
//		    searcht = LoadScanPoints.instance.searcht;
//

		}





			
	//////////////////to Instantiate description panel accordin to the data entered in the search//////////////////////////////////				
//	public void Dsearch(){
//		string cp = "";
//		LoadScanPoints.instance.Section_Scanpoint_Dict.TryGetValue (searcht.text, out Spoint);
//		if (LoadScanPoints.instance.Scanpoint_cPair_Dict.ContainsKey (searcht.text) || LoadScanPoints.instance.Section_Scanpoint_Dict.ContainsKey (searcht.text)) {
//			testing = true;
//			//ScanPointTouchEvent ();
//
//			DescriptionPanel.SetActive (true);
//			DescriptionPanelBtn.SetActive (true);
//			IDescriptionPanelChild = DescriptionPanel.transform.GetChild (0);
//
//				GameObject scanPointDesPref = Instantiate(ScanPointDesPref);
//
//
//				GameObject Scanpointdes =  scanPointDesPref.transform.GetChild(1).gameObject;
//			Scanpointdes.GetComponentInChildren<Text> ().text = searcht.text;
//			Scanpointdes.GetComponentInChildren<Button>().onClick.AddListener (() => {closedictionary() ; });
//				//string loc = "Location Undefined";
//				//if (SPoint.Location != null)
//					//loc = SPoint.Location;
//
//			//GameObject Scanpointloc =  scanPointDesPref.transform.GetChild(3).gameObject;
//				//Scanpointloc.GetComponentInChildren<Text> ().text = loc;
//				
//				scanPointDesPref.transform.SetParent (IDescriptionPanelChild, false);
//				//List <CorrespondingPair> cpList = new List<CorrespondingPair> ();
//				LoadScanPoints.instance.Scanpoint_cPair_Dict.TryGetValue (searcht.text, out CPoints);
//				foreach (CorrespondingPair cPoint in CPoints)
//				{
//					cp += cPoint.Name + ", ";
//
//
//
//					//	Instantiate cp ui 
//					GameObject correspondingPairDesPref = Instantiate(CorrespondingPairDesPref);
//
//					
//					GameObject CorrespName =  correspondingPairDesPref.transform.GetChild(0).gameObject;
//					CorrespName.GetComponent<Text> ().text = cPoint.Name;
//				    CorrespName.GetComponentInChildren<Button>().onClick.AddListener (() => {closedictionary() ; });
//
//
//					GameObject CorrespLocation =  correspondingPairDesPref.transform.GetChild(2).gameObject;
//					CorrespLocation.GetComponent<Text> ().text = cPoint.Location;
//
//					GameObject CorrespDescription =  correspondingPairDesPref.transform.GetChild(4).gameObject;
//					CorrespDescription.GetComponent<Text> ().text = cPoint.Description;
//
//					GameObject CorrespGerms =  correspondingPairDesPref.transform.GetChild(6).gameObject;
//					CorrespGerms.GetComponent<Text> ().text = cPoint.GermUserFriendlyCode;
//
//
//					correspondingPairDesPref.transform.SetParent (IDescriptionPanelChild, false);
//
//				}
//
//				//Debug.Log ("Scan point name : "+ SPoint.Name +" corresponding pair : "+ cp);
//				//
//			}
//		//////////////////to Instantiate description panel accordin to the data entered in the search//////////////////////////////////	
//		else
//			testing = false;
//	}
//
//	public void closedictionary(){
//		DictionaryPanel.SetActive (false);      
//	}




	

	



}