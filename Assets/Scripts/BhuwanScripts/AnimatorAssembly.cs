//Animation of the application will be handled. In-out and sliding of the screens.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnimatorAssembly : MonoBehaviour {
		 
		public Animator LoginAnimator,NavigationAnimator,BottomMenuAnimator,SlideMenuAnimator,DictionaryAnimator,SubscriptionInfo;
	    public Button NavgationButton,GuideButton;
		public static AnimatorAssembly AnimatorController; 
	    public Animator TimerAnimator;
		public GameObject DictionaryBackground;
	    public GameObject loginerror;
		public CanvasGroup NavigationPanel;
		public bool DictionaryToggle,TimerToggle;
	// Use this for initialization
	void Start () {
				AnimatorController = this;	
		DictionaryToggle = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if (EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButton(0)) {
//			
//			if (DictionaryToggle ) {
//				DictionaryAnimator.SetTrigger ("DisableDictionary");
//				DictionaryToggle = false;
//				NavgationButton.interactable = true;
//				GuideButton.interactable = true;
//			}
//		}
	}

	public void EnableDictionary(){
		DictionaryToggle = true;
		DictionaryAnimator.SetTrigger ("EnableDictionary");
		NavgationButton.interactable = false;
		DictionaryToggle = true;
		DictionaryBackground.SetActive (true);
	}


	// Disable Dictionary Animation
	public void DisableDictionaryAnimation(){
		DictionaryToggle = false;
		DictionaryAnimator.SetTrigger ("DisableDictionary");
		NavgationButton.interactable = true;
		GuideButton.interactable = true;
		DictionaryBackground.SetActive (false);
		UniversalClass.IsDictionaryEnabled = false;
//		Debug.Log (UniversalClass.IsDictionaryEnabled);
	}


	public void PlayLoginAnimation(){
			LoginAnimator.SetTrigger ("OnLoignClick");
	}

		
		public void PlayLogOutClickAnimation(){
				LoginAnimator.SetTrigger ("ReverseLogin");
		    
		}

   // Navigation Click
		public void NavigationOnAnimation(){
				NavigationAnimator.SetTrigger ("NaviagtionON");
		}

	// Navigation OFF
		public void NavigationOFFAnimation(){
				NavigationAnimator.SetTrigger ("NavigationOFF");
		NavigationPanel.blocksRaycasts = false;

		}

    // BottomMenuAnimator ON
		public void BottomMenuON(){
				BottomMenuAnimator.SetTrigger ("BottomMenuON");
		}

		// BottomMenuAnimator OFF
		public void BottomMenuOFF(){
				BottomMenuAnimator.SetTrigger ("BottomMenuOFF");
		}

		// SldeMenu ON
		public void SlideMenuMenuON(){
				SlideMenuAnimator.SetTrigger ("SlideMenuON");
		}

		//SldeMenu OFF
		public void SlideMenuOFF(){
				SlideMenuAnimator.SetTrigger ("SlideMenuOFF");
		}

	public void SubscriptionIncoPlay(){
		SubscriptionInfo.SetTrigger ("SubInfoTrig");
	}

	public void ErrorLoginOff(){
		loginerror.SetActive (false);
	}

	public void TimerAnimationToggler(){
		TimerToggle = !TimerToggle;
		TimerAnimator.SetBool ("TimerOn", TimerToggle);
	}
}
