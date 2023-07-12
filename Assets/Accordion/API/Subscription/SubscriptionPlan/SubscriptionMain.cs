//Script Handle the Main Subscription (IAP) of the application.
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SubscriptionMain : MonoBehaviour {

	public Text SSpan,SPrice,Sname,Description;
	public Text S_MonthSpan,S_MonthPrice,S_Monthname,Month_Description;
	string subURL = UniversalClass.BaseUrl+ "/search/SubscriptionData";
	public Text LanguageCode;
	public string req;
	public Transform Subscriptionpanel;
	public Transform SubscriptionMainPanel;

	System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

	private SubscriptionJsonclass sbclass = new SubscriptionJsonclass ();

	//public string jsonString;
	// Use this for initialization
	void Start () {

		LanguageCode = LoadScanPoints.instance.Languagecode;
		StartCoroutine (subD ());

	}
	// Use this for initialization
	public void startApi () {
		StartCoroutine (subD ());
	}
    //Function to check the subscription, based on that display the all Pairs.
	IEnumerator subD()
	{
		//	{    'request':{   'LanguageCode': 'en',   'AppTypeCode': '2AP7S5'     } }
		req = "{    'request':{   'LanguageCode': '" +LanguageCode.text+"',   'AppTypeCode': '2AP7S5'     } }"; 

		Dictionary<string, string> headers = new Dictionary<string, string>();

		headers.Add("Content-Type", "application/json");
		headers.Add("Accept", "application/json");




		WWW www = new WWW(subURL, encoding.GetBytes(req), headers);

		yield return www;

		if (www.error != null)
		{
			Debug.Log("Error in downloading data !");
			yield return new WaitForSeconds (10);
			StartCoroutine (subD ());

		}
		else
		{
			//Debug.Log(www.text);
			sbclass = JsonUtility.FromJson<SubscriptionJsonclass> (www.text);

			//Debug.Log (sbclass.aaData.GenericSearchViewModels[1].SubscriptionName);
			Deserialize (www.text);

		}

	}

	public void Deserialize(string json)
	{
		foreach (GenricViewModelClass gsvm in sbclass.aaData.GenericSearchViewModels) {
			if (gsvm.ProductIdentifier == "BeyondBioMag3D_Basic_1yr") {

				Debug.Log (gsvm.SubscriptionPrice);
				Sname.text = gsvm.Name;
				SSpan.text =  gsvm.SubscriptionSpanType;
				SPrice.text =  gsvm.SubscriptionPrice+" "+ gsvm.CurrencyCode;
				Description.text = gsvm.Description;
			}

			if (gsvm.ProductIdentifier == "BeyondBioMag3D_Basic_1mth") {

				Debug.Log (gsvm.SubscriptionPrice);
				S_Monthname.text = gsvm.Name;
				S_MonthSpan.text =  gsvm.SubscriptionSpanType;
				S_MonthPrice.text =  gsvm.SubscriptionPrice+" "+ gsvm.CurrencyCode;
				Month_Description.text = gsvm.Description;

			}

            //			Transform SubscriptionPanel = Instantiate (Subscriptionpanel);
            //
            //		    Subscriptionpanel.GetChild (0).GetComponent<Text> ().text = gsvm.SubscriptionName;
            //			Subscriptionpanel.GetChild (1).GetComponent<Text> ().text = gsvm.SubscriptionSpanType;
            //			Subscriptionpanel.GetChild (2).GetComponent<Text> ().text = gsvm.SubscriptionPrice;
            //			Subscriptionpanel.GetChild (3).GetComponent<Text> ().text = gsvm.ProductIdentifier;
            //
            //			SubscriptionPanel.transform.SetParent(SubscriptionMainPanel.transform,false);

		}
	}
}
