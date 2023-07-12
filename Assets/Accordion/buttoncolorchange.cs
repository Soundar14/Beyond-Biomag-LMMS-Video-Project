using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class buttoncolorchange : MonoBehaviour {

	public void ColorChange(){
		
			UniversalClass.PreviousButton = UniversalClass.CurrentButton;
			UniversalClass.CurrentButton = this.gameObject;
	
		UniversalClass.CurrentButton.GetComponent<Image> ().color = Color.black;
		if (UniversalClass.PreviousButton != null  && UniversalClass.PreviousButton != UniversalClass.CurrentButton) {
				UniversalClass.PreviousButton.GetComponent<Image> ().color = Color.white;
			}
	

}
}
