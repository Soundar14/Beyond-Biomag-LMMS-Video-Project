//Script handle the toggling of Yearly and monthly subscription.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscriptionToggler : MonoBehaviour {
	public GameObject Yearly,Monthly;
	public bool Tog;

	public void SubscriptionTog(){
		Tog = !Tog;
		if (Tog) {
			Yearly.SetActive (true);
			Monthly.SetActive (false);
		     
		} else {
			Yearly.SetActive (false);
			Monthly.SetActive (true);
		}
	}
}
