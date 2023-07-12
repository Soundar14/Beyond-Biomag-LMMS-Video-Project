//Script to call seed API's (Scanpoint/Corresponding points)
// PlayerPrefs are used to store value locally

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class SeedApi : MonoBehaviour 

{

	string SeedURL =  UniversalClass.BaseUrl+ "/seed";   //test URL
	public int SeedAnatomicalPreviousValue,SeedScanpoint,SeedSection,SeedGerms,SeedCorresponding,seeduilables;
	public bool ValueChanged;
	public GameObject NoInternetConnectionPanel,DataRefreshPanel,TermsandConditionPanel,InternetRestriction;
	//bool isPaused = false;
	public bool SeedCalled = false;
	public bool FirstTime = false;
	public Text SeedAB, SeedSections, SeedSp, SeedCp;
	public int SeedValuePoints,SectionValue,ScanPointValue,uilablesValue;
	public int count = 1;
	public Text SubscriptionParameter;
	public Text Tranz1, transzV;
	public JsonSeedClass seedclassjson = new JsonSeedClass ();
	public Text Languagecode;
    //string Demo = "Hi How Are You";

      // Use this for initialization
    void Awake () 
	{
#if UNITY_ANDROID
        Screen.fullScreen = false;
#endif
        if (PlayerPrefs.GetString ("LangCode") != "") {
			
			Debug.Log ("LANGUAGE "+PlayerPrefs.GetString ("LangCode"));
			Languagecode.text = PlayerPrefs.GetString ("LangCode");
		}
		Languagecode = LoadScanPoints.instance.Languagecode;
		//Languagecode.text = PlayerPrefs.GetString ("LangCode");

	 
		if (PlayerPrefs.GetString ("SubscribedParameter") != "") {
			
			SubscriptionParameter.text = PlayerPrefs.GetString ("SubscribedParameter");
		}

	
		if (PlayerPrefs.GetInt ("Agreed") != 1) {
			TermsandConditionPanel.SetActive (true);
		}


		Debug.Log (Application.version);
        Debug.Log( "Appl: " + Application.version);

        //Debug.Log (DateTime.UtcNow);

        if (PlayerPrefs.GetString ("AppInstalled") == "asdb") {
			Debug.Log ("Already cached");
		}
		else
		{
			Debug.Log ("not cached");
			PlayerPrefs.DeleteAll ();
			PlayerPrefs.SetString("AppInstalled","asdb");
		}

		ValueChanged = false;

		SeedAnatomicalPreviousValue = PlayerPrefs.GetInt ("anatomicalvalue");
		SeedSection = PlayerPrefs.GetInt ("seedsectionValue");
		SeedCorresponding = PlayerPrefs.GetInt ("seedcorrespondingValue");
		SeedScanpoint = PlayerPrefs.GetInt ("SeedScanpointvalue");
		seeduilables = PlayerPrefs.GetInt ("uilabelsvalue");

		//        Debug.Log(PlayerPrefs.GetInt("anatomicalvalue"));
		StartCoroutine (Seed ());

	}

	void Update ()
	{
		transzV.text = Tranz1.text;
	}

	IEnumerator Seed()

	{
		Dictionary<string, string> headers = new Dictionary<string, string>();

		headers.Add("Content-Type", "application/json");
		headers.Add("Accept", "application/json");



		WWW www = new WWW(SeedURL, null, headers);


		yield return www;

		if (www.error != null)
		{
			Debug.Log("Error in downloading data !");
			NoInternetConnectionPanel.SetActive(true);
			UniversalClass.NoInternetConnection = true;
			yield return new WaitForSeconds (20);
			StartCoroutine (Seed ());
		}

		else
		{
			//            Debug.Log(www.text);

			seedclassjson	 = JsonUtility.FromJson<JsonSeedClass> (www.text);
			Deserialize (www.text);


		}

	}


	public void Deserialize(string json)
	{

		NoInternetConnectionPanel.SetActive(false);
		UniversalClass.NoInternetConnection = false;
		InternetRestriction.SetActive(false);

		SeedCalled = true;
		//FirstTime = true;
		foreach (Seedmaster seedmasterS in seedclassjson.aaData.seedmaster) {

			if (seedmasterS.Name == "anatomicalbiomagneticmatrix") 
			{
                //PlayerPrefs.DeleteAll();
                    Debug.Log ("SEEDS"+seedmasterS.Value);
				if (seedmasterS.Value == SeedAnatomicalPreviousValue && SeedAnatomicalPreviousValue != 0) {
					ValueChanged = false;
					UniversalClass.SeedChanged = false;
                   SeedValuePoints = seedmasterS.Value;

					Debug.Log ("SEED VALUE NOT CHANGED" );

				}  
				if (seedmasterS.Value != SeedAnatomicalPreviousValue) {
                    ValueChanged = true;
                    UniversalClass.SeedChanged = true;
					SeedValuePoints = seedmasterS.Value;
                    Debug.Log("SEED VALUE CHANGED  " + seedmasterS.Value);

                }
			}
			//
			//			if (seedmasterS.Name == "scanpoint") 
			//			{
			//				//				Debug.Log (seedmasterS.Value);
			//				if (seedmasterS.Value == SeedScanpoint && SeedScanpoint != 0) {
			//					ValueChanged = false;
			//					UniversalClass.SeedChanged = false;
			//					Debug.Log ("Seed not changed");
			//
			//				}  
			//				if (seedmasterS.Value != SeedScanpoint) {
			//
			//					UniversalClass.SeedChanged = true;
			//					ValueChanged = true;
			//					ScanPointValue = seedmasterS.Value;
			//					//Debug.Log ("Anatomical  Seed");
			//
			//				}
			//			}

			//////////////////////////

			//			if (seedmasterS.Name == "correspondingpair") 
			//			{
			//				//				Debug.Log (seedmasterS.Value);
			//				if (seedmasterS.Value == SeedCorresponding && SeedCorresponding != 0) {
			//				//	ValueChanged = false;
			//					UniversalClass.SeedChanged = false;
			//					Debug.Log ("Seed not changed");
			//
			//				}  
			//				if (seedmasterS.Value != SeedCorresponding) {
			//
			//					UniversalClass.SeedChanged = true;
			//			ValueChanged = true;
			//				//	SeedCp.text = seedmasterS.Value.ToString();
			//					PlayerPrefs.SetInt ("seedcorrespondingValue", seedmasterS.Value);
			//				}
			//			}
			//
			//			if (seedmasterS.Name == "section") 
			//			{
			//						Debug.Log (seedmasterS.Value);
			//				if (seedmasterS.Value == SeedSection && SeedSection != 0) {
			//					ValueChanged = false;
			//					UniversalClass.SeedChanged = false;
			//
			//
			//				}  
			//				if (seedmasterS.Value != SeedSection) {
			//
			//					UniversalClass.SeedChanged = true;
			//					ValueChanged = true;
			//					SectionValue = seedmasterS.Value;
			//					Debug.Log ("Section Seed");
			//
			//				}
			//			}

			///////////////////////
					if (seedmasterS.Name == "uilabel") {
										

                            							if (seedmasterS.Value != seeduilables) {
	
					Debug.Log ("UI labels changed");
					uilablesValue = seedmasterS.Value;
					//PlayerPrefs.DeleteKey ("Uilabelscache");
					
									}
					}


			//////////////////////////////


		}


	}


	void OnApplicationFocus( bool hasFocus )
	{


	//	Debug.Log ("Application maximized");
		StartCoroutine (Seed ());
		count = count + 1;




	}


	//	IEnumerator WaitInfo(){
	//		
	//		DataRefreshPanel.SetActive (true);
	//
	//		yield return new WaitForSeconds (6);
	//
	//		DataRefreshPanel.SetActive (false);
	//	}


	public void ToCacheData(){
		
		Debug.Log ("caching seed");
		//	int seedvaluepoints = SeedValuePoints;
		PlayerPrefs.SetInt ("anatomicalvalue", SeedValuePoints);
		PlayerPrefs.SetInt ("seedsectionValue", SectionValue);
		PlayerPrefs.SetInt ("SeedScanpointvalue", ScanPointValue);
		PlayerPrefs.SetInt ("uilabelsvalue", uilablesValue);

	}

	public void ToCacheAgree(){

		PlayerPrefs.SetInt ("Agreed", 1);
	}


}

