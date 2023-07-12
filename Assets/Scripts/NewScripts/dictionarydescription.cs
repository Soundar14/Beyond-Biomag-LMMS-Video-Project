using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class dictionarydescription : MonoBehaviour {

	public GameObject descPanel;
	public GameObject descPanelBtn;
	public GameObject panel;
	public GameObject HistoryPanel;
	public GameObject DictionaryText;
	public GameObject historyText;





	// Use this for initialization
	void Start ()
	{
		descPanel.SetActive (false);
		descPanelBtn.SetActive (false);
	}
	
    public  void DescriptionTog ()
	{
				descPanel.SetActive (true);
		        descPanelBtn.SetActive (true);
	}
	public  void backDictionaryBtn ()
	{
		
	//	UniversalClass.IsDictionaryEnabled = false;
	//	Debug.Log (UniversalClass.IsDictionaryEnabled);

		HistoryPanel.SetActive (false);
		DictionaryText.SetActive (true);
		historyText.SetActive (false);

		for (int i = 0; i < panel.transform.childCount; i++) {

			Destroy(panel.transform.GetChild(i).gameObject);
			if (i == panel.transform.childCount - 1) {
				
				descPanel.SetActive (false);
				descPanelBtn.SetActive (false);
			} else {
		
				descPanel.SetActive (false);
				descPanelBtn.SetActive (false);
			}



		}


			

	}


}
			




