//Script handles the functionality onClick of ScanPoint
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnClickSp : MonoBehaviour {




	public void GeneraliseclickFunctionCheck()
	{
		
		UniversalClass.Current_SP_gameObject = GameObject.Find (transform.parent.GetChild(1).gameObject.GetComponent<Text>().text);  

		try {
			if(UniversalClass.Previous_SP_gameObject != null){
				UniversalClass.CurrentPoint.GetComponent<MeshRenderer>().enabled = false;
				UniversalClass.CurrentPoint.GetComponent<BoxCollider> ().enabled = false;
			  // UniversalClass.Previous_SP_gameObject.GetComponent<MeshRenderer>().enabled = false;
			//UniversalClass.Current_SP_gameObject.GetComponent<BoxCollider> ().enabled = false;
			}
		}
		catch (System.Exception e) {
			print("SP  not available");
		}  


		try {

			if(UniversalClass.Current_SP_gameObject.tag == "ScanPointsMale"  || UniversalClass.Current_SP_gameObject.tag == "ScanPointsFemale"  )
			{

				UniversalClass.Current_SP_gameObject.GetComponent<MeshRenderer> ().enabled = true;
				UniversalClass.Current_SP_gameObject.GetComponent<BoxCollider> ().enabled = true;
				UniversalClass.Current_SP_gameObject.GetComponent<OnMouseClickClass> ().CallForFocus ();
				UniversalClass.Previous_SP_gameObject = UniversalClass.Current_SP_gameObject;

			}
		}
		catch (System.Exception e) {
			print(" SP not available");
			//print(e);
		}  
	}
}
