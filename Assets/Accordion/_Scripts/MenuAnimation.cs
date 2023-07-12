using UnityEngine;
using System.Collections;

public class MenuAnimation : MonoBehaviour {
	Animator menuAnimation;
	bool _isShown = true;
	// Use this for initialization
	void Start () {
		menuAnimation = GetComponent<Animator> ();
		SwitchState ();
	}

	public void SwitchState()
	{
		_isShown = !_isShown;
		menuAnimation.SetBool ("isShown", _isShown);
	}
}
