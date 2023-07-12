using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using LitJson;

public  class UIlablesNew : MonoBehaviour {
//
//	/// ////////////////////////navigation/////////start/////////////////////////////////////////////////////////////////////////////////
//	public Text About;
//	public Text AboutHeading;
//	public Text Privacy;
//	public Text PrivacyHeading;
//	//	public Text TermsConditions;
//	//	public Text TermsConditionsHeading;
//	public Text Languages;
//	public Text Signout;
//	public Text Website;
//	public Text Tutorial;
//	public Text LoadingPageMessage;
//	///////////////////////////navigation//////////end////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	///////////////////////////Login//////////////////////////////////////////////////////////////////////////////////////////////////
//
//	public Text RememberMe;
//	public Text ForgotPassword;
//	public Text ForgotPasswordinerrorpage;
//	public Text SignIn;
//	public Text Username;
//	public Text Password;
//	public Text Send;
//	public Text Ok;
//	public Text Signinerrortxt;
//	public Text Signinerrormessage;
//	public Text Back;
//	// // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//	public Text Dictionarytxt;
//	public Text Historytxt;
//	public Text Search;
//	public Text ScanPointGuide;
//	//	public Text BioMagHeading;
//	// // /////////////////////////////////////DICTIONARY DESCRIPTION PANEL////////////////////////////////////////////////////////////////////////////////
//	public Text CPLocation;
//	public Text CPInterpretation;
//	public Text CPGerms;
//	public Text SPLocation;
//
//	public Text Notxt;
//	public Text Yestxt;
//	public Text arusure;
//	public GameObject  InternetErrorConnection;
//
//	public string UilabelURL = "http://biomagnetictherapy-stg.us-west-2.elasticbeanstalk.com/search/UILabel";
//
//	//	{"request":{"Name":"","AppTypeCode":"2AP7S5","GenericSearchViewModel":{"Name":""}}}
//
//
//	//public string UilabelGetURL= "http://prithiviraj.vmokshagroup.com:9004/UILabels/en";
//	//{"request":{"Name":"","AppTypeCode":"2AP7S5","GenericSearchViewModel":{"Name":""}}}
//
//	string reqLabels = "{'request':{'Name':'','AppTypeCode':'2AP7S5','GenericSearchViewModel':{'Name':''}}}";
//
//	System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
//	public void english()
//
//	{
//		//		
//		//		About.text = "About";
//		//		Privacy.text = "Privacy Policy";
//		//		TermsConditions.text = "Terms and conditions";
//		//		Languages.text = "Languages";
//		//		Signout.text = "Sign Out";
//		////		Website.text = "";
//		//		Tutorial.text = "Tutorial";
//		//		Dictionarytxt.text = "Dictionary";
//		//		RememberMe.text = "Remember Me";
//		//		ForgotPassword.text = "Forgot Password?";
//		//		SPLocation.text = "Location:";
//		//		CPLocation.text = "Location:";
//		//		CPInterpretation.text = "Interpretation:";
//		//		CPGerms.text = "Germs:";
//		//		BioMagHeading.text = "BIO MAG";
//	} 
//
//	public void Spanish()
//	{
//
//		//		About.text = "Acerca de";
//		//		Privacy.text = "Política de privacidad";
//		//		TermsConditions.text = "Términos y Condiciones";
//		//		Languages.text = "Idiomas";
//		//		Signout.text = "Desconectar";
//		//		//Website.text = "";
//		//		Tutorial.text = "Tutoriales";
//		//		Dictionary.text = "Diccionario";
//		//		RememberMe.text = "Recuérdame";
//		//		ForgotPassword.text = "Se te olvidó tu contraseña?";
//	}
//
//
//	public void Start(){
//		StartCoroutine (UILabels ());
//	}
//
//	IEnumerator UILabels()
//	{
//		Dictionary<string, string> headers = new Dictionary<string, string>();
//
//		headers.Add("Content-Type", "application/json");
//		headers.Add("Accept", "application/json");
//
//
//		WWW www = new WWW(UilabelURL, encoding.GetBytes(reqLabels), headers);
//		yield return www;
//
//		if (www.error != null)
//		{
//			InternetErrorConnection.SetActive (true);	 
//			Debug.Log("Error in downloading data !");
//			yield return new WaitForSeconds (5);
//			StartCoroutine (UILabels ());
//		}
//		else
//		{
//			//	Debug.Log(www.text);
//
//			Deserialize (www.text);
//			InternetErrorConnection.SetActive (false);	 
//		}
//	}
//
//	public void Deserialize(string json)
//	{
//		UIlablesWrapper wrapperuil = new UIlablesWrapper();
//		wrapperuil.uilablesResponse = JsonMapper.ToObject<UIlablesResponse> (json);
//		//		to assign Value to all ui labels
//		foreach (genericsearchviewmodels gsvm  in wrapperuil.uilablesResponse.aaData.GenericSearchViewModels) {
//
//
//			if (gsvm.Name == "3d_Dictionary")
//			{
//				Dictionarytxt.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_history") 
//			{
//				Historytxt.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_biomag")
//			{
//				//	BioMagHeading.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_Location")
//			{
//				CPLocation.text = gsvm.Value;
//				SPLocation.text = gsvm.Value;
//			}
//			if (gsvm.Name == "3d_No") 
//			{
//				Notxt.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_yes")
//			{
//				Yestxt.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_privacy")
//			{
//				Privacy.text = gsvm.Value;
//				PrivacyHeading.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_About App") 
//			{
//				About.text = gsvm.Value;
//				AboutHeading.text = gsvm.Value;
//			}
//
//			//			if (gsvm.Name == "3d_Terms & Conditions")
//			//			{
//			//				TermsConditions.text = gsvm.Value;
//			//				TermsConditionsHeading.text = gsvm.Value;
//			//			}
//
//			if (gsvm.Name == "3d_tutorials") 
//			{
//				Tutorial.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_languages")
//			{
//				Languages.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_website")
//			{
//				Website.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_signout")
//			{
//				Signout.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_Are you sure?") 
//			{
//				arusure.text = gsvm.Value;
//			}
//			if (gsvm.Name == "3d_signin") 
//			{
//				SignIn.text = gsvm.Value;
//			}
//			if (gsvm.Name == "3d_forgotpassword")
//			{
//				ForgotPassword.text = gsvm.Value;
//				ForgotPasswordinerrorpage.text = gsvm.Value;
//			}
//			if (gsvm.Name == "3d_Rememberme") 
//			{
//				RememberMe.text = gsvm.Value;
//			}
//			if (gsvm.Name == "3d_search") 
//			{
//				Search.text = gsvm.Value;
//			}
//			if (gsvm.Name == "3d_Username") 
//			{
//				Username.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_Password") 
//			{
//				Password.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_Send") 
//			{
//				Send.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_OK") 
//			{
//				Ok.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_Sign In Error") 
//			{
//				Signinerrortxt.text = gsvm.Name;
//			}
//
//			if (gsvm.Name == "3d_Errorpassword") 
//			{
//				Signinerrormessage.text = gsvm.Value;
//			}
//
//			if (gsvm.Name == "3d_Back") 
//			{
//				Back.text = gsvm.Value;
//			}
//		}
//
//
//
//	}
//
//
//
//
}