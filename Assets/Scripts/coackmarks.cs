using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class coackmarks : MonoBehaviour {
	public int x = 1;
	public Sprite c1;
	public Sprite c2;
	public Sprite c3;
	public Sprite c4;
	public Sprite c5;
	public Sprite c6;
	public Sprite c7;
	public Sprite c8;
	public Sprite c9;
	public Sprite c10;
	public Sprite c11;
	public Sprite c12;
	public Sprite c13;
	public Sprite c14;
	public Sprite c15;
	public Sprite c16;
	public Sprite c17;

	public Sprite c18;
	public Sprite c19;
	public GameObject coackmarksG;
	public Text Heading;
	public Text Footer;
	public UIlables uil;
	public bool checking = false;



	public float minSwipeDistX;

	public int count = 0;

	private Vector2 startPos;



	public void OnMouseUp(){

		//coachmarks ();
		checking = true;

	}
	public void OnEnable(){

		UniversalClass.UIPanelEnabled = true;
	}

	public void OnDisable(){

		UniversalClass.UIPanelEnabled = false;
	}


	void Update () {

		if (Input.touchCount > 0) 

		{
			Debug.Log ("touch");
			Touch touch = Input.touches[0];



			switch (touch.phase) 

			{

			case TouchPhase.Began:

				startPos = touch.position;

				break;



			case TouchPhase.Ended:

				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

				if (swipeDistHorizontal > minSwipeDistX) 

				{

					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);


					if (swipeValue < 0) {

						Debug.Log ("left");
						x = x + 1;
						count++;
						coachmarks ();

					}
					else if (swipeValue > 0) {

						Debug.Log ("right");
						count--;
						x = x - 1;
						coachmarks ();

						if (x <= 1) {

							x = 1;

						}



					}


				}
				break;

			}
		}
	}


	public void coachmarks()
	{
		//Footer.text = "Swipe Left To Continue";

		if (x == 1) {
			gameObject.GetComponent<Image> ().sprite = c1;

			Heading.text = uil.welcome;
			Footer.text = uil.swipeleft;
		}
		if (x == 2) {
			Heading.text = "";
			Footer.text = uil.t2;
			gameObject.GetComponent<Image> ().sprite = c2;
		}

		if (x == 3) {
			gameObject.GetComponent<Image> ().sprite = c3;
			Footer.text = uil.t3;
		}
		if (x == 4) {
			gameObject.GetComponent<Image> ().sprite = c4;
			Footer.text = uil.t4;
		}
		if (x == 5) {
			gameObject.GetComponent<Image> ().sprite = c5;
			Footer.text = uil.t5;
		}
		if (x == 6) {
			gameObject.GetComponent<Image> ().sprite = c6;
			Footer.text = uil.t6;
		}
		if (x == 7) {
			gameObject.GetComponent<Image> ().sprite = c7;
			Footer.text = uil.t7;
		}
		if (x == 8) {
			gameObject.GetComponent<Image> ().sprite = c8;
			Footer.text = uil.t8;
		}
		if (x == 9) {
			gameObject.GetComponent<Image> ().sprite = c9;
			Footer.text = uil.t9;
		}
		if (x == 10) {
			gameObject.GetComponent<Image> ().sprite = c10;
			Footer.text = uil.t10;
		}
		if (x == 11) {
			gameObject.GetComponent<Image> ().sprite = c11;
			Footer.text = uil.t11;
		}
		if (x == 12) {
			gameObject.GetComponent<Image> ().sprite = c12;
			Footer.text = uil.t12;
		}
		if (x == 13) {
			gameObject.GetComponent<Image> ().sprite = c13;
			Footer.text = uil.tconcentric;
		}
		if (x == 14) {
			gameObject.GetComponent<Image> ().sprite = c14;
			Footer.text = uil.tdictionarycoachmarks;
		}
		if (x == 15) {
			gameObject.GetComponent<Image> ().sprite = c15;
			Footer.text = uil.tdictionaryscanpoint;
		}
		if (x == 16) {
			gameObject.GetComponent<Image> ().sprite = c16;
			Footer.text = uil.tdictionarycorresponding;
		}
		if (x == 17) {
			gameObject.GetComponent<Image> ().sprite = c18;
			Footer.text = uil.t14;
		}
		if (x == 18) {
			gameObject.GetComponent<Image> ().sprite = c19;
			Footer.text = uil.t19;
		}
		if (x == 19) {
			gameObject.GetComponent<Image> ().sprite = c17;
			Footer.text = uil.t13;
		}
		if (x >= 20) {
			coackmarksG.SetActive (false);
			Footer.text = uil.swipeleft;
			x = 1;
			gameObject.GetComponent<Image> ().sprite = c1;
		}

	}






}




