using UnityEngine;
using System.Collections;

public class UIUtilities : MonoBehaviour {

	public void GenderChangeButton()
	{
	}

	public void DictionaryToggle()
	{
     //   EventManager.instance.DictionaryButtonPressed();
	}

    public void ChangeGender()
    {
        EventManager.instance.GenderToggleButtonPressed();
    }
}
