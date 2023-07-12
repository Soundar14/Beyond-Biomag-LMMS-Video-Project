using UnityEngine;
using System.Collections;

public class SmoothFollow1 : MonoBehaviour {
	
		public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


				if (target != null) {
						gameObject.transform.SetParent (target.transform);
						gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, gameObject.transform.parent.position, Time.deltaTime);
						transform.localRotation = Quaternion.Slerp (transform.localRotation, Quaternion.Euler(90,0,0) , Time.deltaTime);
				}
	
	}
}
