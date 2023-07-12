using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sceneloading : MonoBehaviour {

	public Transform loadingIcon;
	public bool loading = false;
	public float counter;

	void OnEnable(){
		counter = 26f;
		loading = true;

	}
	void Update(){
		
		counter -= Time.deltaTime;

		if (counter <= 0) {
			counter = 20f;
			gameObject.SetActive (false);
		}
		loadingIcon.transform.Rotate(0,0,6);
	}



}

	


