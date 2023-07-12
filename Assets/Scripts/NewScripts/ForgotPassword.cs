using UnityEngine;
using System.Collections;

public class ForgotPassword : MonoBehaviour {

	 public GameObject forgotPassword;

	// Use this for initialization
	void Start () {
//		forgotPassword.SetActive (false);
	}
	
	// Update is called once per frame
	public void forgot()
	{
		forgotPassword.SetActive (true);
		}

	public void forgotSave()
	{
		forgotPassword.SetActive (false);
	}
}
