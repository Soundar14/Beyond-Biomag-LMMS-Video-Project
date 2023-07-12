	    using UnityEngine;
		using System.Collections;
		using UnityEngine.UI;
		using System.Collections.Generic;
	    using UnityEngine.EventSystems;

public class OnMouseClickClass : MonoBehaviour , IPointerClickHandler {


            	public GameObject Blocker;
	            public GameObject DropDownForScanguide;
	            public ScanPoint SPoint;
				public GameObject Pivot;
				public ScanPointPlayer ScanPlayer;
				public PivotDirection pd;
			 //   public ScanPoint SPoint;
             	public BioMagneticPoint bioMagneticPoint;
            	public GameObject CurrentSelected;
	            public GameObject PreviousSelected;
			    public List<CorrespondingPair> CPoints;
	            public ScanPoint SPoints;
			    public GameObject AccordionDropdown;
	            public GameObject AccordionDropdownParent;
			    public GameObject ScanpointtitleUI;
			    public GameObject Spui;
			    public GameObject Cptitle;
	           public GameObject CptitleCode;
	           public GameObject CptitlePanelButton;
		        public Material points;
               	public GameObject DescriptionPanelButton;
				public GameObject DictionaryPanel;
	           // public GameObject DictionaryCollider;
				public GameObject DescriptionPanel;
	            public GameObject DescriptionPanelChild;
				public GameObject DescriptionPanelBtn;
				public GameObject ScanPointDesPref;
				public GameObject CorrespondingPairDesPref;
	            //public List<ScanPoint> Spoint;
	            Button[] dropDownButton;
	            public Transform IDescriptionPanelChild;
	            public static UniversalClass uniClass;
	            public	gendertog point;
	            public bool over;
	            public Material blue,Original,RedOriginal;
	            public GraphicRaycaster GR;
				public enum PivotDirection
				{
						front, back, left, right, top, bottom
				}
	            public static OnMouseClickClass intstan;

			// Use this for initialization
			void Start () {
		                intstan = this;

		            Blocker = LoadScanPoints.instance.Blocker; 
///////////////////////////////////	For dropdown of CP////////////////start///////////////////////////////////////////////////////////
		            DescriptionPanelButton	= LoadScanPoints.instance.DescriptionPanelBtn;
		            AccordionDropdown = LoadScanPoints.instance.AccordionDropdown;
		     //       AccordionDropdownParent = LoadScanPoints.instance.AccordionDropdownParent;
					ScanpointtitleUI = LoadScanPoints.instance.ScanpointtitleUI;
					Spui = LoadScanPoints.instance.Spui;
					Cptitle = LoadScanPoints.instance.Cptitle;
		            CptitleCode = LoadScanPoints.instance.CptitleCode;
		DropDownForScanguide = LoadScanPoints.instance.DropDownForScanguide;
	      //      	CptitlePanelButton = LoadScanPoints.instance.CptitlePanelButton;
//////////////////////////////////////////For dropdown of CP//////////////////////////////////////////////////////////////////////////			   
		  

		        	point = LoadScanPoints.instance.point;


//////////////////////////////////////////For INFO PANNEL DICTIONARY///////////////////////////////////////////////////////// ////////
				
		            DescriptionPanel = LoadScanPoints.instance.DescriptionPanel;        
		            DescriptionPanelChild = LoadScanPoints.instance.DescriptionPanelChild;
		 
					DescriptionPanelBtn = LoadScanPoints.instance.DescriptionPanelBtn;
					ScanPointDesPref = LoadScanPoints.instance.ScanPointDesPref;
					CorrespondingPairDesPref = LoadScanPoints.instance.CorrespondingPairDesPref;
		            DictionaryPanel = LoadScanPoints.instance.DictionaryPanel;
		          //  DictionaryCollider = LoadScanPoints.instance.DictionaryCollider;
//////////////////////////////////////////For INFO PANNEL DICTIONARYy//////////////////////////////////////////////////////////////////

//To change the material of the objects
		blue = LoadScanPoints.instance.Blue;
		Original = LoadScanPoints.instance.Original;
		RedOriginal = LoadScanPoints.instance.RedOriginal;
////////////////////////////////////////////////////////

		ScanPlayer = GameObject.Find ("ScanPlayer").GetComponent<ScanPointPlayer> ();

						CreatePivot ();


				

			}

///////////////////////////////////	TO HIGHLIGHT COLOR OF SP ON CLICKING////////////////start///////////////////////////////////////////
		

		IEnumerator wait(){
			yield return new WaitForSeconds (2);
			//Debug.Log ("colour");
			//GetComponent<Renderer> ().material.color = Color.white;
		}

	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData)
	{
		{	
			Camera.main.fieldOfView = 60;
			Blocker.SetActive(true);
			Blocker.GetComponent<BoxCollider> ().enabled = true;
			//GetComponent<Renderer> ().material.color = Color.green;

			CurrentSelected = this.gameObject;
			PreviousSelected = CurrentSelected;

			//ObjectChange ();
			//		if (Input.GetMouseButtonDown(0))
			//		{


			//if (!EventSystem.current.IsPointerOverGameObject()) 


			//if (Input.touchCount > 0) {
			//			
			//

			///////////////////////////////////////////////////TO DESTROY DROP DOWN BEFORE INSTANTIATING//////////////////////////////////////////////////////////////////////////
			for (int i = 0; i < AccordionDropdown.transform.childCount; i++) {

				Destroy (AccordionDropdown.transform.GetChild (i).gameObject);
			}
			////////////////////////////////////////////////TO DESTROY DROP DOWN BEFORE INSTANTIATING///////////////////////////////////////////////////////////////////////
			AccordionDropdown.SetActive (true);
			//			AccordionDropdownParent.SetActive (true);




			GameObject spui = Instantiate (Spui);
			GameObject scanpointtitleUI = Instantiate (ScanpointtitleUI);

			spui.GetComponentsInChildren<UIAccordionElement> ();

			//GameObject Scanpointui =  scanpointtitleUI.transform.GetChild(1).gameObject;
			//spui.GetComponentsInChildren<UIAccordionElement>().
			scanpointtitleUI.GetComponentInChildren<Text> ().text = gameObject.GetComponent<ScanPointID> ().ScanPointName;

			dropDownButton = scanpointtitleUI.GetComponentsInChildren<Button> ();

			dropDownButton [1].gameObject.SetActive (false);   //TO DISABLE FOCUS ICON IN THE DROPDOWN

			dropDownButton [0].onClick.AddListener (() => {
				Infopannel ();
			});//on click to OPen dictionary info

			dropDownButton [1].onClick.AddListener (() => {
				CallForFocus ();                                  //FOCUS ICON IN THE DROPDOWN
			});

			dropDownButton [1].onClick.AddListener (() => {
				FocusIconOff ();                                     //TO DISABLE FOCUS ICON IN THE DROPDOWN
			});
			//to focus on the scanpoint selected
			//				dropDownButton [1].onClick.AddListener (() => {
			//				ObjectChange();
			//				});//TO DISABLE CORRESPONDING PAIRS IN THE DROPDOWN

			scanpointtitleUI.transform.SetParent (spui.transform, false);
			spui.transform.SetParent (AccordionDropdown.transform, false);

			///////////////////////////for INSTANTIATING CP DROP DOWN WITH RESPECT TO SCAN POINT SELECTED///////////////START////////////////////////

			if (LoadScanPoints.instance.Scanpoint_cPair_Dict.ContainsKey (gameObject.name)) {

				List <CorrespondingPair> cpList = new List<CorrespondingPair> ();
				LoadScanPoints.instance.Scanpoint_cPair_Dict.TryGetValue (gameObject.name, out cpList);
				foreach (CorrespondingPair cPoint in cpList) {
					//cp += cPoint.Name + ", ";

					GameObject cptitle = Instantiate (Cptitle);
					cptitle.GetComponent<Text> ().text = cPoint.Name;

					cptitle.transform.GetChild (0).gameObject.GetComponent<Button> ().onClick.AddListener (() => {
						FocusIconOn ();
					});                 //ON CLICKING CP AND 


					//					GameObject cppanel = Instantiate (CptitlePanelButton);
					//					cppanel.transform.SetParent (cptitle.transform, false);
					GameObject cptitlecode = Instantiate (CptitleCode);

					cptitlecode.GetComponent<Text> ().text = cPoint.Code;

					//cptitle.GetComponentInChildren<Text> ().text = cPoint.Code;


					//						cptitle.GetComponentInChildren<Button> ().onClick.AddListener (() => {
					//							point.cpointEnablingD ();
					//						});//TO ENABLE CORRESPONDING PAIRS IN THE DROP DOWN ON CLICKING THE CP

					cptitle.transform.SetParent (spui.transform, false);
					cptitlecode.transform.SetParent (cptitle.transform, false);

				}
			}		
			///////////////////////////for INSTANTIATING CP DROP DOWN WITH RESPECT TO SCAN POINT SELECTED////////////////END///////////////////////

			CallForFocus ();



		}
	}
	#endregion


	///////////////////////////////////	TO HIGHLIGHT COLOR OF SP ON CLICKING//////////////end/////////////////////////////////////////////
			



		



	

	public void FocusIconOn()
						{
		dropDownButton [1].gameObject.SetActive (true);
	}

	public void FocusIconOff()
	{
		Blocker.GetComponent<BoxCollider> ().enabled = true;
		dropDownButton [1].gameObject.SetActive (false);
	}
		


		public void ChangeTarget()
		{
			AccordionDropdown = LoadScanPoints.instance.CorrespondingPoints [Random.Range (0, LoadScanPoints.instance.CorrespondingPoints.Length - 1)];
			AccordionDropdown.GetComponent<CorrespondingPointGameObject>().OnFocus();
		}

	//	public  void ObjectChange(){
	//
	//           cpointEnablingD ();
	//		  UniversalClass.CurrentPoint.GetComponentInChildren<MeshRenderer> ().enabled = true;
	//
	//		//	intstan.PreviousSelected.GetComponent<Renderer> ().material.color = Color.white;
	//		//	intstan.PreviousSelected = intstan.CurrentSelected;
	//	}
			
			

				


				public void CallForFocus()
	{
		//FocusIconOff ();
		
		if (UniversalClass.CurrentPointCP != null) {
			UniversalClass.CurrentPointCP.GetComponent<Renderer> ().material = RedOriginal;
		}
	//	GetComponent<Renderer> ().material = blue;
		GameObject dropdown = DropDownForScanguide.transform.GetChild (0).gameObject;
	//	dropdown.transform.GetChild (0).gameObject.GetComponent<Text> ().text = Pivot.name;
		dropdown.transform.GetChild (0).gameObject.GetComponent<Text> ().text  = gameObject.GetComponent<ScanPointID>().ScanPointName;
	//	AccordionDropdown.	transform.GetChild (0).gameObject.GetComponent<Text> ().text = gameObject.GetComponent<ScanPointID>().ScanPointName;
		UniversalClass.PreviousPoint = UniversalClass.CurrentPoint;
		UniversalClass.CurrentPoint = this.gameObject;

		GetComponent<Renderer> ().material = blue;

		//UniversalClass.CurrentPoint.GetComponent<Renderer> ().material.color = Color.green;
		UniversalClass.CurrentPoint.GetComponent<Renderer> ().material = blue;

		if (UniversalClass.PreviousPoint != null) {
			UniversalClass.PreviousPoint.GetComponent<Renderer> ().material = Original;
		}
		GetComponent<Renderer> ().material = blue;
		//GetComponent<Renderer> ().material.color = Color.green;
            //	GetComponent<Renderer> ().material.color = Color.green;//to high light color of sp
		    //        StartCoroutine(wait ());//to high light color of Sp (Green)

						switch (pd)
						{
						case PivotDirection.front:
								Pivot.transform.rotation =  Quaternion.identity;
								break;
						case PivotDirection.left:
								Pivot.transform.rotation = Quaternion.Euler(0,90,0);
								break;
						case PivotDirection.back:
								Pivot.transform.rotation = Quaternion.Euler(0,180,0);
								break;
		                case PivotDirection.top:
		                    	Pivot.transform.rotation = Quaternion.Euler(60,0,0);
	                    		break;
						case PivotDirection.right: 
								Pivot.transform.rotation = Quaternion.Euler(0,270,0);
								break;
		                case  PivotDirection.bottom:
			                    Pivot.transform.rotation = Quaternion.Euler(-60,180,0);
			                    break;
						default:
								break;
						}
						ScanPlayer.FocusScanPoints (Pivot);
				}


				void CreatePivot()
				{
						Pivot = new GameObject ();
						Pivot.name = " "+gameObject.name;  // Space is must to focus from dictionary
						Pivot.tag = "ScamPointPivot";
						Pivot.transform.parent = transform;
						Pivot.transform.rotation = Quaternion.identity;
						Pivot.transform.localPosition = Vector3.zero;
						Pivot.transform.localScale = Vector3.one * 0.0553507f;

					//	ScanPlayer.FindScanPointPivot (gameObject);
				}


///////////////////////////////////////////////////////////INFO BUTTON TO OPEN INFO PANNEL IN DICTIONARY////////////////////////////////////////

	public void Infopannel(){
		
		for (int i = 0; i < DescriptionPanelChild.transform.childCount; i++) {

			Destroy (DescriptionPanelChild.transform.GetChild (i).gameObject);
		}
		UniversalClass.IsDictionaryEnabled = true;

		AnimatorAssembly.AnimatorController.EnableDictionary(); 
		string cp = "";
		DescriptionPanel.SetActive (true);
		DescriptionPanelButton.SetActive (true);

	//	LoadScanPoints.instance.Section_Scanpoint_Dict.TryGetValue (gameObject.name, out Spoint);
		if (LoadScanPoints.instance.Scanpoint_cPair_Dict.ContainsKey (gameObject.name)) {


			DescriptionPanel.SetActive (true);
			DescriptionPanelBtn.SetActive (false);
			IDescriptionPanelChild = DescriptionPanel.transform.GetChild (0);

			GameObject scanPointDesPref = Instantiate(ScanPointDesPref);


			GameObject Scanpointdes =  scanPointDesPref.transform.GetChild(1).gameObject;
			Scanpointdes.GetComponentInChildren<Text> ().text = gameObject.GetComponent<ScanPointID>().ScanPointName;
		//	Scanpointdes.GetComponentInChildren<Button>().onClick.AddListener (() => {closedictionary() ; });

//			string loc = "Location Undefined";
//			if (SPoint.Location != null)
//			loc = SPoint.Location;
//
			GameObject Scanpointloc =  scanPointDesPref.transform.GetChild(3).gameObject;
			Scanpointloc.GetComponentInChildren<Text> ().text = gameObject.GetComponent<ScanPointID>().ScanpointLocation;

			scanPointDesPref.transform.SetParent (IDescriptionPanelChild, false);
			//List <CorrespondingPair> cpList = new List<CorrespondingPair> ();
			LoadScanPoints.instance.Scanpoint_cPair_Dict.TryGetValue( gameObject.name, out CPoints);
			foreach (CorrespondingPair cPoint in CPoints)
			{
				cp += cPoint.Name + ", ";



				//	Instantiate cp ui 
				GameObject correspondingPairDesPref = Instantiate(CorrespondingPairDesPref);


				GameObject CorrespName =  correspondingPairDesPref.transform.GetChild(0).gameObject;
				CorrespName.GetComponent<Text> ().text = cPoint.Name;



				GameObject CorrespLocation =  correspondingPairDesPref.transform.GetChild(2).gameObject;
				CorrespLocation.GetComponent<Text> ().text = cPoint.Location;

				GameObject CorrespDescription =  correspondingPairDesPref.transform.GetChild(4).gameObject;
				CorrespDescription.GetComponent<Text> ().text = cPoint.Description;

				GameObject CorrespGerms =  correspondingPairDesPref.transform.GetChild(6).gameObject;
				CorrespGerms.GetComponent<Text> ().text = cPoint.Germs;

				GameObject Auth =  correspondingPairDesPref.transform.GetChild(8).gameObject;
				Auth.GetComponent<Text> ().text = cPoint.AutherName;



				correspondingPairDesPref.transform.SetParent (IDescriptionPanelChild, false);

			}


		}


	}

/////////////////////////////IINFO BUTTON TO OPEN INFO PANNEL IN DICTIONARY////////////////////////////////////////////////////////////
	public void closedictionary(){

		AnimatorAssembly.AnimatorController.DisableDictionaryAnimation();


	}

//	public void Update(){
//		if (!EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId)) {
//			over = true;
//			
//		}
//	}


}
