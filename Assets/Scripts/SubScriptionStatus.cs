using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubScriptionStatus : MonoBehaviour {


	public float counter;

	void OnEnable(){
		counter = 4f;
	

	}
	void Update(){

		counter -= Time.deltaTime;

		if (counter <= 0) {
			counter = 4f;
			gameObject.SetActive (false);
		}

	}



}




