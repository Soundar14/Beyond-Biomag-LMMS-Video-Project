using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {
	public GameObject preab2;
	public GameObject preab1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void destroypref()
	{
		Destroy (preab1);
		Destroy (preab2);
		}
}
