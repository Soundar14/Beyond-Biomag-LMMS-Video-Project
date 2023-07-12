//Scripts handles the email input validation
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class EmailValidationMain : MonoBehaviour {
	//public Text BaseURL;

	string EmailValidationURL = UniversalClass.BaseUrl+"/EmailValidation";
	public bool PasswordCorrect,EmailCorrect = false;
	public string req = "";
	public GameObject LoadingScreen,FieldEmpty,RegistrationPanel,SubscriptionPanel,invalidEmailInfo,PasswordMismatch;
	//public Text EmailID,Firstname,Lastname;
	public InputField Password,Reenterpass;
	public Text emailtxt,Emailid,Username;
	public Button Next;
	public const string MatchEmailPattern =@"[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

	System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

	EmailValidationJsonclass emv = new EmailValidationJsonclass ();
	public void Update(){
//	
//		if (Emailid.text.Length > 0 && EmailCorrect == true) {
//			Next.interactable = true;
//		} else {
//			Next.interactable = false;
//		}
//
	}
//	public void ToStartValidation(){
////		
////		if (Firstname.text.Length > 0 && Lastname.text.Length > 0 && EmailID.text.Length > 0 && Password.text.Length > 0 && Reenterpass.text.Length > 0)
////		{
////
////			if (EmailCorrect == true && PasswordCorrect == true) {
////				Debug.Log ("Correct reg");
////				StartCoroutine (Validation ());
////			}
////
////		} else {
////			StartCoroutine (fieldempty ());
////		}
//	}

//	IEnumerator Validation()
//	{
//		req = "{'request':{'Email': '"+EmailID.text+"','AppTypeCode': '2AP7S5'}}";
//			
//		LoadingScreen.SetActive (true);
//		Dictionary<string, string> headersF = new Dictionary<string, string>();
//
//
//		headersF.Add("Content-Type", "application/json");
//		headersF.Add("Accept", "application/json");
//
//
//
//		WWW www = new WWW(EmailValidationURL, encoding.GetBytes(req), headersF);
//
//		yield return www;
//
//		if (www.error != null) {
//			Debug.Log ("Error in downloading data !");
//		}
//
//		else
//		{
//			Debug.Log(www.text);
//			emv = JsonUtility.FromJson<EmailValidationJsonclass> (www.text);
//			Deserialize (www.text);
//			
//
//
//		}
//	}
//
//	public void Deserialize(string ValidationData)
//	{
//
//		emv =  JsonUtility.FromJson<EmailValidationJsonclass> (ValidationData);
//		if (emv.aaData.IsValid == true) {
//			
//			LoadingScreen.SetActive (false);
//			RegistrationPanel.SetActive (false);
//
//			SubscriptionPanel.GetComponent<CanvasGroup> ().alpha = 1; 
//			SubscriptionPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
//			SubscriptionPanel.GetComponent<CanvasGroup> ().interactable = true;
//		//	UniversalClass.SubScriptionPaneEnabled = true;
//		}
//
//		if (emv.aaData.IsValid == false) {
//
//			LoadingScreen.SetActive (false);
//			StartCoroutine (InvalidEmail ());
//			emailtxt.color = Color.red;
//		}
//
//
//	}

	IEnumerator fieldempty(){
		
		FieldEmpty.SetActive (true);

		yield return new WaitForSeconds (3);

		FieldEmpty.SetActive (false);

	}

	IEnumerator InvalidEmail(){

		invalidEmailInfo.SetActive (true);

		yield return new WaitForSeconds (3);

		invalidEmailInfo.SetActive (false);

	}

//	IEnumerator EPasswordMismatch(){
//
//		PasswordMismatch.SetActive (true);
//
//		yield return new WaitForSeconds (3);
//
//		PasswordMismatch.SetActive (false);
//
//	}

//
//	public void ToGoToLogin(){
//		
//		RegistrationPanel.SetActive (false);
//		SubscriptionPanel.SetActive (false);
//	}
	public void IsEmail()
	{
		
		//TO CHECK IF EMAIL ID IN CORRECT FORMAT
		if (Regex.IsMatch (Emailid.text, MatchEmailPattern)) {
			EmailCorrect = true;
		}
			else
			{
				Debug.Log("Invalid Email");
			StartCoroutine (InvalidEmail ());
			EmailCorrect = false;
			}
		}

	public void ToEnableButton()
	{
		if (Username.text.Length > 1) {
			Next.interactable = true;
		} else {
			Next.interactable = false;
		}
	
	}
	//
//
//	public void PasswordCheck()
//
//	{
//		if (Password.text != Reenterpass.text ) {
//			StartCoroutine (EPasswordMismatch ());
//
//		}
//		if (Password.text == Reenterpass.text && Password.text.Length > 0) {
//			
//			PasswordCorrect = true;
//		} else {
//			PasswordCorrect = false;  
//		}
//
//}
}



