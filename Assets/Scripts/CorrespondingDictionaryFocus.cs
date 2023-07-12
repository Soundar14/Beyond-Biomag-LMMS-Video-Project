﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class CorrespondingDictionaryFocus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void GeneraliseclickFunctionCheck()
	{
		gendertog.genderToggleObject.cpointDisablingReset ();//..TO DISABLE ALL THE CP'S ON CLICKING 

		UniversalClass.Current_CP_gameObject = GameObject.Find (transform.parent.GetChild(1).gameObject.GetComponent<Text>().text+"_CP");    //GetComponent<Text> ().text+"_CP");
		try {
			if(UniversalClass.IsDictionaryEnabled == true){

				if(UniversalClass.Previous_CP_gameObject != null)
					UniversalClass.Current_CP_gameObject.GetComponent<MeshRenderer>().enabled = false;
			}

		}
		catch (System.Exception e) {
			print("Corresponding Pair not available");
		}  
		try {

			if(UniversalClass.Current_CP_gameObject.tag == "MaleCorrespondingPoints" || UniversalClass.Current_CP_gameObject.tag == "FemaleCorrespondingPairs" ){
				if(UniversalClass.IsDictionaryEnabled == true){
					UniversalClass.Current_CP_gameObject.GetComponent<MeshRenderer> ().enabled = true;
				}
				UniversalClass.Current_CP_gameObject.GetComponent<CorrespondingPointGameObject> ().OnFocus ();
				UniversalClass.Previous_CP_gameObject = UniversalClass.Current_CP_gameObject;

			}
		}
		catch (System.Exception e) {
			print("Corresponding Pair not available"+e);
		}  
	}
}


