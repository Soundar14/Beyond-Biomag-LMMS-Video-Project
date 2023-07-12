//Script is used for checking the subscription valiation/Expiration.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using UnityEngine.UI;

public class SubscriptionExpire : MonoBehaviour {
	public GameObject SubscriptionExpired,StartExploring;
	DateTime expiredate,Currentdate;
	public Text SubscribedParameter;
	void Start(){
//
//
		if (UniversalClass.NoInternetConnection == false) {
			Currentdate	 = DateTime.UtcNow;
		} 
		if (UniversalClass.NoInternetConnection == false) {
			Currentdate = System.DateTime.Now;
		}
		ExpiryCheck ();	

//		if(PlayerPrefs.HasKey("Expiry date")){
//			Debug.Log ("cache present");
//			ExpiryCheck ();	
//		}

	}

	public void SubscriptionClickMonthly()
	{
		Debug.Log ("monthly Subscription");
		var dat = DateTime.UtcNow;
		expiredate = dat.AddMonths(1);
		PlayerPrefs.SetString ("Expiry date", expiredate.ToString());
		Debug.Log (expiredate);
	}


	public void ExpiryCheck()
	{
		
		Currentdate	 = DateTime.UtcNow;

		if (PlayerPrefs.GetString ("Expiry date") != "") {
			
			expiredate = Convert.ToDateTime (PlayerPrefs.GetString ("Expiry date"));
		

			Debug.Log ("Expire date:" + expiredate);

			if (expiredate > Currentdate && expiredate != null) {
				Debug.Log ("Date not Exeeded");

			} else if (expiredate < Currentdate && expiredate != null) {   
				Debug.Log ("Date  Exeeded");   
				PlayerPrefs.DeleteKey ("DisctionaryCache");
				SubscriptionExpired.SetActive (true);
				SubscribedParameter.text = "DEFAULT";
				PlayerPrefs.SetString ("SubscribedParameter", "DEFAULT");
				StartExploring.SetActive (true);
				PlayerPrefs.DeleteKey ("Expiry date");
			}
		}
	}




	public void Disable_SubscriptionExpiredPanel(){
		SubscriptionExpired.SetActive (false);
	}
	public void Continue_SubscriptionExpire(){
		SubscriptionExpired.SetActive (false);
	}

	public void FreeVersion(){
		PlayerPrefs.DeleteKey ("DisctionaryCache");
		PlayerPrefs.SetString ("SubscribedParameter", "DEFAULT");
		SubscribedParameter.text = "DEFAULT";
		StartExploring.SetActive (true);
	}
}



