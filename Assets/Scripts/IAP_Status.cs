//Script to handle the Subscription status
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IAP_Status : MonoBehaviour {

	public Text Status;
	public GameObject SubscriptionPanel;

	public void Start(){
		if (PlayerPrefs.GetInt ("loginstatus") == 1) {
			ToAddIAP ();
		}
	}

		
	public void statusCheckValid(){
		Status.text = "Subscription is Valid";          
	}

	public void statusCheckFaild(){
		Status.text = "Subscription is failed";      
		UniversalClass.SubScriptionValid = false;
		SubscriptionPanel.SetActive (true);
	}

	public void ToAddIAP(){

	//	IapStatus.GetComponent<UnityEngine.Purchasing.IAPButton> ()
//	gameObject.GetComponent<UnityEngine.Purchasing.IAPButton> ().enabled = true;
	}
}

