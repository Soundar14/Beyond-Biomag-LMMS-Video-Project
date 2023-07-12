using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using LitJson;

public class LanguagesApi : MonoBehaviour {
	public Text BaseURL;
	string LanguageURL = UniversalClass.BaseUrl+ "/search/language"; // WORKING URL

	public string reqL = "";

	public GameObject Languagesui,LanguagepanelParent;
	public Font fontss;
	public Transform Canvass;
	public Transform LanguagePanel;
	public Text ApplicableVersionCode;
	public Text Userid;

	System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();


	

	public void Start(){
		
//		foreach (Transform child in Canvass ) {
//			child.gameObject.GetComponent<Text> ().font = fontss;

//	}

				}
	public void ToStartLanguageAPI(){
		
		StartCoroutine (LangL ());
	 }

//	public Dictionary<string, List<GenericSearchViewModel>> Lang_Dict = new Dictionary<string, List<GenericSearchViewModel>>();


	IEnumerator LangL()
	{

//		if(PlayerPrefs.HasKey("LanguagesList"))
//			{
//			
//
//			}
		Dictionary<string, string> headers = new Dictionary<string, string>();

		headers.Add ("Accept", "application/json");
		headers.Add ("Content-Type", "application/json");
		headers.Add ("x-AppType", "7GLM8C");
		headers.Add ("x-User", Userid.text);
		headers.Add ("x-ApplicableVersion", ApplicableVersionCode.text);
		headers.Add ("x-Trans-token", "SR67TUL47EK");

		WWW www = new WWW(LanguageURL, encoding.GetBytes(reqL), headers);
		yield return www;
        if (www.error != null)
		{
		//	Debug.Log("Error in downloading data !");
			yield return new WaitForSeconds (5);
			StartCoroutine (LangL ());

		}
		else
		{
			foreach (Transform child in LanguagePanel.transform) {//to destroy all the language panel prefab
				GameObject.Destroy(child.gameObject);
			}
		
				Deserialize (www.text);
			    PlayerPrefs.SetString ("LanguagesList", www.text);// to cache list of languages to work without internet

			      // Debug.Log (www.text);


	}
	}

	public void Deserialize(string json)
	{
		LangWrapper wrapperL = new LangWrapper ();
		wrapperL.langResponce = JsonMapper.ToObject<LangResponce> (json);

		foreach (GenericSearchViewModel genericSearchViewModel in wrapperL.langResponce.aaData.GenericSearchViewModels) {
		
			//Debug.Log (genericSearchViewModel.Name);
			if (genericSearchViewModel.Status == true) {
//				Debug.Log(genericSearchViewModel.Name);
				GameObject LangUI = Instantiate (Languagesui);

	

				LangUI.GetComponentInChildren<Text> ().text = genericSearchViewModel.Name;
				LangUI.GetComponentsInChildren<Button> ();
				LangUI.transform.SetParent (LanguagepanelParent.transform, false);
				if (!LangUI.GetComponent<OnLanguageClick> ()) {
					
					LangUI.AddComponent<OnLanguageClick> ();

					OnLanguageClick DictionaryScanPointsInstance = LangUI.GetComponent<OnLanguageClick> ();
					DictionaryScanPointsInstance.lang = genericSearchViewModel;
				               
				}


			}
		}
	}

	
//
//	List<string> LanguagesList = GetLanguageName ();
//
//		foreach (string lan in LanguagesList) {
//			Debug.Log (lan);
//		}
//		
//}
//
//	public List<string> GetLanguageName()
//
//	{
//		return new List<string> (Lang_Dict.Keys);
//	}
//



}
