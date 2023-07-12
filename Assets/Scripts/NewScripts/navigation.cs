using UnityEngine;
using System.Collections;


public class navigation : MonoBehaviour {
	 bool nav;
	public GameObject navpanel;
	// Use this for initialization
	void Start () {
		nav = false;
	}
	

	public void navigationToggle(){
		nav = !nav;
		{ 
			if(nav)
			{
				navpanel.SetActive(true);
			}
			if(nav == false)
			{
				navpanel.SetActive(false);
			}
		}


		  
}
}
