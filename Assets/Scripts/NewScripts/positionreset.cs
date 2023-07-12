using UnityEngine;
using System.Collections;

public class positionreset : MonoBehaviour {

	Vector3 originalposition;

	public GameObject MaleSP,MaleCP;

	public GameObject FemaleSP,FemaleCP;

	// Use this for initialization
	void Start () {
		originalposition = transform.position;
	}

	// Update is called once per frame

	public void reserposition()
	{
		transform.position = originalposition;
		gendertog.genderToggleObject.PointTog = false;

	}

	public void restpoints(){
		StartCoroutine (YesButtonPointsReset ());
	} 


	IEnumerator YesButtonPointsReset(){

		yield return new WaitForSeconds (1);

		MaleCP.SetActive (true);
		MaleSP.SetActive (true);

		FemaleCP.SetActive (false);
		FemaleSP.SetActive (false);
	}

	void Update()//to restrict the model
	{

		//		{
		//			if (transform.position.x <= -5f)
		//				transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
		//			
		//			else if (transform.position.x >= 5f)
		//				transform.position = new Vector3(5f, transform.position.y, transform.position.z);
		//		}
		//
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, -350f, 300f), 
			Mathf.Clamp(transform.position.y, -400f, 800f),
			Mathf.Clamp(transform.position.z, 0, 0)
		);

	}



}
