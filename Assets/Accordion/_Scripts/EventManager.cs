using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class EventManager : MonoBehaviour
{

    DateTime currentDate;
    DateTime oldDatee;
    //Singleton instantiation for Manager
    private static EventManager eventManager;
	//public  EventManager eventManager;
	
		//Dictionary button
	public Button DictionaryOpenBtn;
	public Button DictionaryCloseBtn;
	public Button DropdownCloseBtn;
	public Button ResetButton;

	public GameObject slidemenubutton;
	public int r;


	public GameObject AUS, PromotionPage;
	public GameObject Descriptionpanel;


	 public bool NavBool,SlideBool;

	Vector3 originalposition;
	public GameObject coackmarksG;
	//public GameObject IapStatus;


	public bool showMenu;
	public bool levelbool = true;

	public string CoachMarksMessage = "App opened for the first time";
	public GameObject Coachmarks,SubscriptionScreen,TermsandCondition;


	public GameObject loginScreen,SlideButton,AccordionDropdownParent;
	public CanvasGroup NavigationCanvas;
	public AnimatorAssembly animatoreassembly;

	
	//enable or disable pressure point 
	public Button EnableScanPointsBtn;

	public static EventManager EvntManager;
	//public bool showScanpoints;

	public GameObject ScanpointDropdown;
	GameObject[] sp;
	GameObject[] cp;

		//Focuss body parts buttons
	public AccuCamera cameraControl;

    EventManager()
    {
    }

    public static EventManager instance
    {
        get
        {
            if(eventManager == null)
                eventManager = GameObject.FindObjectOfType<EventManager>();
            return eventManager;
        }
    }

    void Awake()
    {
	
      DontDestroyOnLoad (transform.gameObject);
	
        if (eventManager != null && eventManager != this)
        {
            DestroyImmediate(gameObject);
        } else
        {
            eventManager = this;
            DontDestroyOnLoad(instance.gameObject);
        }
    }





	void Start()
	{
        //if (PlayerPrefs.GetInt("openedwelcome") == 1)
        //{
        //    PlaySubInfoStart();
        //}
        if (PlayerPrefs.GetInt("openedwelcome") == 1)
        {
            PromotionPage.SetActive(false);
        }

        DateTime date = DateTime.Now;


        // Store the current time when it starts
     long currentDatee = date.ToBinary();

        PlayerPrefs.SetString("sysString", currentDatee.ToString());

        //Grab the old time from the player prefs as a long
        long temp = long.Parse(PlayerPrefs.GetString("sysString"));


        //Convert the old time from binary to a DataTime variable
        DateTime oldDateee = DateTime.FromBinary(temp);

        //Use the Subtract method and store the result as a timespan variable
        TimeSpan difference = currentDate.Subtract(oldDateee);
        if(difference.Hours> 72)
        {
            PromotionPage.SetActive(true);
        }
        else
        {
            PromotionPage.SetActive(false);
        }



        if (PlayerPrefs.GetInt ("loginstatus") == 1) {
			SubscriptionScreen.GetComponent<CanvasGroup> ().alpha = 0; 
			SubscriptionScreen.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			SubscriptionScreen.GetComponent<CanvasGroup> ().interactable = false;
		} 
		if (PlayerPrefs.GetString ("Coachmarks") != CoachMarksMessage) {
			Coachmarks.SetActive (true);

		//	TermsandCondition.SetActive (true);
			PlayerPrefs.SetString ("Coachmarks",CoachMarksMessage);
		}
      
        r = 0;
		EvntManager = this;
		NavBool = false;
		SlideBool = false;
		showMenu = false;
    	loginScreen.SetActive (true);
		AUS.SetActive (false);
		levelbool = true;


		//ScanpointDropdown = GameObject.Find ("ScanPointDropDown");
		ScanpointDropdown = GameObject.Find ("Scanpoint Drowpdown");
//		AccordionDropdownParent = LoadScanPoints.instance.AccordionDropdownParent;

		if(ScanpointDropdown.activeSelf)
				ScanpointDropdown.SetActive (false);
	//	AccordionDropdownParent.SetActive (false);
		
		
		
		
				
		//DictionaryOpenBtn.onClick.AddListener (()=> { DictionaryButtonPressed(); });
		DictionaryCloseBtn.onClick.AddListener (()=> { CloseDictionaryButtonPressed(); });
		//DropdownCloseBtn.onClick.AddListener (()=> { CloseDropDown(ScanpointDropdown); });
		//MenuBtn.onClick.AddListener (() => { ExpandMenu(PathMenu); });
		//EnableScanPointsBtn.onClick.AddListener (() => { EnablePressurePoints(); });
		ResetButton.onClick.AddListener (()=> { CloseSpDropdown(); });


	//	sp = GameObject.FindGameObjectsWithTag ("ScanPoints");
	//	cp = GameObject.FindGameObjectsWithTag ("CorrespondingPoints");
				//EnablePressurePoints ();

	}
	void Update(){
		// Check if the left mouse button was clicked
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			// Check if finger is over a UI element
			if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
			{
				closemenu ();
				UniversalClass.UIPanelEnabled = false;
			}
		}


		//Debug.Log (Time.deltaTime + 1);
	}

    //UICanvas Delegates and Events

    public delegate void UIButtonPressEvent();
	
	//Dictionary events
    //public event UIButtonPressEvent openDictionaryEvent;
	//public event UIButtonPressEvent closeDictionaryEvent;

//    public event UIButtonPressEvent menuButtonEvent;
//    public event UIButtonPressEvent instructionButtonEvent;
//    public event UIButtonPressEvent resetButtonEvent;
    public event UIButtonPressEvent genderButtonEvent;
//    public event UIButtonPressEvent pointsTogglebuttonEvent;
//    public event UIButtonPressEvent showButtonsEvent;
	
	

    public delegate void SectionButtonsEvent(string SectionName);
//    public event SectionButtonsEvent sectionsButtonPressed;

    public void DictionaryButtonPressed()
    {
		//DictionaryL.SetActive (true);
		//openDictionaryEvent();

    }
	
	public void CloseDictionaryButtonPressed()
	{
		Descriptionpanel.SetActive (false);
		AnimatorAssembly.AnimatorController.DisableDictionaryAnimation();
		ResetButton.interactable = true;
	}

    public void GenderToggleButtonPressed()
    {
        genderButtonEvent();
    }
	
	public void CloseDropDown(GameObject dropdown)
	{
			//Debug.Log ("Close item pressed");
			dropdown.SetActive (false);
	}

	public void ExpandMenu()
	{
		gendertog.genderToggleObject.PointTog = false;
			showMenu = !showMenu;
				if (showMenu) {
			
			if (animatoreassembly.DictionaryToggle == true) {
				CloseDictionaryButtonPressed ();
			}
						if (NavBool) {
							EnableNavigationdrawer();
						}  
						if (SlideBool) {
							SlideMenuFunction();
						}


						AnimatorAssembly.AnimatorController.BottomMenuON ();
					}
				else if (!showMenu) {
					AnimatorAssembly.AnimatorController.BottomMenuOFF ();
				} 
			
	}
	
//	public void EnablePressurePoints()
//	{
//		showScanpoints = !showScanpoints;
//		ScanpointDropdown.SetActive(false);
//		foreach (GameObject go in sp)
//		{
//						go.GetComponent<MeshRenderer> ().enabled = showScanpoints;
//						go.GetComponent<BoxCollider> ().enabled = showScanpoints;
//		}
//		
//		foreach (GameObject go in cp)
//		{
//						go.GetComponent<MeshRenderer> ().enabled = showScanpoints;
//		}
//	}

   // For Navigation Menu Function
	public void EnableNavigationdrawer()

	{
		
				NavBool = !NavBool;
						if (NavBool) {
								if (SlideBool) {
				                SlideMenuFunction();
				           
								}  
								if (showMenu) {
								ExpandMenu ();
								}

			                //    DictionaryVisibility.DictionaryClass.HideDictionary ();
								AnimatorAssembly.AnimatorController.NavigationOnAnimation ();
		                       	NavigationCanvas.blocksRaycasts = true;
		  	                   // NavigationC.SetActive (true);
		                        SlideButton.SetActive (false);
		                    	UniversalClass.UIPanelEnabled = true;

		                     	 

						}
				        else if (!NavBool) {
						
								AnimatorAssembly.AnimatorController.NavigationOFFAnimation ();
						        SlideButton.SetActive (true);
			                   // NavigationC.SetActive (false);
		                       	NavigationCanvas.blocksRaycasts = false;
			UniversalClass.UIPanelEnabled = false;

						}                     
		}

	// For SlideMenu function
		public void SlideMenuFunction()
		{
				SlideBool = !SlideBool;
				{ 
						if (SlideBool) {
							if (NavBool) {
				            	EnableNavigationdrawer();
							}     
							if (showMenu) {
								ExpandMenu ();
							}
				            //    DictionaryVisibility.DictionaryClass.HideDictionary ();
								AnimatorAssembly.AnimatorController.SlideMenuMenuON ();
				//slidemenubutton.transform.rotation.z = r;
						}
						else if (!SlideBool) {
								AnimatorAssembly.AnimatorController.SlideMenuOFF ();
						}                     
				}
		}
		public void closemenu(){
		
					if (NavBool)
						AnimatorAssembly.AnimatorController.NavigationOFFAnimation ();
		                NavBool = false;
		                SlideButton.SetActive (true);
		              // NavigationC.SetActive (false);

				    if(SlideBool)
						AnimatorAssembly.AnimatorController.SlideMenuOFF ();
		               SlideBool = false;
			        if(showMenu)
						AnimatorAssembly.AnimatorController.BottomMenuOFF ();
		                showMenu = false;
			}




	 public void CloseSpDropdown()
	{
		//showScanpoints = false;
		ScanpointDropdown.SetActive(false);
	//	AccordionDropdownParent.SetActive (false);
	}

	///////////////////////////////////////ARE YOU SURE UI/////////////////////////////////////////////////////////////////
	public void AUSON()
	{
		AUS.SetActive (true);
	}
	public void AUSOFF()
	{

		AUS.SetActive (false);
	}

    public void coachmarksOn(){
	coackmarksG.SetActive (true);
    }
	public void coachmarksOff(){
	coackmarksG.SetActive (false);
	}

	public void ToDisableTermsandCondition(){
		
	}
	public void LoginPrefReset(){
		PlayerPrefs.SetInt("loginstatus",0);
	}

	public void PlaySubInfoStart(){
		Invoke ("PlaySubInfo", 30f);
	}

	public void PlaySubInfo()
	{
		if (PlayerPrefs.GetString ("SubscribedParameter") != "KP18Z7") 
		{
			AnimatorAssembly.AnimatorController.SubscriptionIncoPlay ();
		}
		Invoke ("PlaySubInfoStart", 1f);

	}


    void OnApplicationQuit()
    {
        //Savee the current system time as a string in the player prefs class
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());

        print("Saving this date to prefs: " + System.DateTime.Now);
    }
}





















