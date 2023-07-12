using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserRestriction : MonoBehaviour {
	public GameObject RestrictionPanel;

	void Update() {
		
		if (UniversalClass.NoInternetConnection == true) {
			RestrictionPanel.SetActive (true);
		} 
		else 
		{
			RestrictionPanel.SetActive (false);
		}
	}
}
