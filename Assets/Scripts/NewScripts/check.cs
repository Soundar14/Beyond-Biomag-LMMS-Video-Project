using UnityEngine;
using System.Collections;

public class check : MonoBehaviour {

	public  bool che2;

	// Use this for initialization
	void Start () {
		che2 = false;
	}
	
	// Update is called once per frame


	void OnMouseEnter()
	{
				che2 = true;
		}
	void OnMouseUp()
	{
		che2 = false;
	}

	void OnMouseDown()
	{
		che2 = true;
	}

}
