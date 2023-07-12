using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using LitJson;

public class OnLanguageClick : MonoBehaviour {
	public GenericSearchViewModel lang;
	public string code;
	public Text Languagecode;
	public static  OnLanguageClick OnLanClick;
	public List<CorrespondingPair> CPoints;
	public GameObject LanguagePanel;
	public bool LanguageChanged;
	//string PreferedLanguageURL = "http://biomagnetictherapy-stg.us-west-2.elasticbeanstalk.com/PreferredLanguage/User";
	string PreferedLanguageURL = UniversalClass.BaseUrl+ "PreferredLanguage/User";
	public string reqPL ="";
	public Text PrefLanID;
	public InputField searcht;
	public Text ApplicableVersionCode;
	public Text Userid;



	System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

 void Start()
	{
		

        gameObject.GetComponent<Button> ().onClick.AddListener (() => { langtouchevent(); });
		Languagecode = LoadScanPoints.instance.Languagecode;
		PrefLanID = LoadScanPoints.instance.PrefLan;
		LanguagePanel = LoadScanPoints.instance.LanguagePanel;
		searcht = LoadScanPoints.instance.searcht;
		ApplicableVersionCode = LoadScanPoints.instance.ApplicableVersionCode;
		Userid = LoadScanPoints.instance.Userid;
	}
	public void langtouchevent()

	{
    //	gameObject.GetComponent<Button> ().onClick.AddListener (() => { langtouchevent(); });
		code = lang.Code;
		Languagecode.text  = lang.Code;
		  //TO CACHE LANGUAGE CODE ON LANGUAGE CHANGE
	
		searcht.text = "";


		PlayerPrefs.DeleteKey ("DisctionaryCache");
		PlayerPrefs.DeleteKey ("Uilabelscache");
		PlayerPrefs.DeleteKey ("Configuration");
		//PlayerPrefs.DeleteKey ("");
      //  PlayerPrefs.DeleteAll ();
		LoadScanPoints.instance.languageChange ();
		UniversalClass.IsLanguageClicked = true;
		gendertog.genderToggleObject.cpointDisablingReset ();
		gendertog.genderToggleObject.cpointEnablingD ();
		PlayerPrefs.SetString("LangCode", Languagecode.text);
		LanguagePanel.SetActive (false);
		//StartCoroutine (PreferdLan ());



		}


	IEnumerator PreferdLan()    // to update the prefered language of the user 
	{
		PlayerPrefs.SetInt("loginstatus",1);

		reqPL = "{'request':{'MethodType':'PUT','UserID': '"+PrefLanID.text+ "','PreferredLanguageCode': '"+Languagecode.text+"','Id': " +PrefLanID.text+"}}";

		Dictionary<string, string> headers = new Dictionary<string, string>();

		headers.Add("Content-Type", "application/json");
		headers.Add("Accept", "application/json");
		headers.Add ("x-AppType", "7GLM8C");
		headers.Add ("x-ApplicableVersion", ApplicableVersionCode.text);
		headers.Add ("x-Trans-token", "SR67TUL47EK");
		headers.Add ("x-User", Userid.text);



		WWW www = new WWW(PreferedLanguageURL, encoding.GetBytes(reqPL), headers);

		yield return www;

		if (www.error != null)
		{
			Debug.Log("Error in downloading data !");

		}
		else
		{
			LanguagePanel.SetActive (false);
     		Debug.Log(www.text);
			//Deserialize (www.text);

		}

	}

    }


