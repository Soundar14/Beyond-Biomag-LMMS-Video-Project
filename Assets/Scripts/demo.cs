// Script handle the basic initialisation which includs the usercreation and subscription.Handles the screen loading.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class demo : MonoBehaviour {

	public UserCreation Usercreation;
	public GameObject SubScriptionPanel;
	public GameObject LoadingScreen, TestPanel,Terms,WelcomePanel; 
	public bool Firstime = true;
	public Toggle IAgree;
	public Button OK;
	public Text SubscribedParameter;

	void Start () {
		
		Usercreation =  GameObject.Find ("USERCREATION").GetComponent<UserCreation> ();
		SubscribedParameter = GameObject.Find ("SubscribedParameter").GetComponent<Text>();    
    }

    //AfterSuccessfulSubscription handle the loading activity.Set the Subscription value to display all Pairs.
    public void AfterSuccessfulSubscription()
	{	
		SubscribedParameter.text = "KP18Z7";
		PlayerPrefs.SetString ("SubscribedParameter", "KP18Z7");
		PlayerPrefs.DeleteKey ("DisctionaryCache");
		WelcomePanel.SetActive (true);
		if (PlayerPrefs.GetInt ("loginstatus") == 1) {
			LoadingScreen.SetActive (false);
		} else {
			LoadingScreen.SetActive (false);
			WelcomePanel.SetActive (true);
		}
	}

    //FailureOfSubscription handle the loading activity.Set the Subscription value to default i.e 25 pairs only.
    public void FailureOfSubscription()
	{
		Debug.Log ("Subscription failed");
		LoadingScreen.SetActive (false);
		SubscribedParameter.text = "DEFAULT";
		PlayerPrefs.DeleteKey ("DisctionaryCache");
		PlayerPrefs.SetString ("SubscribedParameter", "DEFAULT");
	}

	public void ToInitiateLoadingScreen(){
		LoadingScreen.SetActive (true);
	}

	public void ToInitiateTerms(){
		Terms.SetActive (true);
	}


	public void StartExploring(){
		WelcomePanel.SetActive (false);
        PlayerPrefs.SetInt("openedwelcome", 1);
	}



}  