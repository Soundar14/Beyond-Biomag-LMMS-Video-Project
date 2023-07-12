using UnityEngine;
using System.Collections;

public class Scanguide : MonoBehaviour {

	public GameObject[] scanguide;
	public float delay = 2f;
	//int i = 0;

	// Use this for initialization

	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator Start() {
		int i = 0;
		yield return new WaitForSeconds(delay);
			i++;  


	}

}
