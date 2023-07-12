using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CorrespondingPointGameObject : MonoBehaviour {

		public GameObject Pivot;
		public AccuCamera PointManager;
		public GameObject DropDown;
	    public ScanPointPlayer ScanPlayer;
	public Material RedHighlight,RedOriginal,Original;
		public enum PivotDirection
		{
				front, back, left, right, top, bottom
		}
		public PivotDirection pd;

		// Use this for initialization
		void Start () 
		{

		RedHighlight = LoadScanPoints.instance.RedHighlight;
		RedOriginal = LoadScanPoints.instance.RedOriginal;
		Original = LoadScanPoints.instance.Original;
		ScanPlayer = GameObject.Find ("ScanPlayer").GetComponent<ScanPointPlayer> ();
				PointManager = Camera.main.GetComponent<AccuCamera> ();
		
		//ScanPlayer = GameObject.Find ("ScanPlayer").GetComponent<ScanPointPlayer> ();
				CreatePivot ();
		}


		void OnDestroy()
		{
				
		}
				

		public void OnMouseDown()
		{
				Debug.Log ("Clicked the object : "+ gameObject.name );
				switch (pd)
				{
				case PivotDirection.front:
						Pivot.transform.rotation = Quaternion.identity;
						break;
				case PivotDirection.left:
						Pivot.transform.rotation = Quaternion.Euler(0,90,0);
						break;
				case PivotDirection.back:
						Pivot.transform.rotation = Quaternion.Euler(0,180,0);
						break;

				case PivotDirection.right: 
						Pivot.transform.rotation = Quaternion.Euler(0,270,0);
						break;
						//				case 'c':
						//					Pivot.transform.rotation = Quaternion.Euler(0,310,0);
						//					break;
				default:
						break;
				}
		OnFocus ();
		}

		public void OnFocus(){

		switch (pd) {
		case PivotDirection.front:
			Pivot.transform.rotation = Quaternion.identity;
			break;
		case  PivotDirection.left:
			Pivot.transform.rotation = Quaternion.Euler(0,90,0);
			break;
		case PivotDirection.top:
			Pivot.transform.rotation = Quaternion.Euler(60,0,0);
			break;
		case  PivotDirection.back:
			Pivot.transform.rotation = Quaternion.Euler(0,180,0);
			break;
		case  PivotDirection.bottom:
			Pivot.transform.rotation = Quaternion.Euler(-60,180,0);
			break;
		case  PivotDirection.right:
			Pivot.transform.rotation = Quaternion.Euler(0,270,0);
			break;
			//				case 'c':
			//						Pivot.transform.rotation = Quaternion.Euler(0,310,0);
			//						break;
		default:
			break;
		}
		ScanPlayer.FocusScanPoints (Pivot);
		

		UniversalClass.PreviousPointCP = UniversalClass.CurrentPointCP;
		UniversalClass.CurrentPointCP = this.gameObject;

		UniversalClass.CurrentPoint.GetComponent<Renderer> ().material = Original;
		GetComponent<Renderer> ().material =  RedHighlight;

		//UniversalClass.CurrentPoint.GetComponent<Renderer> ().material.color = Color.green;

		UniversalClass.CurrentPointCP.GetComponent<Renderer> ().material = RedHighlight;

		if (UniversalClass.PreviousPointCP != null && UniversalClass.PreviousPointCP != UniversalClass.CurrentPointCP) {
			UniversalClass.PreviousPointCP.GetComponent<Renderer> ().material = RedOriginal;
		}  


			
		      
				//PointManager.GetFocusTargetPoint(Pivot.transform);
		}

		void CreatePivot()
		{
				Pivot = new GameObject ();
				Pivot.name = " "+gameObject.name;
				Pivot.transform.parent = transform;
				Pivot.transform.rotation = Quaternion.identity;
				Pivot.transform.localPosition = Vector3.zero;
				Pivot.transform.localScale = Vector3.one * 0.0353507f;
		      //  ScanPlayer.FindScanPointPivot (gameObject);
		}

		void DeleteAllChildren(GameObject parentGO)
		{
				foreach (Transform child in parentGO.transform)
				{
						Destroy(child.gameObject);
				}
		}
}
