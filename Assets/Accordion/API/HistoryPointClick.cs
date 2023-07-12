using UnityEngine;

using System.Collections.Generic;
using UnityEngine.UI;

public class HistoryPointClick : MonoBehaviour {

	public  string SPName;
	public InputField SearchT;
	public string check;


	// Use this for initialization
	void Start () {
	

		gameObject.GetComponent<Button> ().onClick.AddListener (() => { ScanPointClick(); });
		SPName = gameObject.GetComponent<Text> ().text.ToString();

		//check = SPName;
			
	}
	
	public void ScanPointClick(){
		//check  = SPName.text.ToString();
		SearchT.text = check;
	}



}
