using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashNext : MonoBehaviour {
	public int delayTime=0;
	// Use this for initialization
	void Start () {
		Invoke ("LoadSplash",delayTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//void LoadSplash()=>SceneManager.LoadScene (Application.LoadLevel + 1);
	
}
