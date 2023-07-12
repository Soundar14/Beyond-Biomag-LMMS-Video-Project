// Script to handle the font/Text
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FontHandler : MonoBehaviour {
	
	// Update is called once per frame
	void Awake () {
		gameObject.GetComponent<Text>().font= LoadScanPoints.instance.Myfont;
	}

}
