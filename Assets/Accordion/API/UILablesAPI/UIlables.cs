//Script includes all the UIlables for Multilinguil feature.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using LitJson;

public  class UIlables : MonoBehaviour {


	public Text WelcomeMessage;
	public Text StartExploring;

	public Text SubscriptionInfo;
	public Text SubscribeNow;
	public Text Subscribe_Label_Popup;

	public Text OK;
	public Text Cancel;
	public Text RestoreMessage;

	public Text BaseURL;
	public Text RestoreText;
	public Text authortext;
	public Text Subscribetext;

	/////////////////////////////COACHMARKS//////////////////////////////////////////////////////////////////////////////////
	public string welcome;
	public string swipeleft;
	public string t2;
	public string t3;
	public string t4;
	public string t5;
	public string t6;
	public string t7;
	public string t8;
	public string t9;
	public string t10;
	public string t11;
	public string t12;
	public string t13,t14;
	public string tconcentric;
	public string tdictionarycoachmarks;
	public string tdictionaryscanpoint;
	public string tdictionarycorresponding;
	public string t19;
	/////////////////////////////COACHMARKS//////////////////////////////////////////////////////////////////////////////////
	public Text LanguageCodeText;
	public GameObject LoadingPage;
	/// ////////////////////////navigation/////////start/////////////////////////////////////////////////////////////////////////////////
	public Text About;
	public Text AboutHeading;
	public Text Privacy;
	public Text PrivacyHeading,PrivacySubscription;
    public Text Guidelines;
	public Text GuidelinesHeading;
	public Text Languages;
	public Text Signout;
	public Text Website;
	public Text Tutorial;
	public Text Next;
	public Text LoadingPageMessage;
	///////////////////////////navigation//////////end////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	///////////////////////////Login//////////////////////////////////////////////////////////////////////////////////////////////////

	public Text RememberMe;
	public Text ForgotPassword;
	public Text ForgotPasswordinerrorpage;
	public Text ForgotPasswordHeading;
	public Text SignIn;
	public Text Username;
	public Text Password,passwordR;
	public Text Send;
	public Text Ok;
	public Text Signinerrortxt;
	public Text Signinerrormessage;
	public Text Back;
	// // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	public Text Dictionarytxt;
	public Text Historytxt;
	public Text Search;
	public Text ScanPointGuide;
//	public Text BioMagHeading;
	// // /////////////////////////////////////DICTIONARY DESCRIPTION PANEL////////////////////////////////////////////////////////////////////////////////
	public Text CPLocation;
	public Text CPInterpretation;
	public Text CPGerms;
	public Text SPLocation;

	public GameObject CorrspondingpairParent;
	//public Text Corrspondingpair;

	public GameObject ScanpointParent;
	//public Text Scanpoint;
	public Text Emailid;

	public Text Notxt;
	public Text Yestxt;
	public Text arusure;
	public Text interneterrormsg;
	public GameObject  InternetErrorConnection;
	/// <summary>
	/// ///////////////////////////////TUTORIALS LABELS//////////////////////////////////////

	public Text welcometxt;
    public Text SwipeLeft;
	public Text Skip,SkipSubscription;
	public Text FillAllFields;
	public Text PasswordSuccessfullySent;
	public Text PasswdError;

	public Text Subscriptiont,Subscriptionpage,Subscriptiont_onemonth;
	public Text Spantxt,Pricetxt,DescriptionS,Spantxt_onemonth,Pricetxt_onemonth,DescriptionS_onemonth;

	public Text Firstnametxt, Lastnametxt, confirmpasswordtxt;

	public Text Continue, ContinueMessage, ExpireMessage, SubscriptionE, SubscribeE;

	public JsonClassUIlabels uiclass = new JsonClassUIlabels();

	string UilabelURL = UniversalClass.BaseUrl+ "/search/Uilabel";


	 public string reqLabels = "";

	System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();



	public void Awake(){
		
//		if (PlayerPrefs.HasKey ("LangCode") != null) {
//		
//			LanguageCodeText.text = PlayerPrefs.GetString ("LangCode");
//			Debug.Log (PlayerPrefs.GetString ("LangCode"));
//		}

	 reqLabels = "{'request':{'Name':'','AppTypeCode':'2AP7S5','LanguageCode':'"+ LanguageCodeText.text + "','GenericSearchViewModel':{'Name':''}}}";

		StartCoroutine (UILabels ());
	}

	public void OnLanguageChange(){
		reqLabels = "{'request':{'Name':'','AppTypeCode':'2AP7S5','LanguageCode':'"+ LanguageCodeText.text + "','GenericSearchViewModel':{'Name':''}}}";
		LoadingPage.SetActive (true);
		StartCoroutine (UILabels ());
	}


	IEnumerator UILabels()
	{
		yield return new WaitForSeconds (1f);

		if (PlayerPrefs.HasKey ("Uilabelscache")) 
		{
			uiclass	= JsonUtility.FromJson<JsonClassUIlabels> (PlayerPrefs.GetString("Uilabelscache"));
			Debug.Log ("uilabels present in  cache");
			//Debug.Log(PlayerPrefs.GetString("Uilabelscache"));
			Deserialize (PlayerPrefs.GetString ("Uilabelscache"));
		}


		if(!PlayerPrefs.HasKey ("Uilabelscache"))
		{
			
			reqLabels = "{'request':{'Name':'','AppTypeCode':'2AP7S5','LanguageCode':'" + LanguageCodeText.text + "','GenericSearchViewModel':{'Name':''}}}";

			Dictionary<string, string> headers = new Dictionary<string, string> ();

			headers.Add ("Accept", "application/json");
			headers.Add ("Content-Type", "application/json");



			WWW www = new WWW (UilabelURL, encoding.GetBytes (reqLabels), headers);
			yield return www;

			if (www.error != null) {
				InternetErrorConnection.SetActive (true);	 

				Debug.Log ("Error in downloading data !");
				yield return new WaitForSeconds (5);
				StartCoroutine (UILabels ());
			} else {
				
                  Debug.Log("Uilabels from API");

//       		      Debug.Log (www.text);


				uiclass	= JsonUtility.FromJson<JsonClassUIlabels> (www.text);

				//InternetErrorConnection.SetActive (false);

				Deserialize (www.text);
				PlayerPrefs.SetString ("Uilabelscache", www.text);
				//LoadingPage.SetActive (false);
			}
		}
	}

	public void Deserialize(string json)
	{


		//ScanpointParent.GetComponentInChildren<Text> ();

		//Scanpoint.text = ScanpointParent.transform.GetChild (0).GetComponent<Text> ().text;
	//Scanpoint.text = Dictionarytxt.text;
//		to assign Name to all ui labels

		foreach (genericsearchviewmodels gsvm  in uiclass.aaData.GenericSearchViewModels) {

			if (gsvm.UserFriendlyCode == "3d_next")
			{
//				Next.text = gsvm.Name;
			}
//			if (gsvm.UserFriendlyCode == "3d_firstname")
//			{
//				Firstnametxt.text = gsvm.Name;
//			}
//			if (gsvm.UserFriendlyCode == "3d_lastname")
//			{
//				Lastnametxt.text = gsvm.Name;
//			}
//			if (gsvm.UserFriendlyCode == "3d_confirmpassword")
//			{
//				confirmpasswordtxt.text = gsvm.Name;
//			}

			if (gsvm.UserFriendlyCode == "3d_subscription")
			{
				Subscriptiont.text = gsvm.Name;
				Subscriptionpage.text = gsvm.Name;
				SubscriptionE.text = gsvm.Name;

			}

			if (gsvm.UserFriendlyCode == "3d_span")
			{
				Spantxt.text = gsvm.Name;
				Spantxt_onemonth.text = gsvm.Name;
			}
			if (gsvm.UserFriendlyCode == "3d_price")
			{
				Pricetxt.text = gsvm.Name;
				Pricetxt_onemonth.text = gsvm.Name;
			}
			if (gsvm.UserFriendlyCode == "3d_restore")
			{
				RestoreText.text = gsvm.Name;
			}
			if (gsvm.UserFriendlyCode == "3d_subscribe")
			{
				Subscribetext.text = gsvm.Name;
				Subscribe_Label_Popup.text = gsvm.Name;
				Subscriptiont_onemonth.text = gsvm.Name;
				SubscribeE.text = gsvm.Name;

			}
			if (gsvm.UserFriendlyCode == "3d_author")
			{
				authortext.text = gsvm.Name;
			}


			if (gsvm.UserFriendlyCode == "3d_description")
			{
				DescriptionS.text = gsvm.Name;
				DescriptionS_onemonth.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_Dictionary")
			{
				Dictionarytxt.text = gsvm.Name;
			}
			
			if (gsvm.UserFriendlyCode == "3d_history") 
			{
				Historytxt.text = gsvm.Name;
			}
			
			if (gsvm.UserFriendlyCode == "3d_biomag")
			{
			//	BioMagHeading.text = gsvm.Name;
			}
			
			if (gsvm.UserFriendlyCode == "3d_Location")
			{
				CPLocation.text = gsvm.Name;
				SPLocation.text = gsvm.Name;
			}
			if (gsvm.UserFriendlyCode == "3d_No") 
			{
				Notxt.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_yes")
			{
				Yestxt.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_privacy")
			{
				Privacy.text = gsvm.Name;
				PrivacyHeading.text = gsvm.Name;
				PrivacySubscription.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_About App") 
			{
				About.text = gsvm.Name;
				AboutHeading.text = gsvm.Name;
			}


			if (gsvm.UserFriendlyCode == "3d_tutorials") 
			{
				Tutorial.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_languages")
			{
				Languages.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_website")
			{
				Website.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_signout")
			{
			//	Signout.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_Are you sure?") 
			{
				arusure.text = gsvm.Name;
			}
			if (gsvm.UserFriendlyCode == "3d_signin") 
			{
				//SignIn.text = gsvm.Name;
			}
//			if (gsvm.UserFriendlyCode == "3d_forgotpassword")
//			{
////				ForgotPassword.text = gsvm.Name;
//				ForgotPasswordinerrorpage.text = gsvm.Name;
//				ForgotPasswordHeading.text = gsvm.Name;
//			}
			if (gsvm.UserFriendlyCode == "3d_Rememberme") 
			{
//				RememberMe.text = gsvm.Name;
			}
			if (gsvm.UserFriendlyCode == "3d_search") 
			{
				Search.text = gsvm.Name;
			}
			if (gsvm.UserFriendlyCode == "3d_Username") 
			{
				//Username.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_Password") 
			{
				//Password.text = gsvm.Name;
				//passwordR.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_Send") 
			{
				//Send.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_OK") 
			{
//				Ok.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_Sign In Error") 
			{
//				Signinerrortxt.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_Errorpassword") 
			{
//				Signinerrormessage.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_Back") 
			{
//				Back.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_interpretation") {
				
				CPInterpretation.text = gsvm.Name;
			}

			if (gsvm.UserFriendlyCode == "3d_germs") {

				CPGerms.text = gsvm.Name;
			}

			if(gsvm.UserFriendlyCode == "3d_emailid"){
			//	Emailid.text = gsvm.Name;
			}


			if(gsvm.UserFriendlyCode == "3d_loading"){
				LoadingPageMessage.text = gsvm.Name;
			}

			if(gsvm.UserFriendlyCode == "3d_Scanpoint")
			{
				ScanpointParent.transform.GetChild (0).GetComponent<Text> ().text = gsvm.Name;
			}

			if(gsvm.UserFriendlyCode == "3d_correspondingpair")
			{
				CorrspondingpairParent.transform.GetChild (0).GetComponent<Text> ().text = gsvm.Name;
			}

			if(gsvm.UserFriendlyCode == "3d_Fieldempty")
			{
				//FillAllFields.text = gsvm.Name;
			}

			if(gsvm.UserFriendlyCode == "3d_forgotpassworderror")
			{
				//PasswdError.text = gsvm.Name;
			}

			if(gsvm.UserFriendlyCode == "3d_passwordsuccess")
			{
				PasswordSuccessfullySent.text = gsvm.Name;
			}
			//for coack marks..............................

			if(gsvm.UserFriendlyCode == "3d_welcome"){
				welcome = gsvm.Name;
				welcometxt.text = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_Swipeleft"){
				swipeleft = gsvm.Name;
				SwipeLeft.text = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_t2"){
				t2 = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_t3"){
				t3 = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_t4"){
				t4 = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_t5"){
				t5 = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_t6"){
				t6 = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_t7"){
				t7 = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_t8"){
				t8 = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_t9"){
				t9 = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_t10"){
				t10 = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_t11"){
				t11 = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_t12"){
				t12 = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_t13"){
				t13 = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_t14"){
				t14 = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_t15"){
				t19 = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_concentric"){
				tconcentric = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_dictionarycoachmarks"){
				tdictionarycoachmarks = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_dictionaryscanpoint"){
				tdictionaryscanpoint = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_dictionarycorresponding"){
				tdictionarycorresponding = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_skip"){
				Skip.text = gsvm.Name;
				SkipSubscription.text = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_connectionerror"){
				interneterrormsg.text = gsvm.Name;
			}

			if(gsvm.UserFriendlyCode == "3d_Guidelines")
			{
				Guidelines.text = gsvm.Name;
				GuidelinesHeading.text = gsvm.Name;
			}

			if(gsvm.UserFriendlyCode == "3d_cancel"){
				Cancel.text = gsvm.Name;
			}

			if(gsvm.UserFriendlyCode == "3d_OK"){
				OK.text = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_restoreconfirmmessage"){
				RestoreMessage.text = gsvm.Name;
			}

			if(gsvm.UserFriendlyCode == "3d_startexploring"){
				StartExploring.text = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_exploremessage"){
				WelcomeMessage.text = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_subscribenow"){
				SubscribeNow.text = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_subscribepopup"){
				SubscriptionInfo.text = gsvm.Name;
			}


			// EXPIRE MESSAGES

			if(gsvm.UserFriendlyCode == "3d_continue"){
				Continue.text = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_continue_message"){
				ContinueMessage.text = gsvm.Name;
			}
			if(gsvm.UserFriendlyCode == "3d_expire_message"){
				ExpireMessage.text = gsvm.Name;
			}

				
	}



	}




}
