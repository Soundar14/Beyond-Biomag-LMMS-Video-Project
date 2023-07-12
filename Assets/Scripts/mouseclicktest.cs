using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class mouseclicktest : MonoBehaviour {


//	public void OnMouseDown(){
//
//		if (!EventSystem.current.IsPointerOverGameObject()) {
//			GetComponent<Renderer> ().material.color = Color.green;
//		}
//	}
//	public void OnMouseUp(){
//
//		//if(!EventSystem.current.IsPointerOverGameObject)
//		GetComponent<Renderer> ().material.color = Color.white;
//	}
//

//	public  Vector3 Initialposition;

	public void Start(){
//		Initialposition = transform.position;
//		transform.position = Initialposition;
	}

	public void Update(){
		transform.Translate (0, 4*Time.deltaTime, 0);
	}
}

