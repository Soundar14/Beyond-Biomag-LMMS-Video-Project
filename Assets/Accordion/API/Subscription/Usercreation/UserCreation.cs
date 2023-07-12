//Script handle multiple functionality of the application.Handles screen activation and initializaition of Seed API.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using LitJson;

public class UserCreation : MonoBehaviour {
	//public Text BaseURL;
	string UserCreationURL =  UniversalClass.BaseUrl+ "/User/0";
	public EmailValidationMain emailValid;
	public string UserRequest = "";
	public InputField Firstname;
	public InputField Lastname;
	public InputField EmailID;
	public InputField Password;
	public InputField Reenterpass;
	public InputField LoginEmailID, LoginPassword;
	public Text TransactionId;
	public Text SubscriptionCode;
	public GameObject SubScriptionPanel,popuppanel,SubscriptionButton;
	public Text RegistrationID;
	public Text message;
	public GameObject Usercreationpanel,loadingscreen;
	public GameObject PanelSuccess;
	public int Count = 0;
	public Text TimeZone,UTCTime;



	public UsercreationJsonclass uscreation = new UsercreationJsonclass();

	System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
	public void Start(){
		//Resgister ();

	}

	public void activatingusercreation()
	{
		Usercreationpanel.SetActive (true);
		SubScriptionPanel.SetActive (true);
	}

	public void dactivatingusercreation()
	{
		Usercreationpanel.SetActive (false);
	}
	IEnumerator usercreation()
	{
		
		Dictionary<string, string> headers = new Dictionary<string, string>();

		headers.Add("Content-Type", "application/json");
		headers.Add("Accept", "application/json");

		if (Count >= 5) {
			
			loadingscreen.SetActive (false);
		}


		Count = Count + 1;
	//	WWW www = new WWW(UserCreationURL, null, headers);    // for get urls no request

		WWW www = new WWW(UserCreationURL, encoding.GetBytes(UserRequest), headers);

		yield return www;

		if (www.error != null && Count <= 5)
		{
			Debug.Log("Error in downloading data !");

			StartCoroutine (usercreation ());


		}
		else
		{
				        Debug.Log(www.text);
                        Deserialize (www.text);

		}

	}

	public void Deserialize(string UserCData)
	{

		uscreation =  JsonUtility.FromJson<UsercreationJsonclass> (UserCData);

		message.text =	uscreation.aaData.Message;
			
		popuppanel.SetActive (true);
		StartCoroutine (popupmsg ());

		if (uscreation.aaData.Success == true) {
			//UniversalClass.isRegistered = true;


			SubScriptionPanel.GetComponent<CanvasGroup> ().alpha = 0; 
			SubScriptionPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			SubScriptionPanel.GetComponent<CanvasGroup> ().interactable = false;
//			UniversalClass.SubScriptionPaneEnabled = false;

			loadingscreen.SetActive (false);
			LoginEmailID.text = EmailID.text;
			LoginPassword.text = Password.text;

			//To Clear Details in RegistrationPage
			EmailID.text = "";
			Password.text = "";
			Reenterpass.text = "";
			Firstname.text = "";
			Lastname.text = "";
			///////////////////////////////////////
		}
	}

	public void Resgister()
	{
		if (emailValid.EmailCorrect == true) {
			UTCTime.text = System.DateTime.UtcNow.ToString ();
			TimeZone.text = System.TimeZone.CurrentTimeZone.StandardName.ToString ();
			Debug.Log ("Registration");
			//{'request':{'Id':'0','FirstName':'cdzdecdec','MiddleName':'','LastName':' xcdscdsc','DOB':'','Email':'vmoksha.ios@gmail.com','Username':'vmoksha.ios@gmail.com','Status':true,'PreferredLanguageCode':'en','AppTypeCode':'2AP7S5|KP18Z7','ApplicableVersionCode':'','RoleCode':'7O1192','UserTypeCode':'2SQ6A3','Password':'Power@1234','CompanyCode':'VM001','UserID':10034,'MethodType':'POST','SubscriptionData':'{\'Amount\':9,\'Fee\':9,\'TransactionId\':\'501982c5-978c-4260-b94a-0384458c6fe7\',\'SubscriptionDetailsCode\':\'BioMag3D_Basic_1yr\',\'ExpiryDate\':\'2017-08-25 16:46:57.847\',\'TimeZoneCode\':\'New Text\'}'}}
			///string a = "bhuwan"+@"\";
			//bhuwan\
			//{'request':{'Id':'0','FirstName':'ad','MiddleName':'ad','LastName':'xv','DOB':'','Email':'ap@jbvfjk.com','Username':'ap@jbvfjk.com','Status':true,'PreferredLanguageCode':'en','AppTypeCode':'2AP7S5|KP18Z7','ApplicableVersionCode':'','RoleCode':'7O1192','UserTypeCode':'2SQ6A3','Password':'1234','CompanyCode':'VM001','UserID':10034,'MethodType':'POST',                                                                                                                       'SubscriptionData':'{\'Amount\':9,\'Fee\':9,\'TransactionId\':\'dsfcef4534rcfdgfc4cdg\',\'SubscriptionDetailsCode\':\'BioMag3D_Advanced_1mth\',\'ExpiryDate\':\'2017-08-25 16:46:57.847\',\'TimeZoneCode\':\'ZI39C1\'}'}}
			UserRequest = "{'request':{'Id':'0','FirstName':'" + Firstname.text + "','MiddleName':'','LastName':' " + Lastname.text + "','DOB':'','Email':'" + EmailID.text + "','Username':'" + EmailID.text + "','Status':true,'PreferredLanguageCode':'en','AppTypeCode':'2AP7S5|KP18Z7','ApplicableVersionCode':'','RoleCode':'7O1192','UserTypeCode':'2SQ6A3','Password':'" + Password.text + "','CompanyCode':'VM001','UserID':10034,'MethodType':'POST','SubscriptionData':'{" + @"\" + "'Amount" + @"\" + "':9," + @"\" + "'Fee" + @"\" + "':9," + @"\" + "'TransactionId" + @"\" + "':" + @"\" + "'" + TransactionId.text + @"\" + "'," + @"\" + "'SubscriptionDetailsCode" + @"\" + "':" + @"\" + "'" + SubscriptionCode.text + @"\" + "'," + @"\" + "'ExpiryDate" + @"\" + "':" + @"\" + "'" + UTCTime.text + @"\" + "'," + @"\" + "'TimeZoneCode" + @"\" + "':" + @"\" + "'" + TimeZone.text + @"\" + "'}'}}";

			//System.TimeZone.CurrentTimeZone.StandardName;

			StartCoroutine (usercreation ());
			//SubScriptionPanel.SetActive (false);
			//}
//
//			else if (Password.text != Reenterpass.text) 
//			{
//				popuppanel.SetActive (true);
//				StartCoroutine (popupmsg ());
//				message.text = "Password does not match";
//				//SubScriptionPanel.SetActive (false);
//			}

	     
//		} else {
//			popuppanel.SetActive (true);
//			StartCoroutine (popupmsg ());
			//}

	
		}
}

	IEnumerator popupmsg()
	{
		yield return new WaitForSeconds (3);
		message.text = "Please fill in all the Fields";
		popuppanel.SetActive (false);
		//	message.text = "";

	}

	public void ToActivateSubScreen(){
		
		SubScriptionPanel.GetComponent<CanvasGroup> ().alpha = 1; 
		SubScriptionPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		SubScriptionPanel.GetComponent<CanvasGroup> ().interactable = true;
		SubscriptionButton.SetActive (true);
		UniversalClass.UIPanelEnabled = true;

	}

	public void ToDeactivateSubScreen(){

		SubScriptionPanel.GetComponent<CanvasGroup> ().alpha = 0; 
		SubScriptionPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		SubScriptionPanel.GetComponent<CanvasGroup> ().interactable = false;
		SubscriptionButton.SetActive (false);
		UniversalClass.UIPanelEnabled = false;

	}
}
