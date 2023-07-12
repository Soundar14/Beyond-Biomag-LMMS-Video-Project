using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadlevel : MonoBehaviour {


	IEnumerator Start() {
		
		AsyncOperation async = SceneManager.LoadSceneAsync("Scene 1");
		yield return async;
		Debug.Log("Loading complete");
	}
}
