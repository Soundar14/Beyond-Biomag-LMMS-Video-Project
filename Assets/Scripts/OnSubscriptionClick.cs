//Handle the Onclick subscritption.Opens the subscription panel.
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OnSubscriptionClick : MonoBehaviour {

	public GameObject SubscriptionPanel,loadingscreen,SubscriptionExpiredMessage;
	public Text Status;
	public GameObject restore;
	

    public void OnSubscriptionSuccess(){
		Status.text = "Subscription was successful";
		OnSubscriptionBack ();
		//SubscriptionPanel.SetActive (false);
		loadingscreen.SetActive (false);
	}

	public void OnSubscriptionBack(){

		UniversalClass.UIPanelEnabled = false;
		SubscriptionPanel.GetComponent<CanvasGroup> ().alpha = 0; 
		SubscriptionPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		SubscriptionPanel.GetComponent<CanvasGroup> ().interactable = false;
        //SubscriptionPanel.SetActive(false);
    }
	public void OnEnable(){
		Debug.Log ("Subscription Enabled");  
	}

	public void OnDisable(){
		Debug.Log ("Subscription Disabled");   
	}

	public void SubscriptioExpired(){

		SubscriptionPanel.GetComponent<CanvasGroup> ().alpha = 1; 
		SubscriptionPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		SubscriptionPanel.GetComponent<CanvasGroup> ().interactable = true;
//		UniversalClass.SubScriptionPaneEnabled = true;
//		SubscriptionExpiredMessage.SetActive (true);
//		StartCoroutine (waiting ());
	}

	public void RestorePopUp(){
		restore.SetActive (true);
	}

	public void RestorePopUpOff(){
		restore.SetActive (false);
	}


		IEnumerator waiting(){
			yield return new WaitForSeconds (4);
		SubscriptionExpiredMessage.SetActive (false);

		}
}
