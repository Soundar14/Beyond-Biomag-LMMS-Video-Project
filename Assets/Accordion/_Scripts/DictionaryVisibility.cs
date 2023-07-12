using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DictionaryVisibility : MonoBehaviour {
	

	public static DictionaryVisibility DictionaryClass;

    //bool _isShown = false;
	public Button resetbutton,GuideButton;
	public GameObject SPDropdown;
	void OnStart(){
		DictionaryClass = this;
	
	}
		
	public void ShowDictionary()
    {
		UniversalClass.IsDictionaryEnabled = true;
	
//zxz		Debug.Log (UniversalClass.IsDictionaryEnabled);
		SPDropdown.SetActive (false);
		AnimatorAssembly.AnimatorController.EnableDictionary();


		if (EventManager.EvntManager.NavBool) {
			EventManager.EvntManager.EnableNavigationdrawer ();
		}

		else if(EventManager.EvntManager.SlideBool) {
			EventManager.EvntManager.SlideMenuFunction ();
		}

		else if(EventManager.EvntManager.showMenu) {
			EventManager.EvntManager.ExpandMenu ();
		}
    }

	public void HideDictionary()
    {
		AnimatorAssembly.AnimatorController.DisableDictionaryAnimation();
    }

}
