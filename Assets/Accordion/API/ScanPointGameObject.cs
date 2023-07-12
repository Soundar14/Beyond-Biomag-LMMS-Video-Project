using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScanPointGameObject : MonoBehaviour {

	public ScanPoint ScanPointInfo;
	public List<GameObject> CorrespondingPoints; 
	public AccuCamera PointManager;
	public char pivotDirection;
	public GameObject Pivot;
	public GameObject CanvasObject;
	public GameObject Section;
	public GameObject SectionName;
	public GameObject CorrespondingPairUI;
	public GameObject ScanpointDropdown;

	public GameObject DropDown;

//	public enum PivotDirection
//	{
//			front, back, left, right
//	}
	//public PivotDirection pd;

	// Use this for initialization
	void Start () 
	{
//		print (gameObject.transform.localEulerAngles +" "+ gameObject.transform.eulerAngles +" "+ gameObject.transform.rotation );		
		LoadScanPoints.instance.IntimateScanPoints += InitilaizeScanPoints;
		//CreatePivot ();
		CanvasObject = GameObject.Find ("UICanvas");
		ScanpointDropdown = LoadScanPoints.instance.AccordionDropdown;
				
		Section = LoadScanPoints.instance.Spui;
		SectionName = LoadScanPoints.instance.ScanpointtitleUI;
		CorrespondingPairUI = LoadScanPoints.instance.Cptitle;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnDestroy()
	{
				if(LoadScanPoints.instance != null)
					LoadScanPoints.instance.IntimateScanPoints -= InitilaizeScanPoints;
	}

	void InitilaizeScanPoints()
	{
				if(LoadScanPoints.instance.Scanpoint_cPair_Dict.ContainsKey(gameObject.name))
				{
						
						List <CorrespondingPair> cpList = new List<CorrespondingPair> ();
						LoadScanPoints.instance.Scanpoint_cPair_Dict.TryGetValue (gameObject.name, out cpList);
						//print(gameObject.name +" Found ! , List size : " + cpList.Count);

						foreach (CorrespondingPair cp in cpList)
						{
								GameObject cpGameObject = GameObject.Find (cp.Code);
								if (cpGameObject != null && !CorrespondingPoints.Contains(cpGameObject)) {
										CorrespondingPoints.Add (cpGameObject);
								}			
						}
				}
	}

	public void testing()
	{
//			Debug.Log ("Clicked the object : "+ gameObject.name );
//			switch (pd)
//			{
//				case PivotDirection.front:
//					Pivot.transform.rotation =  Quaternion.identity;
//					break;
//				case PivotDirection.left:
//					Pivot.transform.rotation = Quaternion.Euler(0,90,0);
//					break;
//				case PivotDirection.back:
//					Pivot.transform.rotation = Quaternion.Euler(0,180,0);
//					break;
//				case PivotDirection.right: 
//					Pivot.transform.rotation = Quaternion.Euler(0,270,0);
//					break;
////				case 'c':
////					Pivot.transform.rotation = Quaternion.Euler(0,310,0);
////					break;
//				default:
//					break;
//			}
			
			//PointManager.limit = 2;
			PointManager.limit = 120;
			PointManager.distance = 90;

			PointManager.GetFocusTargetPoint(Pivot.transform);
			ScanpointDropdown.SetActive (true);
//			DeleteAllChildren (ScanpointDropdown);
//
//			PointManager.GetFocusTargetPoint(Pivot.transform);
//			GameObject SectionUI = Instantiate (Section);
//			GameObject ScanpointNameUI = Instantiate (SectionName);
//			ScanpointNameUI.GetComponent<Text> ().text = gameObject.name;
//		
//			ScanpointNameUI.transform.SetParent (SectionUI.transform);
//			foreach (GameObject cp in CorrespondingPoints) 
//			{
//				GameObject corresPointUI = Instantiate (CorrespondingPairUI);
//				corresPointUI.GetComponent<Text> ().text = cp.name;
//				corresPointUI.transform.SetParent (SectionUI.transform);
//			}
//
//			SectionUI.transform.SetParent (ScanpointDropdown.transform);
			//CanvasObject.transform.SetParent(ScanpointDropdown.transform);
			
			GameObject dropdown = ScanpointDropdown.transform.GetChild (0).gameObject;//Instantiate (DropDown) as GameObject;
			dropdown.transform.GetChild (0).gameObject.GetComponent<Text> ().text = gameObject.name;
			CorrespondingPairUI = dropdown.transform.GetChild (1).gameObject;
			
			//TODO
			for(int i=0; i <CorrespondingPoints.Count; i++)// (GameObject cp in CorrespondingPoints) 
			{
				//if(i != 0)
					//CorrespondingPairUI = Instantiate (CorrespondingPairUI) as GameObject;
					
					CorrespondingPairUI.GetComponent<Text> ().text = CorrespondingPoints[i].name;
					CorrespondingPairUI.GetComponent<Button> ().onClick.AddListener (()=>{ ChangeTarget(); });
					Debug.Log ("CP name : " + CorrespondingPoints[i].name);
					CorrespondingPairUI.transform.SetParent (dropdown.transform);
					
			}
	}
			
//		public void OnFocus(){
//
//				switch (pd) {
//				case PivotDirection.front:
//						Pivot.transform.rotation = Quaternion.identity;
//						break;
//				case  PivotDirection.left:
//						Pivot.transform.rotation = Quaternion.Euler(0,90,0);
//						break;
//				case  PivotDirection.back:
//						Pivot.transform.rotation = Quaternion.Euler(0,180,0);
//						break;
//				case  PivotDirection.right:
//						Pivot.transform.rotation = Quaternion.Euler(0,270,0);
//						break;
////				case 'c':
////						Pivot.transform.rotation = Quaternion.Euler(0,310,0);
////						break;
//				default:
//						break;
//				}
//				PointManager.GetFocusTargetPoint(Pivot.transform);
//		}

//		void CreatePivot()
//		{
//				Pivot = new GameObject ();
//				Pivot.name = "pivObj_"+gameObject.name;
//				Pivot.transform.parent = transform;
//				Pivot.transform.rotation = Quaternion.identity;
//				Pivot.transform.localPosition = Vector3.zero;
//				Pivot.transform.localScale = Vector3.one * 0.0553507f;
//		}
			
		void DeleteAllChildren(GameObject parentGO)
		{
				foreach (Transform child in parentGO.transform)
				{
						Destroy(child.gameObject);
				}
		}

		//TODO
		public void ChangeTarget()
		{
		DropDown = LoadScanPoints.instance.CorrespondingPoints [Random.Range (0, LoadScanPoints.instance.CorrespondingPoints.Length - 1)];
		   DropDown.GetComponent<CorrespondingPointGameObject>().OnFocus();
	}
}
