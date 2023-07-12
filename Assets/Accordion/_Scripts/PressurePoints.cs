using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PressurePoints : MonoBehaviour {
	public AccuCamera PointManager;
    public Material Blue, Green,Yellow;
    public List<Transform> Targets;

	public bool isRed;
    //public TextMesh Header, Info;

	public GameObject Pivot;
    //public bool isDetails;

	public char pivotDirection;
	// Use this for initialization
	void Start () {
		CreatePivot ();


		if (isRed) {
			PointManager.RedPoints.Add(transform);
			gameObject.SetActive(false);
			return;
		}

    //    PointManager.Points.Add(transform);

//		transform.parent.GetComponent<PointsGroup> ().SubPressurePoints.Add (transform);
       
        Deactivate();

		gameObject.SetActive (false);

//		Targets.Clear ();
//		GameObject[] Gobjs = GameObject.FindGameObjectsWithTag ("red");
//
//		List<GameObject> Trs = new List<GameObject> (Gobjs);
//
//		print (Trs.Count);
//		int tempcount = Random.Range (1, 4);
//		for (int i=0; i<tempcount; i++) {
//			int temp = Random.Range(0,Trs.Count);
//			Targets.Add(Trs[temp].transform);
//			Trs.RemoveAt(temp);
//		}



	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseDown()
    {
        
		switch (pivotDirection) {
		case 'f':
			Pivot.transform.rotation = Quaternion.identity;
			break;
		case 'l':
			Pivot.transform.rotation = Quaternion.Euler(0,90,0);
			break;
		case 'b':
			Pivot.transform.rotation = Quaternion.Euler(0,180,0);
			break;
		case 'r':
			Pivot.transform.rotation = Quaternion.Euler(0,270,0);
			break;
		case 'c':
			Pivot.transform.rotation = Quaternion.Euler(0,310,0);
			break;
		default:
			break;
		}



        foreach (Transform point in PointManager.Points)
        {
            if (point != transform)
            {
               // point.GetComponent<MeshRenderer>().material = Blue;
                point.GetComponent<PressurePoints>().Deactivate();
                point.gameObject.SetActive(false);

				foreach (Transform Target in point.GetComponent<PressurePoints>().Targets) {
					Target.gameObject.SetActive (false);
				}
            }
        }
       // GetComponent<MeshRenderer>().material = Green;

		foreach (Transform Target in Targets) {
			Target.gameObject.SetActive (true);
			//Target.GetComponent<MeshRenderer> ().material = Yellow;
		}
        //print("Clicked");
        ActivateText();

		PointManager.GetFocusTargetPoint(Pivot.transform);

	//	PointManager.DisplayDetails (transform, Targets);
    }


	public void OnFocus(){

		switch (pivotDirection) {
		case 'f':
			Pivot.transform.rotation = Quaternion.identity;
			break;
		case 'l':
			Pivot.transform.rotation = Quaternion.Euler(0,90,0);
			break;
		case 'b':
			Pivot.transform.rotation = Quaternion.Euler(0,180,0);
			break;
		case 'r':
			Pivot.transform.rotation = Quaternion.Euler(0,270,0);
			break;
		case 'c':
			Pivot.transform.rotation = Quaternion.Euler(0,310,0);
			break;
		default:
			break;
		}
		PointManager.GetFocusTargetPoint(Pivot.transform);
	}

	void CreatePivot(){
		Pivot = new GameObject ();
		Pivot.name = "pivObj";
		Pivot.transform.parent = transform;
		Pivot.transform.localPosition = Vector3.zero;
		Pivot.transform.localScale = Vector3.one * 0.0553507f;



	}


    public void ActivateText()
    {
     
    }

    public void Deactivate()
    {
       
    }
}
