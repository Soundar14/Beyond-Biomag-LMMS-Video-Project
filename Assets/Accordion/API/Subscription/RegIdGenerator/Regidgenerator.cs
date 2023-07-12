using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using LitJson;

public class Regidgenerator : MonoBehaviour {

	//string RegidURL =  "http://biomagnetictherapy-stg.us-west-2.elasticbeanstalk.com/GetRegistrationCode";
	string RegidURL =  "http://35.165.231.81/GetRegistrationCode";
	public RegidgeneratJsonclass rgId = new RegidgeneratJsonclass();

	public string UserRequest = "";
	public Text RegID;

	System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

	// Use this for initialization
	void Start () {
		StartCoroutine (usercreation ());
	}

	IEnumerator usercreation()
	{
		Dictionary<string, string> headers = new Dictionary<string, string>();

		headers.Add("Content-Type", "application/json");
		headers.Add("Accept", "application/json");



		//	WWW www = new WWW(UserCreationURL, null, headers);    // for get urls no request

		WWW www = new WWW(RegidURL, encoding.GetBytes(UserRequest), headers);

		yield return www;

		if (www.error != null)
		{
			Debug.Log("Error in downloading data !");
			yield return new WaitForSeconds (5);
			StartCoroutine (usercreation ());


		}
		else
		{
//      Debug.Log(www.text);
			Deserialize (www.text);

		}

	}
	public void Deserialize(string Regiddetails)
	{
		
		rgId =  JsonUtility.FromJson<RegidgeneratJsonclass> (Regiddetails);
		RegID.text = rgId.aaData.NewRegistrationId;

	}





}
