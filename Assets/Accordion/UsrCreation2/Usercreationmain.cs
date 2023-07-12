using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Usercreationmain : MonoBehaviour 
{
	UCJsonclass  usjclass = new UCJsonclass();
	public Text Username,Emailid,deviceID;
	string UsercreationURl =  UniversalClass.BaseUrl+"/User3d/0";
	// Use this for initialization
	public string request,uniqueID;

	public UCJsonclass ucjsonclass = new UCJsonclass (); 

	System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

	void Start () {
		 uniqueID = SystemInfo.deviceUniqueIdentifier;
		deviceID.text = uniqueID.ToString ();
	}

	public void TocallApi(){
		
		request = "{'request':{'Id':'0','Email':'" + Emailid.text + "',"+"'FirstName':'','MiddleName':'','LastName':'',"+"'Username':'" + Username.text + "','Status':true,'PreferredLanguageCode':'en','AppTypeCode':'2AP7S5','ApplicableVersionCode':'KP18Z7','RoleCode':'7O1192','UserTypeCode':'2SQ6A3','Password':'Power@1234','CompanyCode':'A0I7LV','UserID':20025,'MethodType':'POST','Registered':true,'DeviceId':'" + deviceID.text + "'}}";
        Debug.Log("Request: "+ request);
		StartCoroutine (ToStartUsercreation ());

	}

	IEnumerator ToStartUsercreation()
	{
		Dictionary<string, string> headers = new Dictionary<string, string>();

		headers.Add("Content-Type", "application/json");
		headers.Add("Accept", "application/json");
		headers.Add("x-User", "20025");
		headers.Add("x-AppType", "2AP7S5");
		headers.Add("x-ApplicableVersion", "KP18Z7");
		headers.Add("x-Trans-token", "SR67TUL47EK");




		WWW www = new WWW(UsercreationURl, encoding.GetBytes(request), headers);

		yield return www;

		if (www.error != null)
		{
			Debug.Log("Error in downloading data !");

		}
		else
		{
//						Debug.Log(www.text);
			Deserialize (www.text);

		}

	}

	public void Deserialize(string Userdata)
	{

		ucjsonclass	 =  JsonUtility.FromJson<UCJsonclass> (Userdata);
		Debug.Log(ucjsonclass.aaData.Message);
}
}
