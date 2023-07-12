//Scripts handles the UI activities such as Button actions, Sound handler.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {
	
	//public CanvasGroup DictionaryCanvas;
	public AudioClip ClickSound,Timersound;
	public AudioSource AudiSouce;
	//public GameObject ScanguideC;

	//public GameObject ScanguidePanel;
	public static UI_Manager UIManager;
	public Button navigation;
	public Button Gender;
	public Button DictionaryBtn,ResetButton,PointsButton;
	public bool ButtonToggle;
	// Use this for initialization
	void Start () {
		ButtonToggle = false;
		       UIManager = this;
				DisableDictionary ();
		         

	}

    // To Diable Dictionary
		public void EnableDictionary(){
		ButtonToggle = !ButtonToggle;

		if (ButtonToggle == true) {

			navigation.interactable = false;
			Gender.interactable = false;
			DictionaryBtn.interactable = false;
			ResetButton.interactable = false;
			PointsButton.interactable = false;
		}
		if (ButtonToggle == false) {
			
			navigation.interactable = true;
			Gender.interactable = true;
			DictionaryBtn.interactable = true;
			ResetButton.interactable = true;
			PointsButton.interactable = true;
		}
		}
		        
		

	// To Enable Dictionary
		public void DisableDictionary(){

		}

     // To Play Click Sound
		public void PlayClickSound(){
				AudiSouce.PlayOneShot (ClickSound);	
		}
	// To Play Click Sound
	public void PlayClickSound_Timer(){
		AudiSouce.PlayOneShot (Timersound);	
	}
	
}
