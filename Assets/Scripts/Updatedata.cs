using UnityEngine;
using System.Collections;

public class Updatedata : MonoBehaviour {


	public GameObject UpdateDataPanel,Loadingpanel;
	public LoadScanPoints lsp;

	void Start(){
		Loadingpanel = LoadScanPoints.instance.loading;
	}

	public void ToCloseWindow(){

		UpdateDataPanel.SetActive (false);

	}

	public void ToRefereshData()
	{
		Loadingpanel.SetActive (true);
		UpdateDataPanel.SetActive (false);

		Invoke ("ToRefereshDataAfter", 1f);
	}

	public void ToRefereshDataAfter(){
		lsp.languageChange();
}

}
