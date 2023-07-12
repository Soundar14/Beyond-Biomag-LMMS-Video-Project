//Load scan points, Search functionality of dictionary.
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using System;
//using Newtonsoft.Json;
using LitJson;

public class LoadScanPoints : MonoBehaviour 
{
	public GameObject WelcomePanel;
	public Text BaseURL;
	public Font Myfont;
	//public GameObject AfterSplash;
	public dictionarydescription dictionaryd;
	int m,f = 0;
	public GameObject Description;
	public Transform target;
	public FocusBodyParts resetmodelposition;
	public Material Blue,Original,RedHighlight,RedOriginal;
	public GameObject LanguagePanel;
	public GameObject LoginPanel;
	public GameObject DropDownForScanguide;
	public GameObject FemaleScanpoints,MaleScanpoints,FemalCp,MaleCp;
	public LanguagesApi LangApi;
	public Text PrefLan;
	public int j = 0;
	public string TestData = "";
	public string data = "";
	public bool apicalled;
	public Text ApplicableVersionCode;
	public Text Userid,SeedABMvalue;
	public Text SubcribedParameter;
	public SeedApi seed;
	public  Material spmaterial;
	public Vector3 sizeB,CenterB;
	public SubscriptionMain SupscriptionData;

	AnimatorAssembly animateassmble;

	string ScanPointUrl = UniversalClass.BaseUrl+"/Search/AnatomicalBiomagneticMatrix"; 


//////////////////////////Language API//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	public string Language;
	string english;
	string spanish;
	public bool LoggedOnce = false;
	string Testing;
	//int ik=0;
	///////////////////////////////////////////////////////Language API////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	public Text codetesting;

	public Text error;
	public Text Languagecode;

	public BioMagneticPoint bioMagneticPoint;
	public GameObject SectionUI;
	public GameObject SectionTitleUI;
	public GameObject ScanPointUI,SearchSpui;
	public GameObject DictionaryPanel;
	public Button ResetButton;
	//public GameObject DictionaryCollider;
	public GameObject ScanPointUIGParent;
	public GameObject ScanPointUIG;
	public GameObject Accordion,Search,SearchParent;
	public GameObject DescriptionPanel;
	public GameObject DescriptionPanelChild;
	public GameObject DescriptionPanelBtn;
	public GameObject ScanPointDesPref;
	public GameObject CorrespondingPairDesPref;
	public GameObject loading;
	public Config Configuration;

	public GameObject Blocker;

	public Text[] HistoryCount;
	public GameObject HistoryParent;
	public ScanPointPlayer SPlayer;


	////////////////////////////////////////////Main Scan Point List/////////////////////////////////////////////////////////////////////


	public List<ScanPoint> AllScanPoint;
	public List<GameObject> SpointUI_List;

	////////////////////////////////////////////for DPD////////////////////////////////////////////////////////////////////////////////// 
	//	public GameObject AccordionDropdownParent;
	public GameObject AccordionDropdown;
	public GameObject ScanpointtitleUI;
	public GameObject Spui;
	public GameObject Cptitle;
	//public Text CpCode;
	public GameObject CptitleCode;
	public SeedApi Datachanged;
	//	public GameObject CptitlePanelButton;
	////////////////////////////////////////////for DPD////////////////////////////////////////////////////////////////////////////////// 
	/// 
	string currentText,PreviousText;
	public gendertog point;
	public InputField searcht;
	int i;

	////////////////////////////////////////////History panel/////////////////////////////////////////////////////////////////////////// 
	public Text HistoryText;
	public GameObject HistoryPanel;
	public bool HistoryBool;
	public GameObject HistoryHeading;
	public GameObject DictionaryHeading;
	public GameObject HistoryBackBtn;

	System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding(); 

	public UIlables UIlab;
	private static LoadScanPoints Instance;

	public static LoadScanPoints instance

	{
		get
		{
			if(Instance == null)
				return GameObject.FindObjectOfType<LoadScanPoints>();

			return Instance;


		}
	}

	public delegate void LoadedData();
	public LoadedData IntimateScanPoints;
	public GameObject[] CorrespondingPoints;

	public Dictionary<string, List<ScanPoint>> Section_Scanpoint_Dict = new Dictionary<string, List<ScanPoint>>();
	public Dictionary<string, List<CorrespondingPair>> Scanpoint_cPair_Dict = new Dictionary<string, List<CorrespondingPair>>();
	//public Dictionary<string, List<CorrespondingPair>> Scanpoint_cPair_Dict = new Dictionary<string, List<CorrespondingPair>>();
	// Use this for initialization
	void Start () 
	{
        Debug.Log(ScanPointUrl);
        ////////////////////////////////

        sizeB = new Vector3(0.0005419541f,0.0008543934f,0.000540371f);
		CenterB = new Vector3(7.048586e-10f,0.0004272004f,-6.394761e-05f);

		Debug.Log (PlayerPrefs.GetInt("loginstatus"));
		animateassmble = GameObject.Find ("AnimatorControllerObject").GetComponent<AnimatorAssembly> ();

		i = 0;
		AllScanPoint = new List<ScanPoint> ();
		SpointUI_List = new List<GameObject> ();
		//SpointUIG_List = new List<GameObject> ();
		bioMagneticPoint = new BioMagneticPoint ();
		HistoryPanel.SetActive (false);
        if (PlayerPrefs.GetInt("openedwelcome") == 1)
        {
           // StartCoroutine(GetScanPoints());
            ToStartApiCall();
            ToDestroySPCall();
        }

        // To make it more fast
        //loading.SetActive (true);
        //HistoryText.text = PlayerPrefs.GetString ("History");//History in dictionary

        if (PlayerPrefs.HasKey("userid") && PlayerPrefs.HasKey("applicableversioncode"))
		{
			ApplicableVersionCode.text = PlayerPrefs.GetString ("applicableversioncode");
			Userid.text = PlayerPrefs.GetString ("userid");

		}
    }

	public void clearingcache(){
		PlayerPrefs.DeleteAll ();
	}

	public void ToStartApiCall(){

        //PlayerPrefs.DeleteAll();


        if (LoggedOnce == false) {                    
			StartCoroutine (GetScanPoints ());
			LoggedOnce = true;
			//WelcomePanel.SetActive (false);
		} 
		if (PlayerPrefs.GetInt("loginstatus") == 1) {
			Debug.Log ("AlreADY LOGGED ONCE");
		}


	}

    public void ToStartSubCall()
    {
            StartCoroutine(GetScanPoints());
            LoggedOnce = true;
    }


    public void languageChange()//function called when language button clicked
	{
		WelcomePanel.SetActive (true);
		PlayerPrefs.SetInt("loginstatus",1);
		m = 0;
		f = 0;
		resetmodelposition.ResetButtonPressed (target);
		SupscriptionData.startApi ();
		gendertog.genderToggleObject.ModelTogOnSignout ();

		FemaleScanpoints.SetActive (true);
		MaleScanpoints.SetActive (true);
		FemalCp.SetActive (false);


		foreach (Transform child in Accordion.transform) {//to destroy all the dictioary prefab
			GameObject.Destroy(child.gameObject);
		}

		foreach (Transform child in Search.transform) {//to destroy all the search panel prefab
			GameObject.Destroy(child.gameObject);
		}

		//	PlayerPrefs.DeleteKey ("DisctionaryCache");
		Scanpoint_cPair_Dict.Clear();
		Section_Scanpoint_Dict.Clear ();

		Language = "{'request':{'SectionCode':'','ScanPointCode':'','CorrespondingPairCode':'','GermsCode':'','ApplicableVersionCode':'"+SubcribedParameter.text+"','AppTypeCode':'2AP7S5','CurrentLanguageCode':'" + Languagecode.text + "','Publishedfor3D':1}}";

		StartCoroutine (GetScanPoints());
		Configuration.OnLanguageChange ();
		UIlab.OnLanguageChange ();
		//LanguagePanel.SetActive (false);
	}

	void Awake(){
		//	PlayerPrefs.DeleteAll ();	
		apicalled = false;

	}

	public void DictionaryCaching(){

		//loading.SetActive (true);

		if (PlayerPrefs.HasKey ("DisctionaryCache")) {

			//loading.SetActive (false);

			//		Debug.Log(PlayerPrefs.GetString ("DisctionaryCache"));
			Deserialize (PlayerPrefs.GetString ("DisctionaryCache"));
			Debug.Log ("from dictionary");
			loading.SetActive (false);
			//Deserialize (PlayerPrefs.GetString ("DisctionaryCache"));
		}
		else if(!PlayerPrefs.HasKey ("DisctionaryCache")) {

			//loading.SetActive (true);
			//StartCoroutine ( GetScanPoints());
			//	Deserialize (PlayerPrefs.GetString ("DisctionaryCache"));
		}
	}


	IEnumerator GetScanPoints()
	{
		loading.SetActive (true);
        if (PlayerPrefs.GetInt("openedwelcome") == 1)
        {
            LoginPanel.SetActive(false);
          //  WelcomePanel.SetActive(false);
        }
        else
        {
            animateassmble.PlayLoginAnimation();

        }


        Configuration.OnLanguageChange ();
		//LangApi.ToStartLanguageAPI ();
		Language = "{'request':{'SectionCode':'','ScanPointCode':'','CorrespondingPairCode':'','GermsCode':'','ApplicableVersionCode':'"+SubcribedParameter.text+"','AppTypeCode':'2AP7S5','CurrentLanguageCode':'" + Languagecode.text + "','Publishedfor3D':1}}";


		if (PlayerPrefs.GetInt("loginstatus") == 1) {

			Debug.Log ("taking data from dictionary");
			DictionaryCaching ();

		}
		if(UniversalClass.SeedChanged == true ||  !PlayerPrefs.HasKey ("DisctionaryCache") || PlayerPrefs.GetString ("DisctionaryCache") == "") {

			seed.ToCacheData ();

 			Debug.Log ("from APi");
			// PlayerPrefs.DeleteKey ("DisctionaryCache");


			Dictionary<string, string> headers = new Dictionary<string, string> ();

			headers.Add ("Accept", "application/json");
			headers.Add ("Content-Type", "application/json");
			headers.Add ("x-AppType", "7GLM8C");
			headers.Add ("x-User", Userid.text);
			headers.Add ("x-ApplicableVersion", ApplicableVersionCode.text);
			headers.Add ("x-Trans-token", "SR67TUL47EK");



			//GET Json 
			WWW www = new WWW (ScanPointUrl, encoding.GetBytes (Language), headers);
			yield return www;

			if (www.error != null) {
				Debug.Log ("Error in downloading data !");
				PlayerPrefs.SetString ("ErrorDataCache", www.text);

				yield return new WaitForSeconds (5);
				StartCoroutine (GetScanPoints ());

                Debug.Log(www.text + "Dataa");
				//error.text = "Error in downloading data!!";
			}
			//loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

			else {
				//		 Debug.Log(www.text);
				if (!PlayerPrefs.HasKey ("DisctionaryCache")) {
					//loading.SetActive (false);
					PlayerPrefs.SetString ("DisctionaryCache", www.text);
					Deserialize (www.text);
					//Deserialize (PlayerPrefs.GetString ("DisctionaryCache"));
				} else if (PlayerPrefs.GetString ("DisctionaryCache") != www.text) {
					if (PlayerPrefs.GetString ("DisctionaryCache") == PlayerPrefs.GetString ("ErrorDataCache")) {
						PlayerPrefs.DeleteKey ("DisctionaryCache");
					} else {
						PlayerPrefs.SetString ("DisctionaryCache", www.text);
					}
				}
                Debug.Log(www.text + "Dataa");

            }
        }

	}

	public void Deserialize(string json)
	{
		Wrapper wrapper = new Wrapper();
		wrapper.md =  JsonMapper.ToObject<MasterData>(json);
      
      Debug.Log (wrapper.md.aaData.AnatomicalBiomagneticMatrix.Count);

		foreach (BioMagneticPoint bioMagneticPoint  in wrapper.md.aaData.AnatomicalBiomagneticMatrix)
		{
			//Creating new corresponting pair object 
			CorrespondingPair correspondingPair = new CorrespondingPair();
			correspondingPair.Code = bioMagneticPoint.CorrespondingPairCode;
			correspondingPair.Name = bioMagneticPoint.CorrespondingPair;
			correspondingPair.RespectiveScanPoint = bioMagneticPoint.ScanPointCode;
			correspondingPair.Description = bioMagneticPoint.Description;
			correspondingPair.Location = bioMagneticPoint.LocationCorrespondingPair;
			correspondingPair.GermUserFriendlyCode = bioMagneticPoint.GermsUserFriendlyCode;
			correspondingPair.Germs = bioMagneticPoint.Germs;
			correspondingPair.AutherName = bioMagneticPoint.AutherName;

			//Adding ScanPointCode as key and correspondingPair as value to dictionary (Scanpoint_cPair_Dict), where ScanPointCode != null
			if(bioMagneticPoint.ScanPointCode != null)
			{
				if (Scanpoint_cPair_Dict.ContainsKey (bioMagneticPoint.ScanPointCode)) 
				{
					//if scanpoint already exists, add the corresponding pair to the value, which is a list of <CorrespondingPair>					
					Scanpoint_cPair_Dict [bioMagneticPoint.ScanPointCode].Add (correspondingPair);
				} 
				else 
				{
					//if scanpoint does not exists in the dictionary, add (ScanPointCode, List<correspondingPair>)
					List<CorrespondingPair> tempCPList = new List<CorrespondingPair> ();
					tempCPList.Add (correspondingPair);
					Scanpoint_cPair_Dict.Add (bioMagneticPoint.ScanPointCode, tempCPList);
				}
			}

			//Creating new ScanPoint Object
			ScanPoint sPoint = new ScanPoint ();
			sPoint.Code = bioMagneticPoint.ScanPointCode;
			sPoint.Name = bioMagneticPoint.ScanPoint;
			sPoint.SectionCodeBelonging = bioMagneticPoint.SectionCode;
			sPoint.Location = bioMagneticPoint.LocationScanPoint;
			sPoint.SortingRank = bioMagneticPoint.SortingRank;
			sPoint.CPairs.Add (correspondingPair);

			//adding SectionCode<string> as key and List of ScanPoint Objects as value to dictionary named Section_Scanpoint_Dict
			if (bioMagneticPoint.SectionCode != null) 
			{
				//if SectionCode already exists, add the ScanPoint object to the value, which is a list of <ScanPoint>	
				if (Section_Scanpoint_Dict.ContainsKey (bioMagneticPoint.Section))
				{
					//Check if the list is having any scanpoint object with the same name as the current scanpoint object. If not, add the scanpoint object to the list.
					//This prevents redundant scanpoint in the list
					if(Section_Scanpoint_Dict [bioMagneticPoint.Section].Any(record => record.Name == sPoint.Name) == false)
						Section_Scanpoint_Dict [bioMagneticPoint.Section].Add (sPoint);
				} 
				else
				{
					//if SectionCode does not exist in the dictionary, add (SectionCode, scanpoint<list>) to it
					List<ScanPoint> tempSPList = new List<ScanPoint> ();
					tempSPList.Add (sPoint);
					Section_Scanpoint_Dict.Add (bioMagneticPoint.Section, tempSPList);
				} 
			}
			//	IntimateScanPoints ();	
		}

		//Debug.Log (Scanpoint_cPair_Dict.Count);

		List<string> sections = GetSectionsName ();

		//To create Dictionary UI in Runtime
		foreach (string str in sections) 
		{
			//Debug.Log (str);
			//Instantiating required prefabs
			GameObject sectionUI = Instantiate (SectionUI);
			GameObject sectionTitleUI = Instantiate (SectionTitleUI);
			//Assigning SectionName
			sectionTitleUI.GetComponent<Text> ().text = "      "+ str;
			//Forming the regired hierarchy
			sectionTitleUI.transform.SetParent(sectionUI.transform,false);
			sectionUI.transform.SetParent(Accordion.transform,false);
			//Populating scanpoint data under each sections
			CreateScanPointUI (str, sectionUI);
		}


	}

	/// <summary>
	/// returns the name of the sections as list.
	/// </summary>
	/// <returns>The sections name.</returns>
	public List<string> GetSectionsName()
	{
		return new List<string> (Section_Scanpoint_Dict.Keys);
	}

	/// <summary>
	/// returns all scan points names as list.
	/// </summary>
	/// <returns>The all scan points names.</returns>
	public List<string> GetAllScanPointsNames()
	{
		return new List<string> (Scanpoint_cPair_Dict.Keys);
	}

	/// <summary>
	/// returns the scan points for given section.
	/// </summary>
	/// <returns>The scan points for section.</returns>
	/// <param name="SectionName">Section name.</param>
	public List<ScanPoint> GetScanPointsForSection(string SectionName)
	{
		//Debug.Log (Section_Scanpoint_Dict [SectionName]);
		return Section_Scanpoint_Dict [SectionName];
	}

	/// <summary>
	/// Returns the corresponding pairs list for given scanpoint.
	/// </summary>
	/// <returns>The corresponding pairs.</returns>
	/// <param name="ScanpointName">Scanpoint name.</param>
	public List<CorrespondingPair> GetCorrespondingPairs(string ScanpointName)
	{
		if (ScanpointName != null)
			return Scanpoint_cPair_Dict [ScanpointName];
		else
			return	new  List<CorrespondingPair> ();
	}

	public void CreateScanPointUI(string sectionName, GameObject parentUI)
	{


		//Get list of scanPoints under the given section
		List <ScanPoint> scanPoints = GetScanPointsForSection (sectionName);

		//	AllScanPoint.Add (scanPoints [0]);
		//	Debug.Log (AllScanPoint.Count);
		foreach(ScanPoint sp in scanPoints)
		{

			//try{
			//	if (sp.Name.Contains (searcht.text)) {
			//	Debug.Log (sp.Name.Contains (searcht.text));
			//  AllScanPoint.Add (sp);
			//Instantiating scanpoint UI for each scanpoint
			GameObject sPointUI = Instantiate (ScanPointUI);
			//GameObject sPointUIG = Instantiate(ScanPointUIG);

			//Assinging the name 
			sPointUI.GetComponent<Text> ().text = "      "+ sp.Name;

			try{

				foreach (GameObject MalescanPointObject in GameObject.FindGameObjectsWithTag("ScanPointsMale")) {

					if(MalescanPointObject.name == sp.Code){
						
						MalescanPointObject.GetComponent<ScanPointID> ().ScanPointName =sp.Name;
						MalescanPointObject.GetComponent<ScanPointID> ().ScnPointID = m;
						MalescanPointObject.GetComponent<ScanPointID> ().ScanpointLocation = sp.Location;
						m++;

						if(MalescanPointObject.GetComponent<BoxCollider>() == null)
						{
							MalescanPointObject.AddComponent<BoxCollider>();
							MalescanPointObject.GetComponent<BoxCollider>().size =sizeB;
							MalescanPointObject.GetComponent<BoxCollider>().center = CenterB;
						}
						if(MalescanPointObject.GetComponent<MeshRenderer>() == null)
						{
							MalescanPointObject.AddComponent<MeshRenderer>();
							MalescanPointObject.GetComponent<MeshRenderer>().material = spmaterial;

						}


					}

						
				}


				foreach (GameObject FemalescanPointObject in GameObject.FindGameObjectsWithTag("ScanPointsFemale")) {

					if(FemalescanPointObject.name == sp.Code){
						//if(FemalescanPointObject.GetComponent<BoxCollider>() == null){

						FemalescanPointObject.GetComponent<ScanPointID> ().ScanPointName =sp.Name;
						FemalescanPointObject.GetComponent<ScanPointID> ().ScnPointID = f;
						FemalescanPointObject.GetComponent<ScanPointID> ().ScanpointLocation = sp.Location;
						f++;

						if(FemalescanPointObject.GetComponent<BoxCollider>() == null)
						{
							FemalescanPointObject.AddComponent<BoxCollider>();
							FemalescanPointObject.GetComponent<BoxCollider>().size =sizeB;
							FemalescanPointObject.GetComponent<BoxCollider>().center = CenterB;
						}
						if(FemalescanPointObject.GetComponent<MeshRenderer>() == null)
						{
							FemalescanPointObject.AddComponent<MeshRenderer>();
							FemalescanPointObject.GetComponent<MeshRenderer>().material = spmaterial;
						}

					}
				}
			}
			catch(Exception e){
				Debug.Log (sp.Code);
			}

			//////////////



			///////////

			if (!sPointUI.GetComponent<ScanPointsEventListener> ()) 
			{
				sPointUI.AddComponent<ScanPointsEventListener> ();
				ScanPointsEventListener DictionaryScanPointsInstance = sPointUI.GetComponent<ScanPointsEventListener> ();
				//  OnMouseClickClass DictionaryScanPointsInstance2 = sPointUI.GetComponent<OnMouseClickClass> ();
				DictionaryScanPointsInstance.SPoint = sp;
				// DictionaryScanPointsInstance2.SPoint = sp;
				DictionaryScanPointsInstance.CPoints =  GetCorrespondingPairs (sp.Code);
			}

			sPointUI.transform.SetParent(parentUI.transform,false);

			SearchPanelScanPointUI (sp);
			//StartCoroutine (TodestroyScanPoints ());

		}
	}



	// For Optimization
	public void SearchPanelScanPointUI(ScanPoint sp)
	{

		SpointUI_List.Add(Instantiate (SearchSpui));

		SpointUI_List[i].GetComponent<Text> ().text = "  "+ sp.Name;
		SpointUI_List [i].transform.GetChild (0).GetComponent<Text> ().text = sp.Code;
		SpointUI_List [i].transform.GetChild (1).GetComponent<Text> ().text = sp.Location;
		//	SpointUI_List[i].transform.GetChild(0).GetComponent<Text>().text = " " + 

		if (!SpointUI_List[i].GetComponent<ScanPointsEventListener> ()) {
			SpointUI_List[i].AddComponent<ScanPointsEventListener> ();
			ScanPointsEventListener DictionaryScanPointsInstance = SpointUI_List[i].GetComponent<ScanPointsEventListener> ();
			DictionaryScanPointsInstance.SPoint = sp;
			DictionaryScanPointsInstance.CPoints = GetCorrespondingPairs (sp.Code);

		}

		//Forming the required heirarchy
		SpointUI_List[i].transform.SetParent (Search.transform, false);

		i++;

	}



	void Update(){
		//	Application.isShowingSplashScreen == false && 
		if (apicalled == false) {
			//Debug.Log ("Splash screen has been ended");
			//	AfterSplash.SetActive(true);
			if(PlayerPrefs.GetInt("loginstatus") == 1){

				Debug.Log (PlayerPrefs.GetInt("loginstatus"));

				//LoggedOnce = true;
				apicalled = true;
				//Invoke ("ToStartApiCall", 2f);
				//loading.SetActive(true);
				Debug.Log ("Auto Login Call");
				LangApi.ToStartLanguageAPI ();
				ToStartApiCall ();
				//animateassmble.PlayLoginAnimation ();

			}
		}

		if (searcht.text.Length < 1) {
			if (Search.activeSelf == true) {
				Search.SetActive (false);
				SearchParent.SetActive (false);

			}
		} else if (searcht.text.Length > 2) {
			//Debug.Log ("Searching");
			//	Debug.Log ("working");
			if (Search.activeSelf == false) {
				Search.SetActive (true);
				SearchParent.SetActive (true);
			}

			SearchScanCall ();
		}
	}




	public void SearchScanCall(){

		if (Search.activeSelf == true) {
			currentText = searcht.text;
			if (currentText != PreviousText) {
				//DestroyPreviousSearchObject ();
				SearchScanPointUI ();
			}
			PreviousText = currentText;

		}
	}



	public void SearchScanPointUI()//SEARCH FUNCTION
	{
		List <CorrespondingPair> cpList = new List<CorrespondingPair> ();


		foreach (Transform child in Search.transform) {
			Scanpoint_cPair_Dict.TryGetValue (child.GetChild (0).GetComponent<Text> ().text, out cpList);
			if (child.gameObject.GetComponent<Text> ().text.Contains (searcht.text, StringComparison.OrdinalIgnoreCase) || child.GetChild (1).GetComponent<Text> ().text.Contains(searcht.text, StringComparison.OrdinalIgnoreCase)) {//|| sPoint.Location.Contains(searcht.text,StringComparison.OrdinalIgnoreCase)) 

				child.gameObject.SetActive (true);
			} else {
				child.gameObject.SetActive (false);
							



				foreach (CorrespondingPair cPoint in cpList) {
					if (cPoint.Description.Contains (searcht.text, StringComparison.OrdinalIgnoreCase) || cPoint.Name.Contains (searcht.text, StringComparison.OrdinalIgnoreCase) || cPoint.Location.Contains (searcht.text, StringComparison.OrdinalIgnoreCase) || cPoint.Germs.Contains (searcht.text, StringComparison.OrdinalIgnoreCase)) {
						child.gameObject.SetActive (true);
						break;
					} 

				}
			}




		}
	}


	public void HistoryButton(){

		HistoryBool = !HistoryBool;
		if (HistoryBool == true) 
		{
			HistoryPanel.SetActive (true);
			HistoryHeading.SetActive (true);
			DictionaryHeading.SetActive (false);
			DescriptionPanelBtn.SetActive (false);

		}


		if (HistoryBool == false) 
		{
			HistoryPanel.SetActive (false);
			HistoryHeading.SetActive (false);
			DictionaryHeading.SetActive (true);

			if(DescriptionPanel.activeInHierarchy == true && UniversalClass.IsDictionaryEnabled == true){
				DescriptionPanelBtn.SetActive (true);
			}

		}
	}

	public void HistoryDisplay()
	{

		HistoryParent.GetComponentsInChildren<Text> ();
		HistoryCount = HistoryParent.GetComponentsInChildren<Text> ();
		if (j < HistoryParent.transform.childCount &&  Testing !=  "    " + PlayerPrefs.GetString ("History") ) {             //&&  HistoryCount [j].text == "    " + PlayerPrefs.GetString ("History")


			HistoryCount [j].text = "    " + PlayerPrefs.GetString ("History");

			Testing =  "    " + PlayerPrefs.GetString ("History");
			j++;

		} else {

			j = 0;
		}
		//if (PlayerPrefs.GetString ("History") != HistoryCount [j].text) 

	}



	IEnumerator TodestroyScanPoints()
	{
		yield return new WaitForSeconds (1);

		foreach (GameObject MalescanPointObject in GameObject.FindGameObjectsWithTag("ScanPointsMale")) {
			//Debug.Log (scanPointObject.GetComponent<ScanPointID> ().ScanPointName);
			if (MalescanPointObject.GetComponent<ScanPointID> ().ScanPointName == "") {
               // Destroy(MalescanPointObject.GetComponent<MeshRenderer>());
                //MalescanPointObject.GetComponent<BoxCollider> ().enabled = false;

            }
		}
		foreach (GameObject FemalescanPointObject in GameObject.FindGameObjectsWithTag("ScanPointsFemale")) {
			//Debug.Log (scanPointObject.GetComponent<ScanPointID> ().ScanPointName);
			if (FemalescanPointObject.GetComponent<ScanPointID> ().ScanPointName == "") {
				//Destroy (FemalescanPointObject.GetComponent<MeshRenderer> ());
				//FemalescanPointObject.GetComponent<BoxCollider>().enabled = false;

			}
		}
		Invoke ("ToDisableFemaleSp", 4f);
		//FemaleScanpoints.SetActive (false);

		PlayerPrefs.SetInt("loginstatus",1);

	


	}
	// to be called when seed api is changed when application in background



	public	void ToDestroySPCall()
	{

		StartCoroutine (TodestroyScanPoints ());
		MaleCp.SetActive (true);

	}
	void ToDisableFemaleSp(){
		Debug.Log ("Disable Point");
		FemaleScanpoints.SetActive (false);
		loading.SetActive (false);
	}











}

















