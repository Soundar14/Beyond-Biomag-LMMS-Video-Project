using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
    public GameObject LoginScreen,ExteriorObj, InteriorObj,FocusCam,sideUIExand,sideUIClose,BaseUI,MaleObject,FemaleObject,DictionaryWindow;
//	public UISprite SideUI;//,PointEnable,PointDisable;
//    bool isSideUI=false;
    bool isPoints = false;


	// Use this for initialization
	void Start () {
		LoginScreen.SetActive (true);
	}
	
	// Update is called once per frame
    void Update()
    {
       
    }

	public void SignIn(){
		LoginScreen.SetActive (false);
	}

//    public void OpenSideUI()
//    {
//       // isSideUI = !isSideUI;
//
//
//        if (isSideUI)
//        {
//           // SideUI.pivot = UIWidget.Pivot.Right;
//			StartCoroutine(SlideXAnchor(SideUI,0,0.1f));
//
//            isSideUI = false;
//			sideUIExand.SetActive (true);
//			sideUIClose.SetActive (false);
//        }
//        else
//        {
//            //SideUI.pivot = UIWidget.Pivot.Left ;
//			StartCoroutine(SlideXAnchor(SideUI,0.24f,0.1f));
//			sideUIExand.SetActive (false);
//			sideUIClose.SetActive (true);
//            isSideUI = true;
//        }
//
//    }

//	IEnumerator SlideXAnchor(UISprite sprite,float newPos,float speed){
//		while (sprite.GetComponent<UIAnchor>().relativeOffset.x!=newPos) {
//			sprite.GetComponent<UIAnchor>().relativeOffset.x = Mathf.MoveTowards(sprite.GetComponent<UIAnchor>().relativeOffset.x,newPos,speed);
//			//print ("side");
//			yield return new WaitForSeconds(Time.deltaTime);
//		}
//
//	}

    public void Reset()
    {


    }

	public void OnClickPoints(GameObject PointDisable,GameObject PointEnable)
    {
        if (isPoints)
        {
            PointEnable.gameObject.SetActive(true);
            PointDisable.gameObject.SetActive(false);
			FocusCam.transform.parent.parent=null;
//            FocusCam.GetComponent<AccuCamera>().HidePoints();

            isPoints = false;
        }
        else
        {
            PointEnable.gameObject.SetActive(false);
            PointDisable.gameObject.SetActive(true);
			FocusCam.GetComponent<AccuCamera>().OnShowPoints();
            isPoints = true;
        }

    }

	public bool isMale=true;
	public void ChangeGender(GameObject PointDisable,GameObject PointEnable)
	{
		FocusCam.GetComponent<AccuCamera> ().Start ();
		if (isMale)
		{
			PointEnable.gameObject.SetActive(true);
			PointDisable.gameObject.SetActive(false);
			MaleObject.SetActive(false);
			FemaleObject.SetActive(true);
			isMale = false;
		}
		else
		{
			PointEnable.gameObject.SetActive(true);
			PointDisable.gameObject.SetActive(false);
			MaleObject.SetActive(true);
			FemaleObject.SetActive(false);
			isMale = true;
		}
		
	}

    public void OnBaseUI()
    {
		DictionaryWindow.SetActive (false);
		if (BaseUI.activeSelf)
			BaseUI.SetActive (false);
		else
			BaseUI.SetActive (true);
    }

	public void Dictionary(){

		OnBaseUI ();
		DictionaryWindow.SetActive (true);

	}
}
