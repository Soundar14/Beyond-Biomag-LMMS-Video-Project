using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivation : MonoBehaviour {
	public void ToDeactivate()
	{
		gameObject.SetActive (false);
	}

	public void ToQuitAplication(){
		Application.Quit();
	}
}
