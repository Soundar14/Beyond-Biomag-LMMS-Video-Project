//Handles the Authentication API and functionality.Currently there is not registration screen. Login credentials are static.
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using LitJson;
using System.Text.RegularExpressions;
public class LoginA : MonoBehaviour 
{

	public Text BaseURL;
	public Button forgotpasswordbtn;


	 string LoginURL = UniversalClass.BaseUrl+"/account/Authenticate";

	string ForgotPasswordURL = UniversalClass.BaseUrl+"/User/ForgotPassword/Email";

	public LanguagesApi LangApi;
	public string req = "";
	public string Forgotreq = "";
	public string data = "";
	public GameObject SubScripptionPage;
	public GameObject loadingPage;
	public bool RemeberMe;
	public GameObject ForgotpasswordPanel;
	public GameObject FieldEmptyPanel , PasswordSuccessPanel,PasswordFailPanel;
	public Text message;
	public IAP_Status LoginButtonIAP;
	//public UserDetailsView userDetailsView;

	public InputField username;
	public InputField password;
	public string AppTypeCode;
	public string ApplicableVersionCodeApi;
	public Text ApplicableVersionCodeTxt;
	public InputField ForgotPasswordEmail;
	public bool checkingB;
	public ScanPointPlayer splayer;
	public LoadScanPoints LSP;
	public GameObject maleScanpoints;
	public GameObject FemaleScanpoints;
	AnimatorAssembly animateAssmble;

	public string UserLanguageCode;
	public Text LanguageCode;
	public string ApplicableVersionCode;
	public string UserID;
	public Text UserIdTxt;
	public UIlables UIlab;
	public Config Configuration;

	AAData checking = new AAData();
	LoginJsonClass loginjsonclass = new LoginJsonClass ();
	forgotpasswordjasonclass fp = new forgotpasswordjasonclass();
	public const string MatchEmailPattern =@"[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

	System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

	/*private static LoginA Instance;
	
	public static LoginA instance
	{
		get
		{
			if(Instance == null)
				return GameObject.FindObjectOfType<LoginA>();
			
			return Instance;
		}
	}*/


	// Use this for initialization
	//public Dictionary<string, List<UserDetailsView>> UserdetailView_Dict = new Dictionary<string, List<UserDetailsView>>();
	//public Dictionary<string, List<UserDetailsClass>> UserdetailClass_Dict = new Dictionary<string, List<UserDetailsClass>>();
	void Start () {
		if (PlayerPrefs.HasKey ("UserName")) {
			username.text = PlayerPrefs.GetString ("UserName");
			//password.text = PlayerPrefs.GetString ("Password");
		}

//		ForgotpasswordPanel.SetActive (false);
		checkingB = true;
		animateAssmble = GameObject.Find ("AnimatorControllerObject").GetComponent<AnimatorAssembly> ();
		//		if (PlayerPrefs.HasKey ("UserName") ) {
		//			username.text = PlayerPrefs.GetString ("UserName");
		//			password.text = PlayerPrefs.GetString ("Password");
		//		}
	}

	public void CheckLoginAuthentication(){

		//Debug.Log(PlayerPrefs.GetInt("loginstatus"));

		if (username.text.Length > 0) {
			
			//loadingPage.SetActive (true);



			animateAssmble.PlayLoginAnimation ();



			string a = "{     'request':{     'Username':'" + username.text + "', 'Password':'" + password.text + "'," +
				"'AppTypeCode':'" + AppTypeCode + "', 'ApplicableVersionCode':'" + ApplicableVersionCode + "'     }     }";
			req = a;
			//StartCoroutine (LoginD ());

		}
		else 
		{
			FieldEmptyPanel.SetActive (true);
			StartCoroutine(popupmsg ());
			//message.text = "";
		}




		//		StartCoroutine (waiting ());
		//		splayer.FindScanPointPivot ();

	}

	//	IEnumerator waiting(){
	//		yield return new WaitForSeconds (4);
	//	//	splayer.FindScanPointPivot ();
	//	}

	void Update()
	{

		checkingB = checking.Success; 

		if (Input.GetKey(KeyCode.Escape) )
		{
			Application.Quit();
			
		}

	}

	IEnumerator LoginD()
	{
		Dictionary<string, string> headers = new Dictionary<string, string>();

		        headers.Add("Content-Type", "application/json");
	         	headers.Add("Accept", "application/json");


		WWW www = new WWW(LoginURL, encoding.GetBytes(req), headers);

		yield return www;

		if (www.error != null)
		{
			Debug.Log("Error in downloading data !");
			loadingPage.SetActive (false);
		}
		else
		{
//				Debug.Log(www.text);
			Deserialize (www.text);

		}

	}
	/// <summary>
	/// //////////////////////////// FORGOT PASSWORD SENDING REQUEST/ ///////////////START//////////////////////////////////////
	/// </summary>

	IEnumerator forgotpassword()
	{
		Dictionary<string, string> headersF = new Dictionary<string, string>();


		headersF.Add("Content-Type", "application/json");
		headersF.Add("Accept", "application/json");



		WWW www = new WWW(ForgotPasswordURL, encoding.GetBytes(Forgotreq), headersF);

		yield return www;

		if (www.error != null)
		{
			Debug.Log("Error in downloading data !");
			loadingPage.SetActive (false);
		}
		else
		{
			//Debug.Log(www.text);
			Deserializef (www.text);
			fp = JsonUtility.FromJson<forgotpasswordjasonclass> (www.text);
			Debug.Log(fp.aaData.Message);
			//	message.text = fp.Message;


		}
	}


	/////////////////////////////// FORGOT PASSWORD SENDING REQUEST/ ///////////////END//////////////////////////////////////



	public void Deserialize(string LoginData)
	{

		loginjsonclass =  JsonUtility.FromJson<LoginJsonClass> (LoginData);

		//		Debug.Log ("Token :"+ wrapperL.loginResponse.aaData.Success);

		if ( loginjsonclass.aaData.Success == true ) {


			PlayerPrefs.DeleteKey ("Uilabelscache");// to delete uilabels cache before login
			PlayerPrefs.DeleteKey("LanguagesList");// to delet list of languages cache
			PlayerPrefs.DeleteKey ("Configuration");//to delete configuration cache

			//PlayerPrefs.SetInt("loginstatus",1);

			UserLanguageCode = loginjsonclass.aaData.UserDetailsViewModel.PreferredLanguageCode;
			 
			UserID = loginjsonclass.aaData.UserDetailsViewModel.Id.ToString();
			UserIdTxt.text = UserID;

			ApplicableVersionCodeApi = loginjsonclass.aaData.UserDetailsViewModel.ApplicableVersionCode;
			ApplicableVersionCodeTxt.text = ApplicableVersionCodeApi;

			PlayerPrefs.SetString("LangCode", UserLanguageCode);//TO CACHE USER PREFERED LANGUAGE
			LanguageCode.text = UserLanguageCode;

			/// CALLING API AFTER LOGIN SUCCESSFUL//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			Debug.Log ("Config started login");

			Configuration.OnLanguageChange ();
			UIlab.OnLanguageChange ();

			UserID = loginjsonclass.aaData.UserDetailsViewModel.Id.ToString();
			UserIdTxt.text = UserID;

			LSP.ToStartApiCall ();

			PlayerPrefs.SetString ("userid", UserID);
			PlayerPrefs.SetString ("applicableversioncode", ApplicableVersionCodeApi);

			LangApi.ToStartLanguageAPI ();

			LoginButtonIAP.ToAddIAP ();
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


			if (RemeberMe) {
				PlayerPrefs.SetString ("UserName", username.text);
				//PlayerPrefs.SetString ("Password", password.text);
			}
			if (RemeberMe == false) {
				username.text = "";
				password.text = "";
				PlayerPrefs.DeleteKey ("UserName");
			}

			animateAssmble.PlayLoginAnimation ();
			//loadingPage.SetActive (false);
		} else  {
			loadingPage.SetActive (false);
			//ForgotPasswordPage.SetActive (true);

		}

	}

	public void Deserializef(string ForgotData)
	{

		fp = JsonUtility.FromJson<forgotpasswordjasonclass> (ForgotData);
		Debug.Log(fp.aaData.Success);

		if (fp.aaData.Success == true) {
		
			PasswordSuccessPanel.SetActive (true);
			StartCoroutine (PasswordSuccess ());
			ForgotPasswordEmail.text = "";
		} else {
		
			PasswordFailPanel.SetActive (true);
			StartCoroutine (PasswordFail ());
		}


	}


	public void remeBerMeFunction(){
		RemeberMe = !RemeberMe;
		//Debug.Log (RemeberMe);
	}

	public void ForgotPassword(){


		if (ForgotPasswordEmail.text.Length > 0 && ForgotPasswordEmail.text.Contains("@")) 
		{ 

			string ForgotUsername ="{'request':{'email':'"+ ForgotPasswordEmail.text +"','RegistrationId':'','UserTypeCode':'2SQ6A3'}}";



			Forgotreq = ForgotUsername;
			StartCoroutine (forgotpassword ());

			ForgotpasswordPanel.SetActive (false);



		}
		else if(ForgotPasswordEmail.text.Contains("@"))
		{
			//FieldEmptyPanel.SetActive (true);
			//StartCoroutine(popupmsg ());
			//message.text = "";
		}
	}



	IEnumerator popupmsg() //for field is empty user name password
	{
		yield return new WaitForSeconds (3);
		//message.text = "Field is empty";
		FieldEmptyPanel.SetActive (false);
		//	message.text = "";

	}

	IEnumerator PasswordSuccess() // Forgot password sent successfully
	{
		yield return new WaitForSeconds (3);
		//message.text = "Field is empty";
		PasswordSuccessPanel.SetActive (false);
		//	message.text = "";

	}

	IEnumerator PasswordFail() // Forgot password sent fail
	{
		yield return new WaitForSeconds (3);
		//message.text = "Field is empty";
		PasswordFailPanel.SetActive (false);
		//	message.text = "";

	}

	public void Skip(){
		animateAssmble.PlayLoginAnimation ();
	}



	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////









}

