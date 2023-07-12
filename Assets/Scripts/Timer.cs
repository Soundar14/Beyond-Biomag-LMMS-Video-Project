//Script to handle the stopwatch functionality.Play, pause and stop.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

	public InputField MinutesText,Secondstext;
	public bool TimeStatus,Timerrunning;
	public float countdown;
	public Sprite play, pause;
	public GameObject PlayPauseButton;
	public UI_Manager soundt;
	void Update(){
		if(MinutesText.text == "" ){
			PlayPauseButton.GetComponent<Button> ().interactable = false;
		}
		if(MinutesText.text != "" ){
			PlayPauseButton.GetComponent<Button> ().interactable = true;
		}
		if (countdown > 0 && TimeStatus == true)
		{
			countdown -= Time.deltaTime;
			string Minutes = ((int)countdown / 60).ToString ();
			string Seconds = (countdown % 60).ToString ("f1");
			MinutesText.text = Minutes;
			Secondstext.text = Seconds;
			//TimerText.text = Minutes + ":" + Seconds;
			MinutesText.interactable = false;
		}

		if (countdown < 0 && TimeStatus == true)
		{
//			PlayPauseButton.GetComponent<Image> ().sprite = play;
//			Debug.Log ("Time Over");
//			TimeStatus = false;
//			Timerrunning = false;
//			MinutesText.interactable = true;
			resettmer ();
			soundt.PlayClickSound_Timer ();
		}
	}


	public void Play_Pause_toggle(){
		TimeStatus = !TimeStatus;
		if (TimeStatus && Timerrunning == false) {
			countdown = int.Parse (MinutesText.text);
			countdown = countdown * 60;
			Timerrunning = true;
		} 
		if (TimeStatus == false) {
			PlayPauseButton.GetComponent<Image> ().sprite = play;
		}
		if (TimeStatus == true) {
			PlayPauseButton.GetComponent<Image> ().sprite = pause;
		}
	

	}

	public void resettmer(){
		PlayPauseButton.GetComponent<Image> ().sprite = play;
		TimeStatus = false;
		Timerrunning = false;
		countdown = 0;
		MinutesText.text = "";
		Secondstext.text = "";
		MinutesText.interactable = true;

	}

}
