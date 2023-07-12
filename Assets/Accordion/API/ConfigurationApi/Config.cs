using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using LitJson;

[System.Serializable]

public class Config : MonoBehaviour {

	public Text BaseURL;
	//string ConfigurationURL = "http://biomagnetictherapy-stg.us-west-2.elasticbeanstalk.com/search/configuration";
	string ConfigurationURL = UniversalClass.BaseUrl+ "/search/configuration";
	 string req = "";
	public string CodeAbout = "About Us";//code for about app
	public bool testing;
	public Text aboutusdata;
	public Text privacydata;
	public Text privacydata2;
	public Text guidelinesdata,guidelinesdata2;
	//public Text termsandcondition;
	public Text LanguageCode;
	public int count = 0;
	public Text ApplicableVersionCode;
	public Text Userid;

	public configurationjsonclass ConfigJsonClass = new configurationjsonclass ();

	System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

	// Use this for initialization
	void Start () {
		testing = false;

		//StartCoroutine (ConfiN ());

	}

	public void OnLanguageChange(){

	//	{"request":{"SectionCode":"","ScanPointCode":"","CorrespondingPairCode":"","GermsCode":"","ApplicableVersionCode":"","AppTypeCode":"","CurrentLanguageCode":"en"}}


		//req = "{'request':{'SectionCode':'','ScanPointCode':'','CorrespondingPairCode':'','GermsCode':'','ApplicableVersionCode':'','AppTypeCode':'','CurrentLanguageCode':'" + LanguageCode.text+"'}}";
		req = "{'request':{'CurrentLanguageCode':'" + LanguageCode.text+"'}}";

		StartCoroutine (ConfiN ());
	}

//	public Dictionary<string, List<ConfigurationsL>> Config_Dict = new Dictionary<string, List<ConfigurationsL>>();
	
	IEnumerator ConfiN()
	{
		
		if (PlayerPrefs.HasKey ("Configuration")) {
			
			Debug.Log ("Cinfiguration present in cache");

			ConfigJsonClass = JsonUtility.FromJson<configurationjsonclass> (PlayerPrefs.GetString ("Configuration"));

			Deserialize (PlayerPrefs.GetString ("Configuration"));
		} 
		if(!PlayerPrefs.HasKey ("Configuration"))  {

			Dictionary<string, string> headers = new Dictionary<string, string> ();

			headers.Add ("Accept", "application/json");
			headers.Add ("Content-Type", "application/json");
			headers.Add ("x-AppType", "7GLM8C");
			headers.Add ("x-User", Userid.text);
			headers.Add ("x-ApplicableVersion", ApplicableVersionCode.text);
			headers.Add ("x-Trans-token", "SR67TUL47EK");


			WWW www = new WWW (ConfigurationURL, encoding.GetBytes (req), headers);
			yield return www;
		
			if (www.error != null) {
//				Debug.Log ("Error in downloading data !");
				yield return new WaitForSeconds (5);
				StartCoroutine (ConfiN ());
			} else {
			
//			Debug.Log (www.text);


				ConfigJsonClass = JsonUtility.FromJson<configurationjsonclass> (www.text);
				Debug.Log ("Configuration from api");
			Debug.Log (ConfigJsonClass.aaData.ToString());
//			if(!PlayerPrefs.HasKey("Configuration"))
//			{
				Deserialize (www.text);
				//PlayerPrefs.SetString ("Configuration", www.text);
//			}

//		


			
			}
		}
	}
	public void Deserialize(string json)

	{


		foreach (ConfigurationsL configurationsL  in ConfigJsonClass.aaData.GenericSearchViewModels) {
		         
			if (configurationsL.Code == "9B0VV5") {
				
		//		Debug.Log (configurationsL.ValueFrom);
				testing = true;
				aboutusdata.text = configurationsL.ValueFrom;//to display the details
				//PlayerPrefs.SetString ("AboutApp",aboutusdata.text);
			}
			if (configurationsL.Code == "I0UAWB") {
				testing = true;
				privacydata.text = configurationsL.ValueFrom;//to display the details
				//PlayerPrefs.SetString ("AboutApp",aboutusdata.text);
			}
			if (configurationsL.Code == "KOYA66") {
				testing = true;
				privacydata2.text = configurationsL.ValueFrom;//to display the details
				//PlayerPrefs.SetString ("AboutApp",aboutusdata.text);
			}


			if (configurationsL.Code == "HPUR01") {
				testing = true;

				string value = configurationsL.ValueFrom.Replace("&nbsp;",string.Empty); 

				string acceptable =  @"\n";
				string stringPattern = @"</?(?(?=" + acceptable + @")notag|[a-zA-Z0-9]+)(?:\s[a-zA-Z0-9\-]+=?(?:([""']?).*?\1?)?)*\s*/?>";

				//count = configurationsL.ValueFrom.Length - 10000;
				//guidelinesdata.text = configurationsL.ValueFrom.Substring(0, 10000);//to display the details
				guidelinesdata.text = configurationsL.ValueFrom;
				//guidelinesdata2.text = configurationsL.ValueFrom.Substring(10001,count-1);
				//Debug.Log (guidelinesdata.text.Length);
				//PlayerPrefs.SetString ("AboutApp",aboutusdata.text);
			}
		}
	}
}




	

	
   